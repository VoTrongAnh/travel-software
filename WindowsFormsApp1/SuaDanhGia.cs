using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
namespace WindowsFormsApp1
{
    public partial class SuaDanhGia : Form
    {
        private string maBaiViet;
        private string selectedImagePath = null;

        public SuaDanhGia(string maBaiViet)
        {
            InitializeComponent();
            this.maBaiViet = maBaiViet;
            LoadData();
        }

        private void LoadData()
        {
            string connectionString = "Server=LAPTOP-97E246FS;Database=QuanLyDuLich;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT noiDung, HinhAnh FROM BaiVietDanhGia WHERE maBaiViet = @maBaiViet";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@maBaiViet", maBaiViet);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Hiển thị nội dung bài viết
                        rtbNoiDung.Text = reader["noiDung"].ToString();
                        rtbNoiDung.Focus();

                        // Hiển thị đường dẫn ảnh nếu có
                        string imagePath = reader["HinhAnh"].ToString();
                        if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                        {
                            selectedImagePath = imagePath;
                            guna2TextBox2.Text = imagePath;
                        }
                    }
                }
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            string evaluationContent = rtbNoiDung.Text.Trim();
            if (string.IsNullOrEmpty(evaluationContent))
            {
                lbl_Message.Text = "Vui lòng nhập đánh giá";
                lbl_Message.ForeColor = Color.Red;
                return; // Dừng xử lý nếu không hợp lệ
            }

            // Kiểm tra số từ trong nội dung đánh giá
            int wordCount = evaluationContent.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;

            if (wordCount > 100)
            {
                lbl_Message.Text = "Nội dung đánh giá không được quá 100 từ.";
                lbl_Message.ForeColor = Color.Red;
                return; // Dừng xử lý nếu không hợp lệ
            }

            lbl_Message.Text = ""; // Xóa thông báo lỗi nếu hợp lệ

            string newImagePath = SaveImage(selectedImagePath);

            string query = "UPDATE BaiVietDanhGia SET noiDung = @noiDung, HinhAnh = @HinhAnh WHERE maBaiViet = @maBaiViet";
            string connectionString = "Server=LAPTOP-97E246FS;Database=QuanLyDuLich;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số vào lệnh SQL
                    command.Parameters.AddWithValue("@noiDung", evaluationContent);
                    command.Parameters.AddWithValue("@HinhAnh", string.IsNullOrEmpty(newImagePath) ? (object)DBNull.Value : newImagePath);
                    command.Parameters.AddWithValue("@maBaiViet", maBaiViet);

                    // Thực thi câu lệnh
                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Cập nhật bài viết thành công!");
                        this.Close(); // Đóng form sau khi cập nhật thành công
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi cập nhật bài viết.");
                    }
                }
            }
        }

        private string SaveImage(string selectedImagePath)
        {
            if (string.IsNullOrEmpty(selectedImagePath)) return null;

            try
            {
                // Đường dẫn lưu trữ ảnh
                string relativeFolder = "../img/";
                string absoluteFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeFolder);

                // Tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(absoluteFolder))
                {
                    Directory.CreateDirectory(absoluteFolder);
                }

                // Tạo tên file ảnh mới (UUID để tránh trùng lặp)
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(selectedImagePath);
                string absoluteFilePath = Path.Combine(absoluteFolder, fileName);
                string relativeFilePath = Path.Combine(relativeFolder, fileName);

                // Sao chép file ảnh vào thư mục
                File.Copy(selectedImagePath, absoluteFilePath, true);

                return relativeFilePath;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi lưu ảnh: {ex.Message}");
                return null;
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Hiển thị thông báo xác nhận hủy
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy và đóng form không?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close(); // Đóng form
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hình ảnh không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Xóa đường dẫn hình ảnh trong TextBox và đặt selectedImagePath về null
                    guna2TextBox2.Text = "Không có hình ảnh.";
                    selectedImagePath = null;

                    // Thông báo thành công
                    MessageBox.Show("Hình ảnh đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi xóa hình ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SuaDanhGia_Load(object sender, EventArgs e)
        {

        }
    }
}
