using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        private System.Windows.Forms.PictureBox pictureBox1;
        private LinkLabel linkLabel1;
        private Guna2TextBox passwordTextBox;
        private Guna2TextBox guna2TextBox1;
        private Label label3;
        private Label label2;
        private Label label1;

        //public Login()
        //{
        //    InitializeComponent();
        //}

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.passwordTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.lbl_Message = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.ForeColor = System.Drawing.Color.White;
            this.linkLabel1.LinkColor = System.Drawing.Color.Yellow;
            this.linkLabel1.Location = new System.Drawing.Point(13, 233);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(118, 18);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Quên Mật Khẩu\r\n";
            this.linkLabel1.Click += new System.EventHandler(this.linkLabel1_LinkClicked);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.passwordTextBox.DefaultText = "";
            this.passwordTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.passwordTextBox.Location = new System.Drawing.Point(15, 199);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '\0';
            this.passwordTextBox.PlaceholderText = "Nhập mật khẩu";
            this.passwordTextBox.SelectedText = "";
            this.passwordTextBox.Size = new System.Drawing.Size(309, 30);
            this.passwordTextBox.TabIndex = 2;
            // 
            // guna2TextBox1
            // 
            this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox1.DefaultText = "";
            this.guna2TextBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2TextBox1.Location = new System.Drawing.Point(15, 135);
            this.guna2TextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PasswordChar = '\0';
            this.guna2TextBox1.PlaceholderText = "Nhập tên đăng nhập";
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.Size = new System.Drawing.Size(309, 30);
            this.guna2TextBox1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.Gold;
            this.label3.Location = new System.Drawing.Point(14, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 24);
            this.label3.TabIndex = 24;
            this.label3.Text = "Mật Khẩu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(12, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 24);
            this.label2.TabIndex = 25;
            this.label2.Text = "Tên Đăng Nhập";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(35, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 105);
            this.label1.TabIndex = 26;
            this.label1.Text = "Xin Chào";
            // 
            // guna2Button3
            // 
            this.guna2Button3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2Button3.BorderRadius = 7;
            this.guna2Button3.BorderThickness = 2;
            this.guna2Button3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button3.FillColor = System.Drawing.SystemColors.ControlLightLight;
            this.guna2Button3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2Button3.Location = new System.Drawing.Point(15, 279);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.Size = new System.Drawing.Size(146, 52);
            this.guna2Button3.TabIndex = 31;
            this.guna2Button3.Text = "Đăng Ký";
            this.guna2Button3.Click += new System.EventHandler(this.guna2Button3_Click);
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
            this.guna2Button1.Location = new System.Drawing.Point(178, 279);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(146, 52);
            this.guna2Button1.TabIndex = 3;
            this.guna2Button1.Text = "Đăng Nhập";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click_1);
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
            this.guna2Button2.Location = new System.Drawing.Point(12, 346);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(146, 52);
            this.guna2Button2.TabIndex = 33;
            this.guna2Button2.Text = "Khách";
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // lbl_Message
            // 
            this.lbl_Message.AutoSize = true;
            this.lbl_Message.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Message.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_Message.Location = new System.Drawing.Point(14, 253);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(0, 23);
            this.lbl_Message.TabIndex = 34;
            // 
            // Login
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_Message);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.guna2Button3);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.guna2TextBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Login";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Guna2Button guna2Button3;
        private Guna2Button guna2Button1;
        private Guna2Button guna2Button2;
        private Label lbl_Message;
    }
}