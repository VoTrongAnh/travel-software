using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class VietDanhGia : Form
    {
        private User user;
        private string tenDiaDiem;
        private string selectedImagePath = null; // Lưu đường dẫn ảnh được chọn

        public VietDanhGia(User user, string tenDiaDiem)
        {
            InitializeComponent();
            this.user = user;
            this.tenDiaDiem = tenDiaDiem;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void VietDanhGia_Load(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel13_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị thông báo xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy và quay lại trang Xem Đánh Giá không?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Đóng form hiện tại
                    this.Close();

                    // Mở lại form Xem Đánh Giá
                    XemDanhGia formXemDanhGia = new XemDanhGia(tenDiaDiem, user);
                    formXemDanhGia.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi quay lại trang Xem Đánh Giá: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            // Thu thập thông tin từ form
            string evaluationContent = rtb_VietDanhGia.Text.Trim();

            if (string.IsNullOrEmpty(evaluationContent))
            {
                lbl_Message.Text = "Vui lòng nhập đánh giá";
                lbl_Message.ForeColor = Color.Red;
                return; // Dừng xử lý nếu không hợp lệ
            }

            DateTime submittedDate = DateTime.Now; // Ngày gửi đánh giá
            bool approvalStatus = false; // Trạng thái duyệt: false = Chờ duyệt
            string userID = user.GetMaDuKhach(); // Mã người đánh giá
            string location = tenDiaDiem; // Địa điểm đánh giá

            // Kiểm tra số từ trong nội dung đánh giá
            int wordCount = evaluationContent.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;

            if (wordCount > 100)
            {
                lbl_Message.Text = "Nội dung đánh giá không được quá 100 từ.";
                lbl_Message.ForeColor = Color.Red;
                return; // Dừng xử lý nếu không hợp lệ
            }

            lbl_Message.Text = ""; // Xóa thông báo lỗi nếu hợp lệ

            // Kiểm tra nếu ảnh đã được chọn
            string relativeFilePath = null;

            if (!string.IsNullOrEmpty(selectedImagePath))
            {
                try
                {
                    // Đường dẫn thư mục lưu trữ ảnh (tương đối)
                    string relativeFolder = "../img/"; // Đường dẫn tương đối
                    string absoluteFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeFolder);

                    if (!Directory.Exists(absoluteFolder))
                    {
                        Directory.CreateDirectory(absoluteFolder);
                    }

                    // Đường dẫn file đích (tên file được tạo ngẫu nhiên để tránh trùng lặp)
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(selectedImagePath);
                    string absoluteFilePath = Path.Combine(absoluteFolder, fileName);
                    relativeFilePath = Path.Combine(relativeFolder, fileName); // Đường dẫn tương đối

                    // Copy ảnh vào thư mục lưu trữ
                    File.Copy(selectedImagePath, absoluteFilePath, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra khi lưu ảnh: {ex.Message}");
                    return;
                }
            }

            // Thực hiện thêm bài viết vào cơ sở dữ liệu kèm đường dẫn ảnh
            string query = @"
        INSERT INTO BaiVietDanhGia (maNguoiDanhGia, tenDiaDiem, noiDung, Duyet, ngay, HinhAnh)
        VALUES (@maNguoiDanhGia, @tenDiaDiem, @noiDung, @Duyet, @ngay, @HinhAnh)";

            try
            {
                using (SqlConnection connection = new SqlConnection("Server=LAPTOP-97E246FS;Database=QuanLyDuLich;Trusted_Connection=True;"))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số vào câu lệnh SQL
                        command.Parameters.AddWithValue("@maNguoiDanhGia", userID);
                        command.Parameters.AddWithValue("@tenDiaDiem", location);
                        command.Parameters.AddWithValue("@noiDung", evaluationContent);
                        command.Parameters.AddWithValue("@Duyet", approvalStatus);
                        command.Parameters.AddWithValue("@ngay", submittedDate);
                        command.Parameters.AddWithValue("@HinhAnh", string.IsNullOrEmpty(relativeFilePath) ? (object)DBNull.Value : relativeFilePath);
                        // Nếu không chọn ảnh, lưu NULL

                        // Thực thi câu lệnh
                        int result = command.ExecuteNonQuery();

                        // Kiểm tra kết quả
                        if (result > 0)
                        {
                            MessageBox.Show("Bài viết và hình ảnh đã được lưu thành công!");
                            this.Close(); // Đóng form sau khi gửi đánh giá
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi xảy ra khi lưu bài viết!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi lưu vào cơ sở dữ liệu: {ex.Message}");
            }
        }



        private void guna2Button3_Click(object sender, EventArgs e)
        {
            // Mở hộp thoại để người dùng chọn ảnh
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Lưu đường dẫn ảnh đã chọn
                    selectedImagePath = openFileDialog.FileName;

                    // Hiển thị đường dẫn ảnh vào Guna2TextBox2
                    guna2TextBox2.Text = selectedImagePath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra khi chọn ảnh: {ex.Message}");
                }
            }
            else
            {
                guna2TextBox2.Text = "Bạn chưa chọn ảnh."; // Thông báo trong TextBox nếu không chọn ảnh
            }
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Xác nhận người dùng có chắc chắn muốn xóa hình không
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hình ảnh đã chọn?", "Xác nhận xóa hình", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Xóa nội dung trong TextBox và đặt selectedImagePath về null
                    guna2TextBox2.Text = "Không có hình ảnh.";
                    selectedImagePath = null;

                    MessageBox.Show("Hình ảnh đã được xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi xóa hình ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
