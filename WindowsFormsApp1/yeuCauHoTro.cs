using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class yeuCauHoTro : Form
    {
        public yeuCauHoTro()
        {
            InitializeComponent();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string accountName = guna2TextBox1.Text; // Tên tài khoản
            string email = guna2TextBox2.Text; // Email
            string content = guna2TextBox3.Text; // Nội dung yêu cầu

            // Kiểm tra các trường nhập liệu
            if (string.IsNullOrEmpty(accountName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(content))
            {
                lbl_Message.Text = "Vui lòng điền đầy đủ thông tin!";
                lbl_Message.ForeColor = System.Drawing.Color.Red;
                return;
            }

            try
            {
                // Cấu hình thông tin gửi email
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com"); // Gmail SMTP server

                mail.From = new MailAddress("your-email@gmail.com"); // Địa chỉ email của bạn
                mail.To.Add("votronganhhh@gmail.com"); // Địa chỉ email của admin
                mail.Subject = "Yêu cầu hỗ trợ từ " + accountName;
                mail.Body = $"Tên tài khoản: {accountName}\nEmail: {email}\nNội dung yêu cầu: {content}";

                smtpServer.Port = 587; // Cổng SMTP cho Gmail
                smtpServer.Credentials = new NetworkCredential("tr4nphuccc23@gmail.com", "ogln cxtz nxog ocgz"); // Thông tin đăng nhập vào Gmail
                smtpServer.EnableSsl = true; // Bật SSL

                // Gửi email
                smtpServer.Send(mail);
                lbl_Message.Text = "Yêu cầu hỗ trợ đã được gửi thành công!";
                lbl_Message.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                lbl_Message.Text = "Có lỗi xảy ra: " + ex.Message;
                lbl_Message.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Form1 ycht = new Form1();
            ycht.Show();
            //this.Hide();
        }
    }
}
