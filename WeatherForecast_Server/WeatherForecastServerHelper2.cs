using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;

namespace WeatherForecast_Server
{
    public partial class WeatherForecastServerHelper
    {
        public static byte[] ToByteArray<T>(T data)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, data);
                return memoryStream.ToArray();
            }
        }

        public static byte[] GetBytesCurrentWeatherData(XDocument xDocument)
        {
            string currentTemp = (string)xDocument.Descendants("current").Descendants("temp_c").FirstOrDefault() + "°C";
            string feelsLike = (string)xDocument.Descendants("current").Descendants("feelslike_c").FirstOrDefault() + "°C";
            string cloud = (string)xDocument.Descendants("current").Descendants("cloud").FirstOrDefault() + "%";
            string wind_kph = (string)xDocument.Descendants("current").Descendants("wind_kph").FirstOrDefault() + " km/h";
            string humidity = (string)xDocument.Descendants("current").Descendants("humidity").FirstOrDefault() + "%";
            string chanceOfRain = (string)xDocument.Descendants("daily_chance_of_rain").FirstOrDefault() + "%";
            string pressure = (string)xDocument.Descendants("current").Descendants("pressure_mb").FirstOrDefault() + " mbar";
            string vision = (string)xDocument.Descendants("current").Descendants("vis_km").FirstOrDefault() + " km";
            string lastUpdate = (string)xDocument.Descendants("last_updated").FirstOrDefault();
            string typeWeather = (string)xDocument.Descendants("current").Descendants("text").FirstOrDefault();
            string iconUri = (string)xDocument.Descendants("current").Descendants("icon").FirstOrDefault();
            string indexOfUV = (string)xDocument.Descendants("current").Descendants("uv").FirstOrDefault();
            string cityName = (string)xDocument.Descendants("name").FirstOrDefault();
            string countryName = (string)xDocument.Descendants("country").FirstOrDefault();

            object[] objectCurrentDataWeather = new object[]
            {
                currentTemp,
                feelsLike,
                cloud,
                wind_kph,
                humidity,
                chanceOfRain,
                pressure,
                vision,
                lastUpdate,
                typeWeather,
                GetWeatherTypeIcon(iconUri),
                indexOfUV,
                cityName,
                countryName
            };
            return ToByteArray(objectCurrentDataWeather);
        }

        public static byte[] GetBytesForecastWeatherDataByDay(XDocument xDocument)
        {
            DataTable table = new DataTable();
            AddColumnToDataTableForecastByDay(table);
            foreach (var npc in xDocument.Descendants("forecastday"))
            {
                table.Rows.Add(new object[]
                {
                    (string)npc.Descendants("date").FirstOrDefault(),
                    (string)npc.Descendants("maxtemp_c").FirstOrDefault() + "°C",
                    (string)npc.Descendants("mintemp_c").FirstOrDefault() + "°C",
                    (string)npc.Descendants("daily_chance_of_rain").FirstOrDefault() + "%",
                    (string)npc.Descendants("maxwind_kph").FirstOrDefault() + " km/h",
                    (string)npc.Descendants("avgvis_km").FirstOrDefault() + " km",
                    (string)npc.Descendants("avghumidity").FirstOrDefault() + "%",
                    (string)npc.Descendants("text").FirstOrDefault(),
                    GetBytesWeatherIcon((string)npc.Descendants("icon").FirstOrDefault()),
                });
            }
            return ToByteArray(table);
        }

        public static byte[] GetBytesForecastWeatherDataByHour(XDocument xDocument, int dayFromTimeGetData)
        {
            DataTable table = new DataTable();
            int i = 0;
            AddColumnToDataTabeForecastByHour(table);
            foreach (XElement xElement in xDocument.Descendants("forecastday"))
            {
                if (i != dayFromTimeGetData)
                {
                    i++;
                    continue;
                }
                foreach (var xElment2 in xElement.Descendants("hour"))
                {
                    table.Rows.Add(new object[]
                    {
                        ((string)xElment2.Descendants("time").FirstOrDefault()).Split(' ')[1],
                        (string)xElment2.Descendants("temp_c").FirstOrDefault() + "°C",
                        (string)xElment2.Descendants("chance_of_rain").FirstOrDefault() + "%",
                        (string)xElment2.Descendants("wind_kph").FirstOrDefault() + " km/h",
                        (string)xElment2.Descendants("vis_km").FirstOrDefault() + " km",
                        (string)xElment2.Descendants("humidity").FirstOrDefault() + "%",
                        (string)xElment2.Descendants("text").FirstOrDefault(),
                        GetBytesWeatherIcon((string)xElment2.Descendants("icon").FirstOrDefault()),
                    });
                }
                break;
            }
            return ToByteArray(table);
        }

        private static void AddColumnToDataTableForecastByDay(DataTable dataTable)
        {
            dataTable.Columns.Add("Ngày", typeof(string));
            dataTable.Columns.Add("Nhiệt độ cao nhất", typeof(string));
            dataTable.Columns.Add("Nhiệt độ thấp nhất", typeof(string));
            dataTable.Columns.Add("Tỉ lệ mưa", typeof(string));
            dataTable.Columns.Add("Tốc độ gió tối đa", typeof(string));
            dataTable.Columns.Add("Tầm nhìn xa");
            dataTable.Columns.Add("Độ ẩm", typeof(string));
            dataTable.Columns.Add("Thời tiết", typeof(string));
            dataTable.Columns.Add("Biểu tượng", typeof(byte[]));
        }

        private static void AddColumnToDataTabeForecastByHour(DataTable dataTable)
        {
            dataTable.Columns.Add("Thời gian", typeof(string));
            dataTable.Columns.Add("Nhiệt độ", typeof(string));
            dataTable.Columns.Add("Tỉ lệ mưa", typeof(string));
            dataTable.Columns.Add("Tốc độ gió", typeof(string));
            dataTable.Columns.Add("Tầm nhìn xa");
            dataTable.Columns.Add("Độ ẩm", typeof(string));
            dataTable.Columns.Add("Thời tiết", typeof(string));
            dataTable.Columns.Add("Biểu tượng", typeof(byte[]));
        }

        private static Bitmap GetWeatherTypeIcon(string iconUri)
        {
            byte[] data = GetBytesWeatherIcon(iconUri);
            MemoryStream memoryStream = new MemoryStream(data);
            return new Bitmap(memoryStream);
        }

        private static byte[] GetBytesWeatherIcon(string iconUri)
        {
            if (iconUri == "" || iconUri == null)
            {
                return null;
            }

            string[] temp = iconUri.Split('/');
            string fileName = $"{temp[temp.Length - 2]}_{temp[temp.Length - 1]}";
            string filePath = directoryPath + fileName;
            if (File.Exists(filePath))
            {
                return GetWeatherDataFromFile(filePath);
            }

            using (WebClient webClient = new WebClient())
            {
                byte[] image = webClient.DownloadData($"http:{iconUri}");
                WriteImageToFile(image, filePath);
                return image;
            }
        }

        private static byte[] GetWeatherDataFromFile(string filePath)
        {
            return File.ReadAllBytes(filePath);
        }

        private static void WriteImageToFile(byte[] data, string filePath)
        {
            string directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            File.WriteAllBytes(filePath, data);
        }
    }
}
