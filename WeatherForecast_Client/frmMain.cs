using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace WeatherForecast_Client
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        #region Methods

        private byte[] GetWeatherData(int numberOfBytes, string cityName, string type, int day = -1)
        {
            string ip = "127.0.0.1";
            int port = 13000;
            try
            {
                TcpClient tcpClient = new TcpClient(ip, port);
                //Tên vị trí + loại dự báo + Ngày dự báo
                byte[] byteSend = Encoding.ASCII.GetBytes(cityName + "|" + type +
                    (day == -1 ? String.Empty : "|" + day.ToString()));
                NetworkStream networkStream = tcpClient.GetStream();
                //Gửi dữ liệu lên server
                networkStream.Write(byteSend, 0, byteSend.Length);

                byte[] responseData = new byte[numberOfBytes];
                //Nhận dữ liệu từ server
                int demNhan = networkStream.Read(responseData, 0, responseData.Length);

                tcpClient.Close();
                tcpClient.Dispose();
                return responseData.Take(demNhan).ToArray();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("No connection"))
                {
                    MessageBox.Show("Không thể kết nối đến máy chủ!" +
                        "\nVui lòng kiểm tra lại!", "Thông báo");
                    return null;
                }
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        private void DisplayLunarInfo()
        {
            DateTime now = DateTime.Now;
            int solarDay = now.Day;
            int solarMonth = now.Month;
            int solarYear = now.Year;

            Lunar lunar = new Lunar();
            lblDayOfWeek.Text = lunar.GetThu();
            lblSolarDate.Text = String.Format("{0} - {1} - {2}",
                solarDay.ToString().PadLeft(2, '0'), 
                solarMonth.ToString().PadLeft(2, '0'), 
                solarYear);

            int[] tempLunarDate = lunar.ConvertSolar2Lunar(solarDay, solarMonth, solarYear);
            int lunarDay = tempLunarDate[0];
            int lunarMonth = tempLunarDate[1];
            int lunarYear = tempLunarDate[2];

            lblLunarDate.Text = String.Format("{0} - {1} - {2}",
                lunarDay.ToString().PadLeft(2, '0'), 
                lunarMonth.ToString().PadLeft(2, '0'), 
                lunarYear);
            lblLunarDayInfo.Text = "Ngày " + lunar.GetCanChiOfDay(solarDay, solarMonth, solarYear);
            lblLunarMonthInfo.Text = "Tháng " + lunar.GetCanChiOfMoth(lunarMonth, lunarYear);
            lblLunarYearInfo.Text = "Năm " + lunar.GetCanChiOfYear(lunarYear);
        }

        private void DisplayCurrentWeather(string location)
        {
            byte[] data = GetWeatherData(numberOfBytes: 3000, location, "Current");
            
            if (data == null)
            {
                return;
            }
            else if (data.Length == 1)
            {
                MessageBox.Show("Máy chủ đang gặp sự cố!\nXin vui lòng thử lại sau!", "Thông báo");
                return;
            }

            object[] objectCurrentDataWether = 
                WeatherForecastClientHelper.FromByteArray<object[]>(data);
            lblCurrentTemp.Text = objectCurrentDataWether[0].ToString();
            lblFeelsLikeTemp.Text = objectCurrentDataWether[1].ToString();
            lblCLoud.Text = objectCurrentDataWether[2].ToString();
            lblWindSpeed_kph.Text = objectCurrentDataWether[3].ToString();
            lblHumidity.Text = objectCurrentDataWether[4].ToString();
            lblPressure.Text = objectCurrentDataWether[5].ToString();
            lblPressure.Text = objectCurrentDataWether[6].ToString();
            lblVision.Text = objectCurrentDataWether[7].ToString();
            lblLastUpdated.Text = objectCurrentDataWether[8].ToString();
            lblTypeWeather.Text = objectCurrentDataWether[9].ToString();
            Bitmap bitmap = (Bitmap)objectCurrentDataWether[10];
            lblUV.Text = objectCurrentDataWether[11].ToString();

            lblUV.ForeColor = GetColorOfLableUV(lblUV.Text);

            pbTypeWeather.BackgroundImage = bitmap;
            pbTypeWeather.BackgroundImageLayout = ImageLayout.Stretch;

            lblCity.Text = objectCurrentDataWether[12].ToString();
            lblCountry.Text = objectCurrentDataWether[13].ToString();
        }

        private void DisplayForeCastWeather(string location)
        {
            byte[] data = GetWeatherData(numberOfBytes: 17000, location, "ForecastByDay");

            if (data == null)
            {
                return;
            }
            else if (data.Length == 1)
            {
                MessageBox.Show("Máy chủ đang gặp sự cố!\nXin vui lòng thử lại sau!", "Thông báo");
                return;
            }

            DataTable dataTable = WeatherForecastClientHelper.FromByteArray<DataTable>(data);

            //Get list data icon weather
            List<byte[]> iconWeather = new List<byte[]>();
            foreach (DataRow row in dataTable.Rows)
            {
                iconWeather.Add(row.Field<byte[]>("Biểu tượng"));
            }

            dataTable.Columns.Remove("Biểu tượng");
            dataTable.Columns.Add("Biểu tượng", typeof(Bitmap));
            for (int i = 0; i < iconWeather.Count; i++)
            {
                dataTable.Rows[i]["Biểu tượng"] = 
                    WeatherForecastClientHelper.GetWeatherIconFromBytes(iconWeather[i]);
            }
            dgvWeather.DataSource = dataTable;
            FormatDataGridView();
        }

        private Color GetColorOfLableUV(string uv)
        {
            float temp = float.Parse(uv);
            if (temp < 3)
            {
                return Color.LimeGreen;
            }
            if (temp < 6)
            {
                return Color.Yellow;
            }
            if (temp < 8)
            {
                return Color.Orange;
            }
            if (temp < 11)
            {
                return Color.Red;
            }
            return Color.Purple;
        }

        private void FormatDataGridView()
        {
            dgvWeather.AllowUserToAddRows = false;
            dgvWeather.Columns[0].Width = 80;
            dgvWeather.Columns[1].Width = 70;
            dgvWeather.Columns[2].Width = 70;
            dgvWeather.Columns[3].Width = 65;
            dgvWeather.Columns[4].Width = 85;
            dgvWeather.Columns[5].Width = 73;
            dgvWeather.Columns[6].Width = 60;
            dgvWeather.Columns[7].Width = 129;
        }

        private void LoadForm()
        {
            cbbCityName.DataSource = WeatherForecastClientHelper.SixtyThreeCityInVietNam;
        }

        private string GetDangerousInfoOfUV(float uv)
        {
            if (uv < 3)
            {
                return WeatherForecastClientHelper.DangerousInfoOfUV[1];
            }
            if (uv < 6)
            {
                return WeatherForecastClientHelper.DangerousInfoOfUV[2];
            }
            if (uv < 8)
            {
                return WeatherForecastClientHelper.DangerousInfoOfUV[3];
            }
            if (uv < 11)
            {
                return WeatherForecastClientHelper.DangerousInfoOfUV[4];
            }
            return WeatherForecastClientHelper.DangerousInfoOfUV[5];
        }

        #endregion

        //---------------------------------------------------------------------------------------------

        #region Events
        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void btnGetWeatherData_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            if (cbbCityName.SelectedIndex == -1)
            {
                MessageBox.Show("Địa điểm không hợp lệ!\nVui lòng kiểm tra lại!", "Thông báo");
                return;
            }
            DisplayLunarInfo();
            string location = WeatherForecastClientHelper.GetCityNameRemovedSign(
                cbbCityName.SelectedItem.ToString());
            DisplayCurrentWeather(location);
            DisplayForeCastWeather(location);
            this.Cursor = Cursors.Arrow;
        }

        private void lblUV_MouseHover(object sender, EventArgs e)
        {
            float temp = float.Parse((sender as Label).Text);
            MessageBox.Show(GetDangerousInfoOfUV(temp), "Thông tin - Tia UV");
        }

        private void dgvWeather_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            Cursor = Cursors.AppStarting;
            byte[] data = GetWeatherData(numberOfBytes: 1024 * 110, 
                lblCity.Text, type: "ForecastByHour", e.RowIndex);
            object[] obj = new object[]
            {
                DateTime.Parse(dgvWeather.Rows[e.RowIndex].Cells[0].Value.ToString()),
                lblCity.Text,
            };
            using (var form = new frmWeatherForeCastEveryHour(data, obj))
            {
                form.ShowDialog();
            }
            Cursor = Cursors.Arrow;
        }

        #endregion
    }
}
