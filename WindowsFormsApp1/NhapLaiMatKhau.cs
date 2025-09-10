using System;
using System.Data.SqlClient;
using System.IdentityModel.Policy;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class NhapLaiMatKhau : Form
    {
        private string userEmail;  // Biến lưu trữ email của người dùng đang yêu cầu thay đổi mật khẩu

        public NhapLaiMatKhau(string email)
        {
            InitializeComponent();
            userEmail = email;  // Lưu trữ email khi mở form
        }

        // Khi người dùng nhấn nút "Xác Thực"
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            // Lấy mật khẩu mới và mật khẩu xác nhận
            string newPassword = guna2TextBox2.Text;
            string confirmPassword = guna2TextBox1.Text;

            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mật khẩu");
                return;
            }
            // Kiểm tra nếu mật khẩu và mật khẩu xác nhận không trùng nhau
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp, vui lòng thử lại.");
                return;
            }

            // Cập nhật mật khẩu trong cơ sở dữ liệu
            bool isUpdated = UpdatePasswordInDatabase(userEmail, newPassword);

            if (isUpdated)
            {
                MessageBox.Show("Mật khẩu đã được cập nhật thành công.");
                // Quay lại form đăng nhập hoặc màn hình chính
                this.Hide();
                Login loginForm = new Login();
                loginForm.Show();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi cập nhật mật khẩu. Vui lòng thử lại.");
            }
        }

        // Phương thức cập nhật mật khẩu trong cơ sở dữ liệu
        private bool UpdatePasswordInDatabase(string email, string newPassword)
        {
            string connectionString = "Server=LAPTOP-97E246FS;Database=QuanLyDuLich;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Câu lệnh SQL để cập nhật mật khẩu cho tài khoản với email đã cho
                    string query = "UPDATE ThanhVien SET matKhau = @Password WHERE email = @Email";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Password", newPassword);  // Lưu mật khẩu trực tiếp
                        command.Parameters.AddWithValue("@Email", email);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();  // Thực thi câu lệnh SQL

                        // Kiểm tra xem có cập nhật được tài khoản không
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi cập nhật mật khẩu: {ex.Message}");
                    return false;
                }
            }
        }

        // Nếu người dùng nhấn "Quay Lại", trở về màn hình trước
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Quay lại form đăng nhập hoặc form khác
            Login loginForm = new Login();
            loginForm.Show();
        }
    }
}
