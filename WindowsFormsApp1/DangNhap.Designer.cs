using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace WindowsFormsApp1
{
    public partial class DangNhap : Form
    {
        private System.Windows.Forms.PictureBox pictureBox1;
        private LinkLabel linkLabel1;
        private Button button2;
        private Button button1;
        private Guna2TextBox passwordTextBox;
        private Guna2TextBox guna2TextBox1;
        private Label label3;
        private Label label2;
        private Label label1;

        public DangNhap()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangNhap));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.passwordTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.ForeColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(17, 248);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(97, 16);
            this.linkLabel1.TabIndex = 21;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Quên Mật Khẩu";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(15, 280);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(142, 38);
            this.button2.TabIndex = 20;
            this.button2.Text = "Đăng Ký";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(183, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 38);
            this.button1.TabIndex = 19;
            this.button1.Text = "Đăng Nhập";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.passwordTextBox.DefaultText = "";
            this.passwordTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.passwordTextBox.Location = new System.Drawing.Point(15, 199);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '\0';
            this.passwordTextBox.PlaceholderText = "Nhập mật khẩu";
            this.passwordTextBox.SelectedText = "";
            this.passwordTextBox.Size = new System.Drawing.Size(309, 30);
            this.passwordTextBox.TabIndex = 22;
            // 
            // guna2TextBox1
            // 
            this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox1.DefaultText = "";
            this.guna2TextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox1.Location = new System.Drawing.Point(15, 135);
            this.guna2TextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PasswordChar = '\0';
            this.guna2TextBox1.PlaceholderText = "Nhập tên đăng nhập";
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.Size = new System.Drawing.Size(309, 30);
            this.guna2TextBox1.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(12, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 24;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Text = "Mật Khẩu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(12, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 16);
            this.label2.TabIndex = 25;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Text = "Tên Đăng Nhập";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(35, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 105);
            this.label1.TabIndex = 26;
            this.label1.Text = "Xin Chào";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(15, 355);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(142, 39);
            this.button3.TabIndex = 27;
            this.button3.Text = "Khách";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // Form4
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.guna2TextBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Button button3;
    }
}
