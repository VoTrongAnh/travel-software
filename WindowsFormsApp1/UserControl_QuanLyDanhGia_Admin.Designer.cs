namespace WindowsFormsApp1
{
    partial class UserControl_QuanLyDanhGia_Admin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_DuyetDanhGia = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2Button7 = new Guna.UI2.WinForms.Guna2Button();
            this.btnDuyet = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            this.cbbDiaDiem = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoc = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DuyetDanhGia)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(33, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 98;
            this.label1.Text = "Thời gian";
            // 
            // dgv_DuyetDanhGia
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.dgv_DuyetDanhGia.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_DuyetDanhGia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgv_DuyetDanhGia.ColumnHeadersHeight = 18;
            this.dgv_DuyetDanhGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_DuyetDanhGia.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgv_DuyetDanhGia.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_DuyetDanhGia.Location = new System.Drawing.Point(38, 143);
            this.dgv_DuyetDanhGia.Name = "dgv_DuyetDanhGia";
            this.dgv_DuyetDanhGia.RowHeadersVisible = false;
            this.dgv_DuyetDanhGia.RowHeadersWidth = 51;
            this.dgv_DuyetDanhGia.RowTemplate.Height = 24;
            this.dgv_DuyetDanhGia.Size = new System.Drawing.Size(1004, 373);
            this.dgv_DuyetDanhGia.TabIndex = 94;
            this.dgv_DuyetDanhGia.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_DuyetDanhGia.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgv_DuyetDanhGia.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgv_DuyetDanhGia.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv_DuyetDanhGia.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgv_DuyetDanhGia.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgv_DuyetDanhGia.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_DuyetDanhGia.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgv_DuyetDanhGia.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_DuyetDanhGia.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgv_DuyetDanhGia.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_DuyetDanhGia.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_DuyetDanhGia.ThemeStyle.HeaderStyle.Height = 18;
            this.dgv_DuyetDanhGia.ThemeStyle.ReadOnly = false;
            this.dgv_DuyetDanhGia.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_DuyetDanhGia.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_DuyetDanhGia.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgv_DuyetDanhGia.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv_DuyetDanhGia.ThemeStyle.RowsStyle.Height = 24;
            this.dgv_DuyetDanhGia.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_DuyetDanhGia.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(33, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(203, 25);
            this.label6.TabIndex = 91;
            this.label6.Text = "Đánh giá của khách";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(108, 58);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker2.TabIndex = 90;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 89;
            this.label5.Text = "Đến ngày:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(108, 82);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 88;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 87;
            this.label4.Text = "Từ ngày:";
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
            this.guna2Button7.Location = new System.Drawing.Point(38, 522);
            this.guna2Button7.Name = "guna2Button7";
            this.guna2Button7.Size = new System.Drawing.Size(258, 45);
            this.guna2Button7.TabIndex = 116;
            this.guna2Button7.Text = "Xem hình";
            this.guna2Button7.Click += new System.EventHandler(this.guna2Button7_Click);
            // 
            // btnDuyet
            // 
            this.btnDuyet.BackColor = System.Drawing.Color.Transparent;
            this.btnDuyet.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnDuyet.BorderRadius = 7;
            this.btnDuyet.BorderThickness = 2;
            this.btnDuyet.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDuyet.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDuyet.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDuyet.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDuyet.FillColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDuyet.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDuyet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnDuyet.Location = new System.Drawing.Point(784, 522);
            this.btnDuyet.Name = "btnDuyet";
            this.btnDuyet.Size = new System.Drawing.Size(258, 45);
            this.btnDuyet.TabIndex = 117;
            this.btnDuyet.Text = "Duyệt";
            this.btnDuyet.Click += new System.EventHandler(this.btnDuyet_Click);
            // 
            // guna2Button4
            // 
            this.guna2Button4.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button4.BorderColor = System.Drawing.Color.IndianRed;
            this.guna2Button4.BorderRadius = 7;
            this.guna2Button4.BorderThickness = 2;
            this.guna2Button4.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button4.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button4.FillColor = System.Drawing.SystemColors.ControlLightLight;
            this.guna2Button4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button4.ForeColor = System.Drawing.Color.IndianRed;
            this.guna2Button4.Location = new System.Drawing.Point(784, 573);
            this.guna2Button4.Name = "guna2Button4";
            this.guna2Button4.Size = new System.Drawing.Size(258, 45);
            this.guna2Button4.TabIndex = 118;
            this.guna2Button4.Text = "Xóa";
            this.guna2Button4.Click += new System.EventHandler(this.guna2Button4_Click);
            // 
            // cbbDiaDiem
            // 
            this.cbbDiaDiem.FormattingEnabled = true;
            this.cbbDiaDiem.Location = new System.Drawing.Point(407, 55);
            this.cbbDiaDiem.Name = "cbbDiaDiem";
            this.cbbDiaDiem.Size = new System.Drawing.Size(192, 24);
            this.cbbDiaDiem.TabIndex = 134;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(402, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 25);
            this.label2.TabIndex = 133;
            this.label2.Text = "Địa điểm";
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.Color.Transparent;
            this.btnLoc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnLoc.BorderRadius = 7;
            this.btnLoc.BorderThickness = 2;
            this.btnLoc.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLoc.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLoc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLoc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLoc.FillColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLoc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnLoc.Location = new System.Drawing.Point(679, 55);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(220, 35);
            this.btnLoc.TabIndex = 135;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // UserControl_QuanLyDanhGia_Admin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.cbbDiaDiem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.guna2Button4);
            this.Controls.Add(this.btnDuyet);
            this.Controls.Add(this.guna2Button7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_DuyetDanhGia);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label4);
            this.Name = "UserControl_QuanLyDanhGia_Admin";
            this.Size = new System.Drawing.Size(1086, 649);
            this.Load += new System.EventHandler(this.UserControl_QuanLyDanhGia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DuyetDanhGia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_DuyetDanhGia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Button guna2Button7;
        private Guna.UI2.WinForms.Guna2Button btnDuyet;
        private Guna.UI2.WinForms.Guna2Button guna2Button4;
        private System.Windows.Forms.ComboBox cbbDiaDiem;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnLoc;
    }
}
