namespace WindowsFormsApp1
{
    partial class UserControl_ThongKe
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.guna2Button7 = new Guna.UI2.WinForms.Guna2Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Button7
            // 
            this.guna2Button7.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2Button7.BorderRadius = 7;
            this.guna2Button7.BorderThickness = 2;
            this.guna2Button7.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button7.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button7.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button7.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button7.FillColor = System.Drawing.SystemColors.ControlLightLight;
            this.guna2Button7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2Button7.Location = new System.Drawing.Point(914, 16);
            this.guna2Button7.Name = "guna2Button7";
            this.guna2Button7.Size = new System.Drawing.Size(123, 47);
            this.guna2Button7.TabIndex = 115;
            this.guna2Button7.Text = "Xem";
            this.guna2Button7.Click += new System.EventHandler(this.guna2Button7_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(375, 55);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker2.TabIndex = 104;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Hà Giang",
            "Cao Bằng",
            "Bắc Kạn",
            "Tuyên Quang",
            "Lào Cai",
            "Điện Biên",
            "Lai Châu",
            "Sơn La",
            "Yên Bái",
            "Hà Nội",
            "Thái Nguyên",
            "Lạng Sơn",
            "Quảng Ninh",
            "Bắc Ninh",
            "Hải Dương",
            "Hưng Yên",
            "Hải Phòng",
            "Nam Định",
            "Ninh Bình",
            "Thái Bình",
            "Hà Nam",
            "Vĩnh Phúc",
            "Phú Thọ",
            "Tuyên Quang",
            "Nghệ An",
            "Hà Tĩnh",
            "Quảng Bình",
            "Quảng Trị",
            "Thừa Thiên Huế",
            "Đà Nẵng",
            "Quảng Nam",
            "Quảng Ngãi",
            "Bình Định",
            "Phú Yên",
            "Khánh Hòa",
            "Ninh Thuận",
            "Bình Thuận",
            "Hồ Chí Minh",
            "Đồng Nai",
            "Bà Rịa - Vũng Tàu",
            "Bình Dương",
            "Bình Phước",
            "Tây Ninh",
            "Long An",
            "Tiền Giang",
            "Bến Tre",
            "Trà Vinh",
            "Vĩnh Long",
            "Đồng Tháp",
            "An Giang",
            "Kiên Giang",
            "Hậu Giang",
            "Sóc Trăng",
            "Bạc Liêu",
            "Cà Mau",
            "Tây Nguyên",
            "Đắk Lắk",
            "Đắk Nông",
            "Gia Lai",
            "Kon Tum",
            "Lâm Đồng",
            "Hải Phòng",
            "Đà Nẵng",
            "Cần Thơ"});
            this.comboBox2.Location = new System.Drawing.Point(648, 19);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(171, 24);
            this.comboBox2.TabIndex = 102;
            this.comboBox2.Text = "Hà Nội";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(546, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 16);
            this.label7.TabIndex = 101;
            this.label7.Text = "Chọn địa điểm:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Default;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(528, 24);
            this.label6.TabIndex = 100;
            this.label6.Text = "Thống kê số lượng du khách ghé thăm địa điểm cụ thể";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(603, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 97;
            this.label3.Text = "Theo:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Tháng",
            "Quý"});
            this.comboBox1.Location = new System.Drawing.Point(651, 55);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 96;
            this.comboBox1.Text = "Tháng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(302, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 95;
            this.label2.Text = "Đến ngày:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 94;
            this.label1.Text = "Từ ngày:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(78, 55);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 93;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(44, 104);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Khách du lịch";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(993, 507);
            this.chart1.TabIndex = 116;
            this.chart1.Text = "chart1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(124, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 117;
            this.label4.Text = "(người)";
            // 
            // UserControl_ThongKe
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.guna2Button7);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "UserControl_ThongKe";
            this.Size = new System.Drawing.Size(1086, 649);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button guna2Button7;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label4;
    }
}
