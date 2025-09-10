using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
          
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string username = guna2TextBox1.Text;
            string email = guna2TextBox2.Text;
            string password = guna2TextBox3.Text;

            // Kiểm tra nếu thiếu thông tin
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lbl_Message.Text = "Vui lòng điền đầy đủ thông tin.";
                lbl_Message.ForeColor = Color.Orange;
                lbl_Message.Visible = true; // Hiển thị Label thông báo
                return;
            }

            // Thực hiện đăng ký người dùng
            if (RegisterUser(username, email, password))
            {
                lbl_Message.Text = "Đăng Ký Thành Công!";
                lbl_Message.ForeColor = Color.Green;
                lbl_Message.Visible = true; // Hiển thị Label thông báo thành công

                // Tạo và cấu hình Timer
                Timer timer = new Timer();
                timer.Interval = 2000; // Đặt thời gian chờ là 2 giây (2000ms)
                timer.Tick += (tickSender, args) =>
                {
                    timer.Stop(); // Dừng timer sau khi thực hiện

                    // Mở form đăng nhập và ẩn form đăng ký
                    Login login = new Login();
                    login.Show();
                    this.Hide();
                };
                timer.Start(); // Bắt đầu đếm ngược 2 giây
            }


            else
            {
                lbl_Message.Text = "Đăng Ký Thất Bại. Vui lòng thử lại.";
                lbl_Message.ForeColor = Color.Red;
                lbl_Message.Visible = true; // Hiển thị Label thông báo thất bại
            }
        }
        private void DangKy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                guna2Button1_Click(sender, e);
            }
        }


        private bool RegisterUser(string username, string email, string password)
        {
            string connectionString = "Server=LAPTOP-97E246FS;Database=QuanLyDuLich;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Biến lưu thông báo lỗi nếu có
                        StringBuilder errorMessage = new StringBuilder();


                        // Kiểm tra xem email đã tồn tại chưa
                        string checkEmailQuery = "SELECT COUNT(1) FROM ThanhVien WHERE email = @email";
                        using (SqlCommand command = new SqlCommand(checkEmailQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@email", email);
                            int emailExists = (int)command.ExecuteScalar();
                            if (emailExists > 0)
                            {
                                errorMessage.AppendLine("Email đã tồn tại. Vui lòng chọn email khác.");
                            }
                        }

                        // Nếu có lỗi, chỉ hiển thị thông báo lỗi và ngừng tiếp tục quá trình đăng ký
                        if (errorMessage.Length > 0)
                        {
                            MessageBox.Show(errorMessage.ToString()); // Hiển thị tất cả các lỗi
                            return false; // Ngừng thực hiện các bước tiếp theo
                        }

                        // Bước 1: Thêm vào bảng DuKhach
                        string insertDukhachQuery = "INSERT INTO DuKhach (maDuKhach) VALUES (DBO.AUTO_IDDK());";
                        using (SqlCommand command = new SqlCommand(insertDukhachQuery, connection, transaction))
                        {
                            command.ExecuteNonQuery();
                        }

                        // Bước 2: Lấy mã du khách vừa chèn
                        string selectMaDuKhachQuery = "SELECT TOP 1 maDuKhach FROM DuKhach ORDER BY maDuKhach DESC";
                        string maDuKhach;
                        using (SqlCommand command = new SqlCommand(selectMaDuKhachQuery, connection, transaction))
                        {
                            maDuKhach = command.ExecuteScalar()?.ToString();
                            if (string.IsNullOrEmpty(maDuKhach))
                            {
                                throw new Exception("Không thể lấy mã du khách.");
                            }
                        }

                        // Bước 3: Thêm vào bảng ThanhVien (Lưu mật khẩu dưới dạng chuỗi văn bản)
                        string insertThanhVienQuery = "INSERT INTO ThanhVien (tenTaiKhoan, email, matKhau, maDuKhach) VALUES (@username, @email, @password, @maDuKhach)";
                        using (SqlCommand command = new SqlCommand(insertThanhVienQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@username", username);
                            command.Parameters.AddWithValue("@email", email);
                            command.Parameters.AddWithValue("@password", password); // Lưu mật khẩu dưới dạng chuỗi văn bản
                            command.Parameters.AddWithValue("@maDuKhach", maDuKhach);

                            int result = command.ExecuteNonQuery();
                            if (result <= 0)
                            {
                                throw new Exception("Thêm vào bảng ThanhVien không thành công.");
                            }
                        }

                        // Cam kết giao dịch
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        private void DangKy_Load(object sender, EventArgs e)
        {
             this.KeyDown += new KeyEventHandler(DangKy_KeyDown);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
