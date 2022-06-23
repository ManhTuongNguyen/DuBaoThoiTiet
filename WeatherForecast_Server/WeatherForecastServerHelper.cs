using System;
using System.Data;
using System.IO;
using System.Net;
using System.Xml.Linq;

namespace WeatherForecast_Server
{
    public partial class WeatherForecastServerHelper
    {
        //Thời gian tối thiểu để không cần cập nhật lại dữ liệu thời tiết bằng API
        private static readonly double minimumTimeNotNeedToUpdate = 15f;

        private static string directoryPath = Directory.GetCurrentDirectory() + @"/Temp/";

        private static readonly string APIUrl = "http://api.weatherapi.com/v1/forecast.xml?";
        private static readonly string APIUrlOptional = "&days=10&aqi=no&alerts=no&lang=vi";
        private static readonly string hashKey = "ChangeKeyToYourInBellowLine";
        private static readonly string key = Decryption.Decrypt(hashKey);

        private static string boundary = "-----------------------------------------------------";

        public static string GetApiURL(string cityName)
        {
            return APIUrl + "key=" + key + $"&q={cityName}" + APIUrlOptional;
        }

        public static ObjectDataWeather GetDataWeatherUsingDatabase(string cityName)
        {
            string query = "SELECT [Location], [Data], [TimeGetData] FROM [dbo].[Weather] ";
            query += $"WHERE [Location] = '{cityName}'";
            DataTable dataTable = DataProvider.ExecuteQuery(query);
            ObjectDataWeather obj = new ObjectDataWeather();
            obj.CityName = dataTable.Rows[0][0].ToString();
            obj.DataWeather = dataTable.Rows[0][1].ToString();
            obj.TimeGetData = dataTable.Rows[0][2].ToString();
            dataTable = null;
            return obj;
        }

        public static bool InsertDataWeatherToDatabase(string cityName, string data)
        {
            string timeNow = DateTime.Now.ToLocalTime().ToString();
            return DataProvider.ExecuteNonquery("exec USP_InsertData @cityName , @data , @timeGetData "
                , new object[] { cityName, data, timeNow }) > 0;
        }

        /// <summary>
        /// Tính toán thời gian chênh lệch giữa hai thời điểm
        /// </summary>
        /// <param name="time1">Thời gian thứ nhất</param>
        /// <param name="time2">Thời gian thứ hai</param>
        /// <returns>Số phút chênh lệch giữa thời điểm thứ hai và thứ nhất</returns>
        public static double CaculateDifferentTime(string time1, string time2)
        {
            DateTime timer1 = Convert.ToDateTime(time1);
            DateTime timer2 = Convert.ToDateTime(time2);

            TimeSpan duration = timer2.Subtract(timer1);

            return duration.TotalMinutes;
        }

        public static XDocument GetWeatherData(string location)
        {
            ObjectDataWeather obj = null;

            //Lấy dữ liệu thời tiết trên database
            try
            {
                obj = GetDataWeatherUsingDatabase(location);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine(boundary);
                Console.WriteLine("Không tìm thấy dữ liệu trên database");
                Console.WriteLine("Đang lấy dữ liệu thời tiết bằng API...");
                Console.WriteLine(boundary);
            }
            catch
            {
                Console.WriteLine(boundary);
                Console.WriteLine("Có lỗi đã xảy ra\nKhông thể kết nối đến database!");
                Console.WriteLine(boundary);
                //Lấy dữ liệu thời tiết từ API
                return GetDataWeatherUsingAPI(location);
            }

            if (obj == null)
            {
                //Không tìm thấy dữ liệu có sẵn trên hệ thống
                return GetDataWeatherUsingAPI(location);
            }

            //Tính thời gian chênh lệch giữa thời gian dữ liệu
            //được lưu trên database và thời gian hiện tại
            bool needUpdateDataWeather = CaculateDifferentTime(obj.TimeGetData, 
                DateTime.Now.ToLocalTime().ToString()) > minimumTimeNotNeedToUpdate;
            switch (needUpdateDataWeather)
            {
                case true:
                    //Tìm thấy dữ liệu có sẵn trên cơ sở dữ liệu
                    //Thời gian cập nhật của dữ liệu thời tiết này > minimumTimeNotNeedToUpdate
                    // => Cập nhật lại thông tin bằng API
                    Console.WriteLine(boundary);
                    Console.WriteLine("Đã tìm thấy dữ liệu trên database!");
                    Console.WriteLine($"Thời gian cập nhật của dữ liệu này là: {obj.TimeGetData}");
                    Console.WriteLine("Đang cập nhật lại dữ liệu thời tiết sử dụng API!");
                    Console.WriteLine(boundary);
                    return GetDataWeatherUsingAPI(location);
                case false:
                    //Tìm thấy dữ liệu có sẵn trên cơ sở dữ liệu, với thời gian cập nhật < minimumTimeNotNeedToUpdate
                    // => Không cần cập nhật dữ liệu thời tiết
                    Console.WriteLine(boundary);
                    Console.WriteLine("Đã tìm thấy dữ liệu trên database!");
                    Console.WriteLine($"Thời gian cập nhật của dữ liệu này là: {obj.TimeGetData}");
                    Console.WriteLine(boundary);
                    return XDocument.Parse(obj.DataWeather);
                default:
                    return null;
            }            
        }

        /// <summary>
        /// Lấy dữ liệu thời tiết tại 1 địa điểm sử dụng API
        /// </summary>
        /// <param name="cityName">Tên địa điểm lấy dữ liệu thời tiết</param>
        /// <returns>Thông tin thời tiết dưới dạng byte[]</returns>
        /// Special thank to WeatherAPI.com for providing API
        private static XDocument GetDataWeatherUsingAPI(string cityName)
        {
            XDocument xDocument;
            using (WebClient webClient = new WebClient())
            {
                string uri = GetApiURL(cityName);
                xDocument = XDocument.Load(uri);
                //Chèn (update) thông tin thời tiết vào database
                try
                {
                    InsertDataWeatherToDatabase(cityName, xDocument.ToString());
                    string message = $"Đã ghi dữ liệu thời tiết của tỉnh {cityName} " +
                        $"lên database thành công vào thời điểm: {DateTime.Now}!";
                    Console.WriteLine(message);
                }
                catch
                {
                    Console.WriteLine(boundary);
                    Console.WriteLine("Có lỗi đã xảy ra!");
                    Console.WriteLine("Không thể lưu dữ liệu lên database!");
                    Console.WriteLine(boundary);
                }
            };
            return xDocument;
        }

        public static byte[] GetCurrentDataWeather(string location)
        {
            XDocument xDocument = GetWeatherData(location);
            return GetBytesCurrentWeatherData(xDocument);
        }

        public static byte[] GetForecastDataWeatherByDay(string location)
        {
            XDocument xDocument = GetWeatherData(location);
            return GetBytesForecastWeatherDataByDay(xDocument);
        }
        public static byte[] GetForecastDataWeatherByHour(string location, int dayFromTimeGetData)
        {
            XDocument xDocument = GetWeatherData(location);
            return GetBytesForecastWeatherDataByHour(xDocument, dayFromTimeGetData);
        }
    }
}
