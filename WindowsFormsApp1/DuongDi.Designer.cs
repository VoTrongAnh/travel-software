namespace WindowsFormsApp1
{
    partial class DuongDi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DuongDi));
            this.panel3 = new System.Windows.Forms.Panel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.gmap_DuongDi = new GMap.NET.WindowsForms.GMapControl();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.panel3.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(230)))), ((int)(((byte)(243)))));
            this.panel3.Controls.Add(this.guna2HtmlLabel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 49);
            this.panel3.TabIndex = 87;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(310, 3);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(211, 43);
            this.guna2HtmlLabel1.TabIndex = 86;
            this.guna2HtmlLabel1.Text = "Xem Đường Đi";
            this.guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.gmap_DuongDi);
            this.guna2Panel1.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 101);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(800, 349);
            this.guna2Panel1.TabIndex = 88;
            // 
            // gmap_DuongDi
            // 
            this.gmap_DuongDi.Bearing = 0F;
            this.gmap_DuongDi.CanDragMap = true;
            this.gmap_DuongDi.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap_DuongDi.GrayScaleMode = false;
            this.gmap_DuongDi.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap_DuongDi.LevelsKeepInMemory = 5;
            this.gmap_DuongDi.Location = new System.Drawing.Point(0, 3);
            this.gmap_DuongDi.MarkersEnabled = true;
            this.gmap_DuongDi.MaxZoom = 2;
            this.gmap_DuongDi.MinZoom = 2;
            this.gmap_DuongDi.MouseWheelZoomEnabled = true;
            this.gmap_DuongDi.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap_DuongDi.Name = "gmap_DuongDi";
            this.gmap_DuongDi.NegativeMode = false;
            this.gmap_DuongDi.PolygonsEnabled = true;
            this.gmap_DuongDi.RetryLoadTile = 0;
            this.gmap_DuongDi.RoutesEnabled = true;
            this.gmap_DuongDi.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap_DuongDi.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap_DuongDi.ShowTileGridLines = false;
            this.gmap_DuongDi.Size = new System.Drawing.Size(800, 346);
            this.gmap_DuongDi.TabIndex = 1;
            this.gmap_DuongDi.Zoom = 0D;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(0, 0);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(800, 349);
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // guna2Button2
            // 
            this.guna2Button2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2Button2.BorderRadius = 7;
            this.guna2Button2.BorderThickness = 2;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.SystemColors.ControlLightLight;
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2Button2.Location = new System.Drawing.Point(12, 51);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(146, 44);
            this.guna2Button2.TabIndex = 90;
            this.guna2Button2.Text = "Lấy vị trí";
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2Button1.BorderRadius = 7;
            this.guna2Button1.BorderThickness = 2;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.SystemColors.ControlLightLight;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2Button1.Location = new System.Drawing.Point(642, 51);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(146, 44);
            this.guna2Button1.TabIndex = 91;
            this.guna2Button1.Text = "Tìm Đường Đi";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // DuongDi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DuongDi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đường Đi";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private GMap.NET.WindowsForms.GMapControl gmap_DuongDi;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}