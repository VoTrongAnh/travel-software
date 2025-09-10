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
    public partial class UserControl_QuanLyDanhGia_Admin : UserControl
    {
        public UserControl_QuanLyDanhGia_Admin()
        {
            InitializeComponent();
        }

        private void UserControl_QuanLyDanhGia_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadDiaDiemToComboBox();
        }
        //private void SetupDataGridView()
        //{
        //    // Cột nội dung: Tăng độ rộng
        //    dgv_DuyetDanhGia.Columns["Nội Dung"].Width = 300; // Tùy chỉnh độ rộng theo ý muốn

        //    // Cột hình ảnh: Hiển thị nhỏ gọn
        //    dgv_DuyetDanhGia.Columns["Hình Ảnh"].Width = 100; // Đặt chiều rộng cho cột hình ảnh

        //    // Tùy chỉnh wrap text cho nội dung để hiển thị tốt hơn
        //    dgv_DuyetDanhGia.Columns["Nội Dung"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

        //    // Tự động điều chỉnh chiều cao dòng để phù hợp với nội dung
        //    dgv_DuyetDanhGia.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        //    // Cài đặt căn giữa tiêu đề cột
        //    dgv_DuyetDanhGia.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //    // Cài đặt căn giữa các dữ liệu trong các cột (có thể thay đổi theo nhu cầu)
        //    dgv_DuyetDanhGia.Columns["Ngày"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    dgv_DuyetDanhGia.Columns["Mã Bài Viết"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    dgv_DuyetDanhGia.Columns["Tên Tài Khoản"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        //    dgv_DuyetDanhGia.Columns["Địa Điểm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        //    dgv_DuyetDanhGia.Columns["Nội Dung"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        //    dgv_DuyetDanhGia.Columns["Hình Ảnh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //    // Đảm bảo cột tiêu đề không bị lệch và chiều cao tiêu đề đúng
        //    dgv_DuyetDanhGia.ColumnHeadersHeight = 40;  // Điều chỉnh chiều cao của tiêu đề cột
        //    dgv_DuyetDanhGia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

        //    // Nếu cần, có thể tắt chế độ tự động thay đổi kích thước cột
        //    dgv_DuyetDanhGia.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        //}
        private void SetupDataGridView()
        {
            // Cài đặt kích thước chữ cho tiêu đề cột
            dgv_DuyetDanhGia.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8.25F, FontStyle.Bold);
            dgv_DuyetDanhGia.ReadOnly = true;
            // Cài đặt kích thước chữ cho dữ liệu trong các ô
            dgv_DuyetDanhGia.DefaultCellStyle.Font = new Font("Arial", 8.25F);  // Kích thước chữ nhỏ hơn

            // Cài đặt căn giữa tiêu đề cột
            dgv_DuyetDanhGia.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Cài đặt căn giữa dữ liệu cho các cột có kiểu số hoặc ngày tháng
            dgv_DuyetDanhGia.Columns["Ngày"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_DuyetDanhGia.Columns["Mã Bài Viết"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_DuyetDanhGia.Columns["Hình Ảnh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Căn trái cho các cột văn bản như "Tên Tài Khoản", "Địa Điểm", "Nội Dung"
            dgv_DuyetDanhGia.Columns["Tên Tài Khoản"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv_DuyetDanhGia.Columns["Địa Điểm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv_DuyetDanhGia.Columns["Nội Dung"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Cài đặt chế độ xuống dòng cho cột "Nội Dung"
            dgv_DuyetDanhGia.Columns["Nội Dung"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Cài đặt chiều cao của các dòng để phù hợp với nội dung
            dgv_DuyetDanhGia.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Điều chỉnh chiều rộng cột (tuỳ chỉnh theo nhu cầu)
            dgv_DuyetDanhGia.Columns["Ngày"].Width = 100;
            dgv_DuyetDanhGia.Columns["Mã Bài Viết"].Width = 120;
            dgv_DuyetDanhGia.Columns["Tên Tài Khoản"].Width = 150;
            dgv_DuyetDanhGia.Columns["Địa Điểm"].Width = 150;
            dgv_DuyetDanhGia.Columns["Nội Dung"].Width = 300;
            dgv_DuyetDanhGia.Columns["Hình Ảnh"].Width = 100;

            // Đảm bảo cột tự động điều chỉnh theo nội dung
            dgv_DuyetDanhGia.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }


        private void btnDuyet_Click(object sender, EventArgs e)
        {

            if (dgv_DuyetDanhGia.SelectedRows.Count > 0)
            {
                // Lấy thông tin của dòng được chọn
                DataGridViewRow selectedRow = dgv_DuyetDanhGia.SelectedRows[0];
                if (selectedRow.Cells["Mã Bài Viết"].Value == null || string.IsNullOrWhiteSpace(selectedRow.Cells["Mã Bài Viết"].Value.ToString()))
                {
                    MessageBox.Show("Không tồn tại bài viết");
                    return; // Dừng lại nếu giá trị không hợp lệ
                }
                string maBaiViet = selectedRow.Cells["Mã Bài Viết"].Value.ToString(); // Giả sử có cột MaBaiViet
                string tenThanhVien = selectedRow.Cells["Tên Tài Khoản"].Value.ToString();
                string diaDiem = selectedRow.Cells["Địa Điểm"].Value.ToString();
                string noiDung = selectedRow.Cells["Nội Dung"].Value.ToString();
                DateTime ngay = Convert.ToDateTime(selectedRow.Cells["Ngày"].Value);

                // Hiển thị MessageBox xác nhận
                var result = MessageBox.Show("Bạn có muốn duyệt đánh giá này?", "Duyệt đánh giá", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // Cập nhật trạng thái duyệt trong cơ sở dữ liệu
                    UpdateDuyetStatus(maBaiViet);

                    // Thông báo thành công
                    MessageBox.Show("Đánh giá đã được duyệt!");

                    // Cập nhật lại dữ liệu trong DataGridView (nếu cần)
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bài viết để duyệt.");
            }
        }

        private void UpdateDuyetStatus(string maBaiViet)
        {
            string connectionString = "Server=LAPTOP-97E246FS;Database=QuanLyDuLich;Trusted_Connection=True;"; // Thay bằng connection string của bạn

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE BaiVietDanhGia SET Duyet = 1 WHERE maBaiViet = @maBaiViet"; // Cập nhật trạng thái duyệt

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số để tránh SQL Injection
                    command.Parameters.AddWithValue("@maBaiViet", maBaiViet);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Kiểm tra kết quả
                    if (result <= 0)
                    {
                        MessageBox.Show("Có lỗi xảy ra khi duyệt bài viết.");
                    }
                }
            }
        }
        private void LoadData()
        {
            string connectionString = "Server=LAPTOP-97E246FS;Database=QuanLyDuLich;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT bv.ngay AS N'Ngày', 
                   bv.maBaiViet AS N'Mã Bài Viết', 
                   CASE 
                       WHEN dk.maDuKhach = 'DK001' THEN 'Admin' 
                       ELSE ISNULL(tv.tenTaiKhoan, 'Du Khách') 
                   END AS N'Tên Tài Khoản', 
                   bv.tenDiaDiem AS N'Địa Điểm', 
                   bv.noiDung AS N'Nội Dung',
                   CASE 
                       WHEN ISNULL(bv.HinhAnh, '') = '' THEN N'Không có' 
                       ELSE bv.HinhAnh 
                   END AS N'Hình Ảnh'
            FROM BaiVietDanhGia bv
            LEFT JOIN ThanhVien tv ON bv.maNguoiDanhGia = tv.maDuKhach
            LEFT JOIN DuKhach dk ON bv.maNguoiDanhGia = dk.maDuKhach
            WHERE bv.Duyet = 0;";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                // Lấy dữ liệu từ cơ sở dữ liệu
                dataAdapter.Fill(dataTable);

                // Xóa các cột hiện có trong DataGridView
                dgv_DuyetDanhGia.Columns.Clear();
                // Gán dữ liệu vào DataGridView
                dgv_DuyetDanhGia.DataSource = dataTable;

                // Tùy chỉnh tên cột nếu cần thiết
                dgv_DuyetDanhGia.Columns["Ngày"].HeaderText = "Ngày";
                dgv_DuyetDanhGia.Columns["Mã Bài Viết"].HeaderText = "Mã Bài Viết";
                dgv_DuyetDanhGia.Columns["Tên Tài Khoản"].HeaderText = "Tên Thành Viên";
                dgv_DuyetDanhGia.Columns["Địa Điểm"].HeaderText = "Địa Điểm";
                dgv_DuyetDanhGia.Columns["Nội Dung"].HeaderText = "Nội Dung";
                dgv_DuyetDanhGia.Columns["Hình Ảnh"].HeaderText = "Đường Dẫn Ảnh";
                
                // Đảm bảo cột "Hình Ảnh" hiển thị đường dẫn ảnh dạng chuỗi
                if (dgv_DuyetDanhGia.Columns["Hình Ảnh"] != null)
                {
                    dgv_DuyetDanhGia.Columns["Hình Ảnh"].HeaderText = "Đường Dẫn Hình Ảnh";
                    dgv_DuyetDanhGia.Columns["Hình Ảnh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // Xử lý hiển thị "Không có" trong cột hình ảnh nếu dữ liệu trống (dự phòng)
                foreach (DataGridViewRow row in dgv_DuyetDanhGia.Rows)
                {
                    if (row.Cells["Hình Ảnh"].Value == null || string.IsNullOrEmpty(row.Cells["Hình Ảnh"].Value.ToString()))
                    {
                        row.Cells["Hình Ảnh"].Value = "Không có";
                    }
                }
                SetupDataGridView();
            }
        }


        private void guna2Button4_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn trong DataGridView không
            if (dgv_DuyetDanhGia.SelectedRows.Count > 0)
            {
                // Lấy thông tin của dòng được chọn
                DataGridViewRow selectedRow = dgv_DuyetDanhGia.SelectedRows[0];
                if (selectedRow.Cells["Mã Bài Viết"].Value == null || string.IsNullOrWhiteSpace(selectedRow.Cells["Mã Bài Viết"].Value.ToString()))
                {
                    MessageBox.Show("Không tồn tại bài viết");
                    return; // Dừng lại nếu giá trị không hợp lệ
                }
                // Lấy maBaiViet từ cột "Mã Bài Viết" trong DataGridView
                string maBaiViet = selectedRow.Cells["Mã Bài Viết"].Value.ToString(); // Điều chỉnh tên cột theo bảng của bạn

                // Thực hiện xóa bài viết khỏi cơ sở dữ liệu
                string connectionString = "Server=LAPTOP-97E246FS;Database=QuanLyDuLich;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Câu lệnh SQL để xóa bài viết
                    string query = "DELETE FROM BaiVietDanhGia WHERE maBaiViet = @maBaiViet";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@maBaiViet", maBaiViet);

                    try
                    {
                        // Mở kết nối và thực thi câu lệnh
                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Bài viết đã được xóa thành công!");
                            // Sau khi xóa, bạn có thể làm mới lại DataGridView
                            LoadData(); // Đảm bảo LoadData() là phương thức nạp lại dữ liệu
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi xảy ra khi xóa bài viết!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bài viết cần xóa.");
            }
        }
        private void LoadData(string diaDiem = "Tất cả", DateTime? startDate = null, DateTime? endDate = null)
        {
            string connectionString = "Server=LAPTOP-97E246FS;Database=QuanLyDuLich;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Khởi tạo câu truy vấn cơ bản
                string query = @"
        SELECT bv.ngay AS N'Ngày', 
               bv.maBaiViet AS N'Mã Bài Viết', 
               CASE 
                   WHEN dk.maDuKhach = 'DK001' THEN 'Admin' 
                   ELSE ISNULL(tv.tenTaiKhoan, 'Du Khách') 
               END AS N'Tên Tài Khoản', 
               bv.tenDiaDiem AS N'Địa Điểm', 
               bv.noiDung AS N'Nội Dung',
               ISNULL(bv.HinhAnh, 'Không có') AS N'Hình Ảnh'
        FROM BaiVietDanhGia bv
        LEFT JOIN ThanhVien tv ON bv.maNguoiDanhGia = tv.maDuKhach
        LEFT JOIN DuKhach dk ON bv.maNguoiDanhGia = dk.maDuKhach
        WHERE bv.Duyet = 0";

                // Thêm điều kiện lọc theo địa điểm nếu có
                if (diaDiem != "Tất cả")
                {
                    query += " AND bv.tenDiaDiem = @diaDiem";
                }

                // Thêm điều kiện lọc theo ngày nếu có
                if (startDate.HasValue && endDate.HasValue)
                {
                    query += " AND bv.ngay BETWEEN @startDate AND @endDate";
                }

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                // Truyền tham số địa điểm
                if (diaDiem != "Tất cả")
                {
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@diaDiem", diaDiem);
                }

                // Truyền tham số ngày
                if (startDate.HasValue && endDate.HasValue)
                {
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@startDate", startDate.Value.Date);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@endDate", endDate.Value.Date);
                }

                //DataTable dataTable = new DataTable();
                //dataAdapter.Fill(dataTable);

                //// Xóa cột hiện có trong DataGridView
                //dgv_DuyetDanhGia.Columns.Clear();
                //dgv_DuyetDanhGia.DataSource = dataTable;

                //// Tùy chỉnh giao diện
                //dgv_DuyetDanhGia.ReadOnly = true;
                //dgv_DuyetDanhGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //dgv_DuyetDanhGia.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                DataTable dataTable = new DataTable();

                // Lấy dữ liệu từ cơ sở dữ liệu
                dataAdapter.Fill(dataTable);

                // Xóa các cột hiện có trong DataGridView
                dgv_DuyetDanhGia.Columns.Clear();
                // Gán dữ liệu vào DataGridView
                dgv_DuyetDanhGia.DataSource = dataTable;

                // Tùy chỉnh tên cột nếu cần thiết
                dgv_DuyetDanhGia.Columns["Ngày"].HeaderText = "Ngày";
                dgv_DuyetDanhGia.Columns["Mã Bài Viết"].HeaderText = "Mã Bài Viết";
                dgv_DuyetDanhGia.Columns["Tên Tài Khoản"].HeaderText = "Tên Thành Viên";
                dgv_DuyetDanhGia.Columns["Địa Điểm"].HeaderText = "Địa Điểm";
                dgv_DuyetDanhGia.Columns["Nội Dung"].HeaderText = "Nội Dung";
                dgv_DuyetDanhGia.Columns["Hình Ảnh"].HeaderText = "Đường Dẫn Ảnh";
                SetupDataGridView();
            }
        }
        private void LoadDiaDiemToComboBox()
        {
            string connectionString = "Server=LAPTOP-97E246FS;Database=QuanLyDuLich;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT DISTINCT tenDiaDiem FROM BaiVietDanhGia WHERE Duyet = 0";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Xóa tất cả mục trong ComboBox trước khi tải lại
                    cbbDiaDiem.Items.Clear();

                    // Thêm mục "Tất cả" để hiển thị toàn bộ dữ liệu
                    cbbDiaDiem.Items.Add("Tất cả");

                    // Thêm các địa điểm từ cơ sở dữ liệu vào ComboBox
                    while (reader.Read())
                    {
                        cbbDiaDiem.Items.Add(reader["tenDiaDiem"].ToString());
                    }

                    // Đặt giá trị mặc định
                    cbbDiaDiem.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách địa điểm: " + ex.Message);
                }
            }
        }


        private void btnLoc_Click(object sender, EventArgs e)
        {
           
            string selectedDiaDiem = cbbDiaDiem.SelectedItem?.ToString() ?? "Tất cả";
            DateTime startDate = dateTimePicker2.Value.Date;
            DateTime endDate = dateTimePicker1.Value.Date;

            // Gọi phương thức LoadData để lọc dữ liệu
            LoadData(selectedDiaDiem, startDate, endDate);
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có hàng nào được chọn hay không
                if (dgv_DuyetDanhGia.SelectedRows.Count > 0)
                {
                    // Lấy hàng được chọn
                    DataGridViewRow selectedRow = dgv_DuyetDanhGia.SelectedRows[0];

                    // Lấy giá trị cột "Ảnh"
                    var cellValue = selectedRow.Cells["Hình Ảnh"].Value;

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

