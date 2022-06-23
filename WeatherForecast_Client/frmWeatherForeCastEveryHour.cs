using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WeatherForecast_Client
{
    public partial class frmWeatherForeCastEveryHour : Form
    {
        public frmWeatherForeCastEveryHour(byte[] data, object[] obj)
        {
            InitializeComponent();
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
            DateTime date = DateTime.Parse(obj[0].ToString());
            this.Text = $"Dự báo thời tiết tại {obj[1]} ngày {date.Day} tháng {date.Month} năm {date.Year}";
            dgvWeatherData.DataSource = dataTable;
            FormatDataGridView();
        }

        private void FormatDataGridView()
        {
            dgvWeatherData.AllowUserToResizeRows = false;
            dgvWeatherData.MultiSelect = false;
            dgvWeatherData.Columns[0].Width = 75;
            dgvWeatherData.Columns[1].Width = 80;
            dgvWeatherData.Columns[2].Width = 80;
            dgvWeatherData.Columns[3].Width = 90;
            dgvWeatherData.Columns[4].Width = 90;
            dgvWeatherData.Columns[5].Width = 80;
            dgvWeatherData.Columns[6].Width = 170;
            dgvWeatherData.Columns[7].Width = 129;
            //((DataGridViewImageColumn)dgvWeatherData.Columns[7]).ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
    }
}
