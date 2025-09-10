using System;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        // Biến lưu mã OTP đã tạo và gửi
        private string generatedOtp;

        public Form3()
        {
            InitializeComponent();
            lbl_Message.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e) { }

        private void button3_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string email = guna2TextBox2.Text;

            // Xóa thông báo cũ
            lbl_Message.Text = "";
            lbl_Message.ForeColor = Color.Red; // Màu mặc định cho thông báo lỗi

            // Kiểm tra nếu email trống
            if (string.IsNullOrEmpty(email))
            {
                lbl_Message.Text = "Vui lòng nhập email.";
                guna2TextBox2.Focus();  // Đặt focus vào textbox email
                return;
            }

            // Kiểm tra định dạng email hợp lệ bằng regex
            if (!IsValidEmail(email))
            {
                lbl_Message.Text = "Email không hợp lệ. Vui lòng nhập lại.";
                guna2TextBox2.Focus();  // Đặt focus vào textbox email
                return;
            }

            // Kiểm tra email trong cơ sở dữ liệu
            if (CheckEmailExists(email))
            {
                // Tạo OTP mới và gửi
                generatedOtp = GenerateOtp();
                SendOtp(email, generatedOtp);
                lbl_Message.ForeColor = Color.Green; // Đổi màu thông báo thành xanh lá cây
                lbl_Message.Text = "OTP đã được gửi đến email của bạn.";
            }
            else
            {
                lbl_Message.Text = "Email không tồn tại trong hệ thống.";
                guna2TextBox2.Focus();  // Đặt focus vào textbox email
            }
        }

        // Hàm kiểm tra định dạng email hợp lệ
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email; // Trả về true nếu email hợp lệ
            }
            catch
            {
                return false; // Trả về false nếu email không hợp lệ
            }
        }


        private bool CheckEmailExists(string email)
        {
            string connectionString = "Server=LAPTOP-97E246FS;Database=QuanLyDuLich;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM ThanhVien WHERE email = @Email";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private string GenerateOtp()
        {
            Random random = new Random();
            int otp = random.Next(100000, 999999); // Tạo OTP từ 100000 đến 999999
            return otp.ToString();
        }

        private void SendOtp(string email, string otp)
        {
            try
            {
                // Cấu hình gửi email
                var fromAddress = new MailAddress("votronganhhh@gmail.com", "PhanMemDuLich");
                var toAddress = new MailAddress(email);
                const string fromPassword = "rjot lynp qkoh cssj"; // Sử dụng mật khẩu ứng dụng thay vì mật khẩu tài khoản
                const string subject = "Mã OTP của bạn";
                string body = @"
<html>
<body>
    <p style='font-family: Arial; font-size: 20px;'>Mã OTP của bạn là: <strong style='font-size: 30px; font-weight: bold;'>" + otp + @"</strong></p>
</body>
</html>";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com", // SMTP server
                    Port = 587,
                    EnableSsl = true, // Kết nối SSL/TLS
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true  
                })
                {
                    smtp.Send(message);  // Gửi email

                    // Hiển thị thông báo thành công trên lbl_Message
                    lbl_Message.ForeColor = Color.Green; // Đổi màu thông báo thành xanh lá cây
                    lbl_Message.Text = "OTP đã được gửi đến email của bạn.";
                }
            }
            catch (SmtpException smtpEx)
            {
                // Bắt lỗi gửi email và hiển thị thông báo lỗi
                lbl_Message.ForeColor = Color.Red; // Đổi màu thông báo thành đỏ
                lbl_Message.Text = $"Lỗi SMTP: {smtpEx.Message}";
            }
            catch (Exception ex)
            {
                // Bắt các lỗi khác và hiển thị thông báo lỗi
                lbl_Message.ForeColor = Color.Red; // Đổi màu thông báo thành đỏ
                lbl_Message.Text = $"Lỗi không xác định: {ex.Message}";
            }
        }


        // Phương thức xác thực OTP khi người dùng nhập
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string enteredOtp = guna2TextBox1.Text;

            // Xóa thông báo cũ
            lbl_Message.Text = "";
            lbl_Message.ForeColor = Color.Red; // Màu mặc định cho thông báo lỗi

            // Kiểm tra OTP người dùng nhập vào với OTP đã gửi
            if (string.IsNullOrEmpty(enteredOtp))
            {
                lbl_Message.Text = "Vui lòng nhập mã OTP.";
                return;
            }

            // So sánh OTP người dùng nhập với mã đã gửi
            if (enteredOtp == generatedOtp)
            {
                // Nếu OTP đúng, chuyển đến form tạo mật khẩu mới
                NhapLaiMatKhau formNewPassword = new NhapLaiMatKhau((guna2TextBox2.Text));
                formNewPassword.Show();
                this.Hide();

                // Thông báo thành công
                lbl_Message.ForeColor = Color.Green; // Đổi màu thông báo thành xanh lá cây
                lbl_Message.Text = "OTP đúng. Vui lòng tạo mật khẩu mới.";
            }
            else
            {
                // Thông báo lỗi
                lbl_Message.Text = "Mã OTP không đúng. Vui lòng thử lại.";
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void lbl_SaiEmail_Click(object sender, EventArgs e)
        {

        }
    }
}
