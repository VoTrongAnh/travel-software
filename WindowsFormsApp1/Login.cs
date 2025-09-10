using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        private string maUser;
        private string tenTaiKhoanUser;
        public Login()
        {  
            InitializeComponent();
            passwordTextBox.UseSystemPasswordChar = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }



        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, EventArgs e)
        {
            Form3 kpmk = new Form3();
            kpmk.Show();
            this.Hide();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private User AuthenticateUser(string username, string password)
        {
            string connectionString = "Server=LAPTOP-97E246FS;Database=QuanLyDuLich;Trusted_Connection=True;";

            // Nếu tài khoản là admin, kiểm tra bảng QuanTriVien
            if (username.ToLower() == "admin")
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT maQuanTriVien, tenTaiKhoan, maDuKhach FROM QuanTriVien WHERE tenTaiKhoan = @username AND matKhau = @password";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Đọc dữ liệu từ cơ sở dữ liệu
                                string maAdmin = reader.GetString(0); // Cột maQuanTri
                                string tenTaiKhoanAdmin = reader.GetString(1); // Cột tenTaiKhoan
                                string maDuKhach = reader.GetString(2);                           // Trả về đối tượng User với thông tin quản trị viên
                                return new User(maAdmin, tenTaiKhoanAdmin, maDuKhach);
                            }
                        }
                    }
                }
            }
            else
            {
                // Nếu không phải admin, kiểm tra bảng ThanhVien
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT maThanhVien, tenTaiKhoan, maDuKhach FROM ThanhVien WHERE tenTaiKhoan = @username AND matKhau = @password";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Đọc dữ liệu từ cơ sở dữ liệu
                                string maUser = reader.GetString(0); // Cột maThanhVien
                                string tenTaiKhoan = reader.GetString(1); // Cột tenTaiKhoan
                                string maDuKhach = reader.GetString(2); // Cột maDuKhach
                                                                        // Trả về đối tượng User với thông tin thành viên
                                return new User(maUser, tenTaiKhoan, maDuKhach);
                            }
                        }
                    }
                }
            }

            // Trả về null nếu không tìm thấy người dùng
            return null;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            DangKy dangKy = new DangKy();
            dangKy.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //TrangChu form1 = new TrangChu();
            //form1.Show();
            //this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            guna2TextBox1.KeyDown += TextBox_KeyDown;
            passwordTextBox.KeyDown += TextBox_KeyDown;

        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Gọi nút đăng nhập
                guna2Button1_Click_1(sender, e);
                // Ngăn âm thanh beep
                e.SuppressKeyPress = true;
            }
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DangKy dangKy = new DangKy();
            dangKy.Show();
            this.Hide();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            string username = guna2TextBox1.Text.Trim();
            string password = passwordTextBox.Text.Trim();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lbl_Message.Text = "Vui lòng nhập đầy đủ thông tin."; // Hiển thị thông báo khi thiếu thông tin
                lbl_Message.ForeColor = Color.Orange; // Màu chữ cam để làm nổi bật thông báo thiếu
                lbl_Message.Visible = true; // Đảm bảo Label luôn hiển thị
                return; // Dừng lại nếu không đầy đủ thông tin
            }
            User authenticatedUser = AuthenticateUser(username, password);

            if (authenticatedUser != null)
            {
                // Mở form chính và truyền User vào
                Form1 formUser = new Form1(authenticatedUser);
                formUser.Show();
                this.Hide();
            }
            else
            {
                // Thay thế MessageBox bằng Label
                lbl_Message.Text = "Tên đăng nhập hoặc mật khẩu không đúng."; // Hiển thị thông báo trên Label
                lbl_Message.ForeColor = Color.Red;
                passwordTextBox.Focus();
            }
        }



        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //TrangChu form1 = new TrangChu();
            //form1.Show();
            //this.Hide();
            Form1 form1 = new Form1(new User("DK004","Du Khách","DK004"));
            form1.Show();
            this.Hide();
        }





    }
}
