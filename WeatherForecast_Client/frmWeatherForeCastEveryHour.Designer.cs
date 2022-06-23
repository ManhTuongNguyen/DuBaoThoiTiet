
namespace WeatherForecast_Client
{
    partial class frmWeatherForeCastEveryHour
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
            this.dgvWeatherData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWeatherData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvWeatherData
            // 
            this.dgvWeatherData.AllowUserToAddRows = false;
            this.dgvWeatherData.AllowUserToDeleteRows = false;
            this.dgvWeatherData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWeatherData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWeatherData.Location = new System.Drawing.Point(0, 0);
            this.dgvWeatherData.Name = "dgvWeatherData";
            this.dgvWeatherData.RowHeadersVisible = false;
            this.dgvWeatherData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvWeatherData.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvWeatherData.RowTemplate.Height = 56;
            this.dgvWeatherData.RowTemplate.ReadOnly = true;
            this.dgvWeatherData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWeatherData.Size = new System.Drawing.Size(1085, 462);
            this.dgvWeatherData.TabIndex = 0;
            // 
            // frmWeatherForeCastEveryHour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 462);
            this.Controls.Add(this.dgvWeatherData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1103, 509);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1103, 509);
            this.Name = "frmWeatherForeCastEveryHour";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmWeatherForeCastEveryHour";
            ((System.ComponentModel.ISupportInitialize)(this.dgvWeatherData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvWeatherData;
    }
}