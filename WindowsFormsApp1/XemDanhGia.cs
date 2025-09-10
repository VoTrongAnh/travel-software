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
using System.IO;

namespace WindowsFormsApp1
{
    public partial class XemDanhGia : Form
    {
        private string tenDiaDiem;
        private User user;
        public XemDanhGia(string tenDiaDiem, User user)
        {
            InitializeComponent();
            this.tenDiaDiem = tenDiaDiem;
            this.user = user;
            // Gọi hàm sử dụng tenDiaDiem nếu cần
            HienThiDanhGia();
            LoadData();
            panel1.Controls.Add(lbl_TieuDe);
            lbl_TieuDe.Location = new Point(
            (panel1.Width - lbl_TieuDe.Width) / 2, // Căn giữa theo chiều ngang
            (panel1.Height - lbl_TieuDe.Height) / 2 // Căn giữa theo chiều dọc
            ) ;
            this.user = user;
        }

        private void SetupDataGridView()
        {
            // Cột nội dung: Tăng độ rộng
            dgv_XemDanhGia.Columns["Nội Dung"].Width = 300; // Tùy chỉnh độ rộng theo ý muốn

            // Cột hình ảnh: Hiển thị nhỏ gọn
            dgv_XemDanhGia.Columns["Ảnh"].Width = 100; // Đặt chiều rộng cho cột hình ảnh

            // Tùy chỉnh wrap text cho nội dung để hiển thị tốt hơn
            dgv_XemDanhGia.Columns["Nội Dung"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Tự động điều chỉnh chiều cao dòng để phù hợp với nội dung
            dgv_XemDanhGia.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Cài đặt căn giữa tiêu đề cột
            dgv_XemDanhGia.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Cài đặt căn giữa các dữ liệu trong các cột (có thể thay đổi theo nhu cầu)
            dgv_XemDanhGia.Columns["Ngày"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_XemDanhGia.Columns["Mã Bài Viết"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_XemDanhGia.Columns["Tên Tài Khoản"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv_XemDanhGia.Columns["Nội Dung"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv_XemDanhGia.Columns["Ảnh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Đảm bảo cột tiêu đề không bị lệch và chiều cao tiêu đề đúng
            dgv_XemDanhGia.ColumnHeadersHeight = 40;  // Điều chỉnh chiều cao của tiêu đề cột
            dgv_XemDanhGia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv_XemDanhGia.ReadOnly = true;
            // Nếu cần, có thể tắt chế độ tự động thay đổi kích thước cột
            dgv_XemDanhGia.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void LoadData()
        {
            string connectionString = "Server=LAPTOP-97E246FS;Database=QuanLyDuLich;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT bv.ngay AS N'Ngày', 
                   maBaiViet AS N'Mã Bài Viết',
                   CASE 
                       WHEN dk.maDuKhach = 'DK001' THEN 'Admin' 
                       ELSE ISNULL(tv.tenTaiKhoan, 'Du Khách') 
                   END AS N'Tên Tài Khoản', 
                   bv.tenDiaDiem AS N'Địa Điểm', 
                   bv.noiDung AS N'Nội Dung', 
                   ISNULL(bv.HinhAnh, 'Không có') AS N'Ảnh'
            FROM BaiVietDanhGia bv
            LEFT JOIN ThanhVien tv ON bv.maNguoiDanhGia = tv.maDuKhach
            LEFT JOIN DuKhach dk ON bv.maNguoiDanhGia = dk.maDuKhach
            WHERE bv.Duyet = 1 AND bv.tenDiaDiem = @tenDiaDiem";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@tenDiaDiem", tenDiaDiem);

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Gán dữ liệu vào DataGridView
                dgv_XemDanhGia.DataSource = dataTable;

                // Tùy chỉnh tên cột nếu cần thiết
                dgv_XemDanhGia.Columns["Ngày"].HeaderText = "Ngày";
                dgv_XemDanhGia.Columns["Mã Bài Viết"].HeaderText = "Mã Bài Viết";
                dgv_XemDanhGia.Columns["Tên Tài Khoản"].HeaderText = "Tên Thành Viên";
                dgv_XemDanhGia.Columns["Nội Dung"].HeaderText = "Nội Dung";
                dgv_XemDanhGia.Columns["Ảnh"].HeaderText = "Đường Dẫn Ảnh";

                // Ẩn cột "Địa Điểm" nếu không cần hiển thị
                dgv_XemDanhGia.Columns["Địa Điểm"].Visible = false;

                SetupDataGridView();
            }
        }


        private void HienThiDanhGia()
        {
            lbl_TieuDe.Text = "Đánh giá về " + tenDiaDiem; // Ví dụ hiển thị tên địa điểm trên giao diện
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            VietDanhGia form5 = new VietDanhGia(user,tenDiaDiem);
            form5.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
     


        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            VietDanhGia form5 = new VietDanhGia(user,tenDiaDiem);
            form5.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

  


        private void XoaBaiVietTrongDatabase(string maBaiViet)
        {
            // Thực hiện xóa bài viết từ cơ sở dữ liệu (ví dụ với câu lệnh SQL)
            string connectionString = "Server=LAPTOP-97E246FS;Database=QuanLyDuLich;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM BaiVietDanhGia WHERE maBaiViet = @maBaiViet";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@maBaiViet", maBaiViet);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            // Đóng form hiện tại
            this.Hide();

            // Mở lại form xem địa điểm
            XemDiaDiem formXemDiaDiem = new XemDiaDiem(user,tenDiaDiem);
            formXemDiaDiem.Show();

        }
        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có hàng nào được chọn hay không
                if (dgv_XemDanhGia.SelectedRows.Count > 0)
                {
                    // Lấy hàng được chọn
                    DataGridViewRow selectedRow = dgv_XemDanhGia.SelectedRows[0];

                    // Lấy giá trị cột "Ảnh"
                    var cellValue = selectedRow.Cells["Ảnh"].Value;

                    if (cellValue != null && !string.IsNullOrEmpty(cellValue.ToString()))
                    {
                        string relativeImagePath = cellValue.ToString();

                        // Chuyển đường dẫn tương đối thành đường dẫn tuyệt đối
                        string absoluteImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeImagePath);

                        // Kiểm tra xem file ảnh có tồn tại không
                        if (File.Exists(absoluteImagePath))
                        {
                            // Mở ảnh bằng ứng dụng mặc định của hệ thống
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = absoluteImagePath,
                                UseShellExecute = true // Đảm bảo mở tệp bằng ứng dụng mặc định
                            });
                        }
                        else
                        {
                            MessageBox.Show("Ảnh không tồn tại tại đường dẫn đã lưu.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không có ảnh cho bài viết được chọn.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một hàng để xem ảnh.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
            }
        }



    }
}
