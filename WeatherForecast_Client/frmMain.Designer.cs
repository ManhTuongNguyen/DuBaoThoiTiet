
namespace WeatherForecast_Client
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbbCityName = new System.Windows.Forms.ComboBox();
            this.lblCurrentTemp = new System.Windows.Forms.Label();
            this.lblFeelsLikeTemp = new System.Windows.Forms.Label();
            this.lblCLoud = new System.Windows.Forms.Label();
            this.lblWindSpeed_kph = new System.Windows.Forms.Label();
            this.lblHumidity = new System.Windows.Forms.Label();
            this.pbTypeWeather = new System.Windows.Forms.PictureBox();
            this.lblTypeWeather = new System.Windows.Forms.Label();
            this.dgvWeather = new System.Windows.Forms.DataGridView();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblPressure = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblVision = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnRegion = new System.Windows.Forms.Panel();
            this.lblCountry = new System.Windows.Forms.Label();
            this.btnGetWeatherData = new System.Windows.Forms.Button();
            this.groupBoxCurrentWeather = new System.Windows.Forms.GroupBox();
            this.lblUV = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblLastUpdated = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblWeatherForecast = new System.Windows.Forms.Label();
            this.pnDateInfo = new System.Windows.Forms.Panel();
            this.lblLunarYearInfo = new System.Windows.Forms.Label();
            this.lblLunarMonthInfo = new System.Windows.Forms.Label();
            this.lblLunarDayInfo = new System.Windows.Forms.Label();
            this.lblLunarDate = new System.Windows.Forms.Label();
            this.lblSolarDate = new System.Windows.Forms.Label();
            this.lblDayOfWeek = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbTypeWeather)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWeather)).BeginInit();
            this.panel2.SuspendLayout();
            this.pnRegion.SuspendLayout();
            this.groupBoxCurrentWeather.SuspendLayout();
            this.pnDateInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(8, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tỉnh / Thành phố";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(8, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tốc độ gió";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(8, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nhiệt độ hiện tại";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(8, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Độ ẩm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Silver;
            this.label6.Location = new System.Drawing.Point(8, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Độ bao phủ của mây";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Silver;
            this.label7.Location = new System.Drawing.Point(8, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Cảm giác như";
            // 
            // cbbCityName
            // 
            this.cbbCityName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbCityName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbCityName.BackColor = System.Drawing.SystemColors.Window;
            this.cbbCityName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCityName.ForeColor = System.Drawing.Color.SlateBlue;
            this.cbbCityName.FormattingEnabled = true;
            this.cbbCityName.Location = new System.Drawing.Point(201, 41);
            this.cbbCityName.Name = "cbbCityName";
            this.cbbCityName.Size = new System.Drawing.Size(245, 26);
            this.cbbCityName.TabIndex = 7;
            // 
            // lblCurrentTemp
            // 
            this.lblCurrentTemp.AutoSize = true;
            this.lblCurrentTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentTemp.ForeColor = System.Drawing.Color.LightGreen;
            this.lblCurrentTemp.Location = new System.Drawing.Point(209, 78);
            this.lblCurrentTemp.Name = "lblCurrentTemp";
            this.lblCurrentTemp.Size = new System.Drawing.Size(42, 20);
            this.lblCurrentTemp.TabIndex = 8;
            this.lblCurrentTemp.Text = "0 °C";
            // 
            // lblFeelsLikeTemp
            // 
            this.lblFeelsLikeTemp.AutoSize = true;
            this.lblFeelsLikeTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFeelsLikeTemp.ForeColor = System.Drawing.Color.LightGreen;
            this.lblFeelsLikeTemp.Location = new System.Drawing.Point(209, 111);
            this.lblFeelsLikeTemp.Name = "lblFeelsLikeTemp";
            this.lblFeelsLikeTemp.Size = new System.Drawing.Size(42, 20);
            this.lblFeelsLikeTemp.TabIndex = 9;
            this.lblFeelsLikeTemp.Text = "0 °C";
            // 
            // lblCLoud
            // 
            this.lblCLoud.AutoSize = true;
            this.lblCLoud.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCLoud.ForeColor = System.Drawing.Color.LightGreen;
            this.lblCLoud.Location = new System.Drawing.Point(209, 144);
            this.lblCLoud.Name = "lblCLoud";
            this.lblCLoud.Size = new System.Drawing.Size(38, 20);
            this.lblCLoud.TabIndex = 10;
            this.lblCLoud.Text = "0 %";
            // 
            // lblWindSpeed_kph
            // 
            this.lblWindSpeed_kph.AutoSize = true;
            this.lblWindSpeed_kph.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWindSpeed_kph.ForeColor = System.Drawing.Color.LightGreen;
            this.lblWindSpeed_kph.Location = new System.Drawing.Point(209, 207);
            this.lblWindSpeed_kph.Name = "lblWindSpeed_kph";
            this.lblWindSpeed_kph.Size = new System.Drawing.Size(59, 20);
            this.lblWindSpeed_kph.TabIndex = 11;
            this.lblWindSpeed_kph.Text = "0 km/h";
            // 
            // lblHumidity
            // 
            this.lblHumidity.AutoSize = true;
            this.lblHumidity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHumidity.ForeColor = System.Drawing.Color.LightGreen;
            this.lblHumidity.Location = new System.Drawing.Point(209, 239);
            this.lblHumidity.Name = "lblHumidity";
            this.lblHumidity.Size = new System.Drawing.Size(38, 20);
            this.lblHumidity.TabIndex = 12;
            this.lblHumidity.Text = "0 %";
            // 
            // pbTypeWeather
            // 
            this.pbTypeWeather.Location = new System.Drawing.Point(458, 78);
            this.pbTypeWeather.Name = "pbTypeWeather";
            this.pbTypeWeather.Size = new System.Drawing.Size(186, 149);
            this.pbTypeWeather.TabIndex = 13;
            this.pbTypeWeather.TabStop = false;
            // 
            // lblTypeWeather
            // 
            this.lblTypeWeather.AutoSize = true;
            this.lblTypeWeather.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeWeather.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblTypeWeather.Location = new System.Drawing.Point(488, 55);
            this.lblTypeWeather.Name = "lblTypeWeather";
            this.lblTypeWeather.Size = new System.Drawing.Size(69, 20);
            this.lblTypeWeather.TabIndex = 14;
            this.lblTypeWeather.Text = "Thời tiết";
            // 
            // dgvWeather
            // 
            this.dgvWeather.BackgroundColor = System.Drawing.Color.SkyBlue;
            this.dgvWeather.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWeather.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWeather.Location = new System.Drawing.Point(0, 0);
            this.dgvWeather.Name = "dgvWeather";
            this.dgvWeather.RowHeadersVisible = false;
            this.dgvWeather.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvWeather.RowTemplate.Height = 45;
            this.dgvWeather.RowTemplate.ReadOnly = true;
            this.dgvWeather.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWeather.Size = new System.Drawing.Size(982, 228);
            this.dgvWeather.TabIndex = 16;
            this.dgvWeather.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWeather_CellClick);
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.Location = new System.Drawing.Point(7, 7);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(0, 29);
            this.lblCity.TabIndex = 19;
            // 
            // lblPressure
            // 
            this.lblPressure.AutoSize = true;
            this.lblPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPressure.ForeColor = System.Drawing.Color.LightGreen;
            this.lblPressure.Location = new System.Drawing.Point(209, 270);
            this.lblPressure.Name = "lblPressure";
            this.lblPressure.Size = new System.Drawing.Size(61, 20);
            this.lblPressure.TabIndex = 22;
            this.lblPressure.Text = "0 mbar";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Silver;
            this.label8.Location = new System.Drawing.Point(8, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 20);
            this.label8.TabIndex = 23;
            this.label8.Text = "Tầm nhìn xa";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Silver;
            this.label10.Location = new System.Drawing.Point(8, 268);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 20);
            this.label10.TabIndex = 24;
            this.label10.Text = "Áp suất";
            // 
            // lblVision
            // 
            this.lblVision.AutoSize = true;
            this.lblVision.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVision.ForeColor = System.Drawing.Color.LightGreen;
            this.lblVision.Location = new System.Drawing.Point(209, 177);
            this.lblVision.Name = "lblVision";
            this.lblVision.Size = new System.Drawing.Size(40, 20);
            this.lblVision.TabIndex = 25;
            this.lblVision.Text = "0km";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvWeather);
            this.panel2.Location = new System.Drawing.Point(12, 446);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(982, 228);
            this.panel2.TabIndex = 27;
            // 
            // pnRegion
            // 
            this.pnRegion.BackColor = System.Drawing.Color.Transparent;
            this.pnRegion.Controls.Add(this.lblCountry);
            this.pnRegion.Controls.Add(this.lblCity);
            this.pnRegion.ForeColor = System.Drawing.Color.Gold;
            this.pnRegion.Location = new System.Drawing.Point(684, 12);
            this.pnRegion.Name = "pnRegion";
            this.pnRegion.Size = new System.Drawing.Size(316, 128);
            this.pnRegion.TabIndex = 28;
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountry.Location = new System.Drawing.Point(84, 67);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(200, 55);
            this.lblCountry.TabIndex = 21;
            this.lblCountry.Text = "Vietnam";
            // 
            // btnGetWeatherData
            // 
            this.btnGetWeatherData.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGetWeatherData.Location = new System.Drawing.Point(492, 233);
            this.btnGetWeatherData.Name = "btnGetWeatherData";
            this.btnGetWeatherData.Size = new System.Drawing.Size(118, 42);
            this.btnGetWeatherData.TabIndex = 29;
            this.btnGetWeatherData.Text = "Hiển thị";
            this.btnGetWeatherData.UseVisualStyleBackColor = true;
            this.btnGetWeatherData.Click += new System.EventHandler(this.btnGetWeatherData_Click);
            // 
            // groupBoxCurrentWeather
            // 
            this.groupBoxCurrentWeather.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxCurrentWeather.Controls.Add(this.lblUV);
            this.groupBoxCurrentWeather.Controls.Add(this.btnGetWeatherData);
            this.groupBoxCurrentWeather.Controls.Add(this.label12);
            this.groupBoxCurrentWeather.Controls.Add(this.lblLastUpdated);
            this.groupBoxCurrentWeather.Controls.Add(this.label4);
            this.groupBoxCurrentWeather.Controls.Add(this.lblTypeWeather);
            this.groupBoxCurrentWeather.Controls.Add(this.label1);
            this.groupBoxCurrentWeather.Controls.Add(this.pbTypeWeather);
            this.groupBoxCurrentWeather.Controls.Add(this.lblVision);
            this.groupBoxCurrentWeather.Controls.Add(this.lblHumidity);
            this.groupBoxCurrentWeather.Controls.Add(this.label8);
            this.groupBoxCurrentWeather.Controls.Add(this.label2);
            this.groupBoxCurrentWeather.Controls.Add(this.lblWindSpeed_kph);
            this.groupBoxCurrentWeather.Controls.Add(this.label10);
            this.groupBoxCurrentWeather.Controls.Add(this.lblCLoud);
            this.groupBoxCurrentWeather.Controls.Add(this.label3);
            this.groupBoxCurrentWeather.Controls.Add(this.lblFeelsLikeTemp);
            this.groupBoxCurrentWeather.Controls.Add(this.lblCurrentTemp);
            this.groupBoxCurrentWeather.Controls.Add(this.label5);
            this.groupBoxCurrentWeather.Controls.Add(this.cbbCityName);
            this.groupBoxCurrentWeather.Controls.Add(this.lblPressure);
            this.groupBoxCurrentWeather.Controls.Add(this.label7);
            this.groupBoxCurrentWeather.Controls.Add(this.label6);
            this.groupBoxCurrentWeather.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCurrentWeather.ForeColor = System.Drawing.Color.DarkOrchid;
            this.groupBoxCurrentWeather.Location = new System.Drawing.Point(12, 12);
            this.groupBoxCurrentWeather.Name = "groupBoxCurrentWeather";
            this.groupBoxCurrentWeather.Size = new System.Drawing.Size(666, 356);
            this.groupBoxCurrentWeather.TabIndex = 30;
            this.groupBoxCurrentWeather.TabStop = false;
            this.groupBoxCurrentWeather.Text = "Thời tiết hiện tại";
            // 
            // lblUV
            // 
            this.lblUV.AutoSize = true;
            this.lblUV.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblUV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUV.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblUV.Location = new System.Drawing.Point(209, 299);
            this.lblUV.Name = "lblUV";
            this.lblUV.Size = new System.Drawing.Size(18, 20);
            this.lblUV.TabIndex = 29;
            this.lblUV.Text = "0";
            this.lblUV.MouseHover += new System.EventHandler(this.lblUV_MouseHover);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Silver;
            this.label12.Location = new System.Drawing.Point(8, 297);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 20);
            this.label12.TabIndex = 28;
            this.label12.Text = "Tia UV";
            // 
            // lblLastUpdated
            // 
            this.lblLastUpdated.AutoSize = true;
            this.lblLastUpdated.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastUpdated.ForeColor = System.Drawing.Color.Orange;
            this.lblLastUpdated.Location = new System.Drawing.Point(500, 324);
            this.lblLastUpdated.Name = "lblLastUpdated";
            this.lblLastUpdated.Size = new System.Drawing.Size(0, 20);
            this.lblLastUpdated.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(364, 324);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 18);
            this.label4.TabIndex = 26;
            this.label4.Text = "Cập nhật lần cuối";
            // 
            // lblWeatherForecast
            // 
            this.lblWeatherForecast.AutoSize = true;
            this.lblWeatherForecast.BackColor = System.Drawing.Color.Transparent;
            this.lblWeatherForecast.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeatherForecast.ForeColor = System.Drawing.Color.Crimson;
            this.lblWeatherForecast.Location = new System.Drawing.Point(12, 392);
            this.lblWeatherForecast.Name = "lblWeatherForecast";
            this.lblWeatherForecast.Size = new System.Drawing.Size(463, 32);
            this.lblWeatherForecast.TabIndex = 31;
            this.lblWeatherForecast.Text = "Dự báo cho những ngày tiếp theo";
            // 
            // pnDateInfo
            // 
            this.pnDateInfo.BackColor = System.Drawing.Color.Transparent;
            this.pnDateInfo.Controls.Add(this.lblLunarYearInfo);
            this.pnDateInfo.Controls.Add(this.lblLunarMonthInfo);
            this.pnDateInfo.Controls.Add(this.lblLunarDayInfo);
            this.pnDateInfo.Controls.Add(this.lblLunarDate);
            this.pnDateInfo.Controls.Add(this.lblSolarDate);
            this.pnDateInfo.Controls.Add(this.lblDayOfWeek);
            this.pnDateInfo.Location = new System.Drawing.Point(685, 172);
            this.pnDateInfo.Name = "pnDateInfo";
            this.pnDateInfo.Size = new System.Drawing.Size(315, 196);
            this.pnDateInfo.TabIndex = 32;
            // 
            // lblLunarYearInfo
            // 
            this.lblLunarYearInfo.AutoSize = true;
            this.lblLunarYearInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLunarYearInfo.ForeColor = System.Drawing.Color.Gold;
            this.lblLunarYearInfo.Location = new System.Drawing.Point(169, 159);
            this.lblLunarYearInfo.Name = "lblLunarYearInfo";
            this.lblLunarYearInfo.Size = new System.Drawing.Size(0, 20);
            this.lblLunarYearInfo.TabIndex = 5;
            // 
            // lblLunarMonthInfo
            // 
            this.lblLunarMonthInfo.AutoSize = true;
            this.lblLunarMonthInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLunarMonthInfo.ForeColor = System.Drawing.Color.Gold;
            this.lblLunarMonthInfo.Location = new System.Drawing.Point(169, 128);
            this.lblLunarMonthInfo.Name = "lblLunarMonthInfo";
            this.lblLunarMonthInfo.Size = new System.Drawing.Size(0, 20);
            this.lblLunarMonthInfo.TabIndex = 4;
            // 
            // lblLunarDayInfo
            // 
            this.lblLunarDayInfo.AutoSize = true;
            this.lblLunarDayInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLunarDayInfo.ForeColor = System.Drawing.Color.Gold;
            this.lblLunarDayInfo.Location = new System.Drawing.Point(169, 98);
            this.lblLunarDayInfo.Name = "lblLunarDayInfo";
            this.lblLunarDayInfo.Size = new System.Drawing.Size(0, 20);
            this.lblLunarDayInfo.TabIndex = 3;
            // 
            // lblLunarDate
            // 
            this.lblLunarDate.AutoSize = true;
            this.lblLunarDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLunarDate.ForeColor = System.Drawing.Color.Orange;
            this.lblLunarDate.Location = new System.Drawing.Point(75, 73);
            this.lblLunarDate.Name = "lblLunarDate";
            this.lblLunarDate.Size = new System.Drawing.Size(0, 20);
            this.lblLunarDate.TabIndex = 2;
            // 
            // lblSolarDate
            // 
            this.lblSolarDate.AutoSize = true;
            this.lblSolarDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSolarDate.ForeColor = System.Drawing.Color.Orange;
            this.lblSolarDate.Location = new System.Drawing.Point(74, 47);
            this.lblSolarDate.Name = "lblSolarDate";
            this.lblSolarDate.Size = new System.Drawing.Size(0, 20);
            this.lblSolarDate.TabIndex = 1;
            // 
            // lblDayOfWeek
            // 
            this.lblDayOfWeek.AutoSize = true;
            this.lblDayOfWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDayOfWeek.ForeColor = System.Drawing.Color.Orange;
            this.lblDayOfWeek.Location = new System.Drawing.Point(8, 15);
            this.lblDayOfWeek.Name = "lblDayOfWeek";
            this.lblDayOfWeek.Size = new System.Drawing.Size(0, 24);
            this.lblDayOfWeek.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnGetWeatherData;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WeatherForecast_Client.Properties.Resources.Background_WeatherForecast;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1006, 679);
            this.Controls.Add(this.pnDateInfo);
            this.Controls.Add(this.lblWeatherForecast);
            this.Controls.Add(this.groupBoxCurrentWeather);
            this.Controls.Add(this.pnRegion);
            this.Controls.Add(this.panel2);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dự báo thời tiết";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTypeWeather)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWeather)).EndInit();
            this.panel2.ResumeLayout(false);
            this.pnRegion.ResumeLayout(false);
            this.pnRegion.PerformLayout();
            this.groupBoxCurrentWeather.ResumeLayout(false);
            this.groupBoxCurrentWeather.PerformLayout();
            this.pnDateInfo.ResumeLayout(false);
            this.pnDateInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbbCityName;
        private System.Windows.Forms.Label lblCurrentTemp;
        private System.Windows.Forms.Label lblFeelsLikeTemp;
        private System.Windows.Forms.Label lblCLoud;
        private System.Windows.Forms.Label lblWindSpeed_kph;
        private System.Windows.Forms.Label lblHumidity;
        private System.Windows.Forms.PictureBox pbTypeWeather;
        private System.Windows.Forms.Label lblTypeWeather;
        private System.Windows.Forms.DataGridView dgvWeather;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblPressure;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblVision;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnRegion;
        private System.Windows.Forms.Button btnGetWeatherData;
        private System.Windows.Forms.GroupBox groupBoxCurrentWeather;
        private System.Windows.Forms.Label lblLastUpdated;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblUV;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblWeatherForecast;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Panel pnDateInfo;
        private System.Windows.Forms.Label lblLunarDayInfo;
        private System.Windows.Forms.Label lblLunarDate;
        private System.Windows.Forms.Label lblSolarDate;
        private System.Windows.Forms.Label lblDayOfWeek;
        private System.Windows.Forms.Label lblLunarYearInfo;
        private System.Windows.Forms.Label lblLunarMonthInfo;
    }
}

