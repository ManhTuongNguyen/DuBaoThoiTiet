using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace WeatherForecast_Server
{
    class Program
    {
        static readonly string directory = System.IO.Directory.GetCurrentDirectory() + @"\";
        static bool isExitProgram = false;
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            int port = 13000;
        StartServer:
            Console.WriteLine("Máy chủ đang bắt đầu hoạt động...");
            try
            {
                while (true)
                {
                    TcpListener tcpListener = new TcpListener(IPAddress.Any, port);
                    tcpListener.Start();
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    Console.WriteLine("Đã kết nối với một máy khách!");

                    NetworkStream networkStream = tcpClient.GetStream();
                    byte[] recieveByte = new byte[1024];
                    //Nhận dữ liệu gửi lên từ Client
                    int demNhan = networkStream.Read(recieveByte, 0, recieveByte.Length);
                    Console.Write("Đã nhận: ");
                    string dataRecieved = Encoding.ASCII.GetString(recieveByte, 0, demNhan);
                    string[] listStringRecieved = dataRecieved.Split('|');
                    string location = listStringRecieved[0];
                    Console.WriteLine(dataRecieved);

                    //Lấy thông tin thời tiết và gửi về cho máy khách
                    byte[] responseData = null;
                    try
                    {
                        if (listStringRecieved[1].Equals("Current"))
                        {
                            //Get object current weather converted to byte array
                            responseData = WeatherForecastServerHelper.GetCurrentDataWeather(location);
                            goto SendDataToClient;
                        }
                        if (listStringRecieved[1].Equals("ForecastByDay"))
                        {
                            //Get table forecast weather converted to byte array
                            responseData = WeatherForecastServerHelper.GetForecastDataWeatherByDay(location);
                            goto SendDataToClient;
                        }
                        if (listStringRecieved[1].Equals("ForecastByHour"))
                        {
                            //Get table forecast weather converted to byte array
                            responseData = WeatherForecastServerHelper.
                                GetForecastDataWeatherByHour(location, int.Parse(listStringRecieved[2]));
                        }
                    }
                    catch (WebException ex)
                    {
                        if (ex.Message.Contains("The remote server returned an error: (401) Unauthorized."))
                        {
                            WriteLogToText(ex);
                            // Key không chính xác
                            isExitProgram = true;
                        }
                    }
                SendDataToClient:
                    if (isExitProgram)
                    {
                        networkStream.Write(new byte[1], 0, 1);

                        tcpClient.Close();
                        tcpClient.Dispose();
                        tcpListener.Stop();
                        System.Environment.Exit(0);
                    }
                    networkStream.Write(responseData, 0, responseData.Length);
                    Console.WriteLine($"Đã gửi thành công {responseData.Length} byte dữ liệu về máy khách!");
                    responseData = null;

                    tcpClient.Close();
                    tcpClient.Dispose();
                    tcpListener.Stop();

                    Console.WriteLine("\n");
                }
            }
            catch (Exception ex)
            {
                WriteLogToText(ex);
                Console.WriteLine("Có lỗi đã xảy ra:");
                Console.WriteLine(ex.Message);
                ex.ToString();
                Console.WriteLine("Hãy kiểm tra log file và sửa lỗi!");
                for (int i = 5; i > 0; i--)
                {
                    Console.WriteLine($"Máy chủ sẽ tự khởi động lại sau {i} giây!");
                    Thread.Sleep(1000);
                    if (i > 1)
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                    }
                }
                goto StartServer;
            }
        }

        private static void WriteLogToText(Exception ex)
        {
            DateTime time = DateTime.Now;
            string fileName = $"LOG_{time.Year}{time.Month.ToString().PadLeft(2, '0')}" +
                $"{time.Day.ToString().PadLeft(2, '0')}_";
            fileName += String.Format($"{time.Hour.ToString().PadLeft(2, '0')}");
            fileName += String.Format($"{time.Minute.ToString().PadLeft(2, '0')}");
            fileName += String.Format($"{time.Second.ToString().PadLeft(2, '0')}");
            fileName += ".txt";
            string filePath = directory + fileName;
            File.WriteAllText(filePath, ex.ToString());
        }
    }
}
