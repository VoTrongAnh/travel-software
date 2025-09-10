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
    public partial class UserControl_QuangLyDanhGia_Sua_Xoa : UserControl
    {
        private User user;
        public UserControl_QuangLyDanhGia_Sua_Xoa(User user)
        {
            InitializeComponent();
            this.user = user;
            LoadData();
            LoadDiaDiemToComboBox();
        }

        private void LoadData()
        {
            string connectionString = "Server=LAPTOP-97E246FS;Database=QuanLyDuLich;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Truy vấn đơn giản lấy dữ liệu từ bảng BaiVietDanhGia
                string query = @"
        SELECT 
            ngay AS N'Ngày', 
            maBaiViet AS N'Mã Bài Viết', 
            tenDiaDiem AS N'Địa Điểm', 
            noiDung AS N'Nội Dung',
            ISNULL(HinhAnh, 'Không có') AS N'Đường Dẫn Hình Ảnh'
        FROM BaiVietDanhGia
        WHERE Duyet = 0 AND maNguoiDanhGia = @MaDuKhach";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số mã du khách
                    command.Parameters.AddWithValue("@MaDuKhach", user.GetMaDuKhach());

                    // Tạo DataAdapter và điền dữ liệu vào DataTable
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Xóa các cột hiện có trong DataGridView để tránh chồng dữ liệu
                    dgv_QuanLyDanhGia.Columns.Clear();
                    // Gán dữ liệu vào DataGridView
                    dgv_QuanLyDanhGia.DataSource = dataTable;

                    // Cấu hình DataGridView
                    dgv_QuanLyDanhGia.ReadOnly = true;
                    dgv_QuanLyDanhGia.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    dgv_QuanLyDanhGia.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
                    dgv_QuanLyDanhGia.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    dgv_QuanLyDanhGia.ColumnHeadersHeight = 40;
                    // Cấu hình cột Đường Dẫn Hình Ảnh nếu cần
                    if (dgv_QuanLyDanhGia.Columns.Contains("Đường Dẫn Hình Ảnh"))
                    {
                        dgv_QuanLyDanhGia.Columns["Đường Dẫn Hình Ảnh"].HeaderText = "Đường Dẫn Hình Ảnh";
                        dgv_QuanLyDanhGia.Columns["Đường Dẫn Hình Ảnh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu có dòng nào được chọn
            if (dgv_QuanLyDanhGia.SelectedRows.Count > 0)
            {
                if (dgv_QuanLyDanhGia.SelectedRows[0].Cells["Mã Bài Viết"].Value == null)
                {
                    MessageBox.Show("Không tồn tại bài viết");
                    return; // Dừng lại nếu giá trị không hợp lệ
                }
                // Lấy thông tin Mã Bài Viết của hàng được chọn
                var maBaiViet = dgv_QuanLyDanhGia.SelectedRows[0].Cells["Mã Bài Viết"].Value.ToString();

                // Xác nhận người dùng có muốn xóa không
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa bài viết này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    // Xóa bài viết trong cơ sở dữ liệu
                    string connectionString = "Server=LAPTOP-97E246FS;Database=QuanLyDuLich;Trusted_Connection=True;";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        // Truy vấn SQL để xóa bài viết theo mã bài viết
                        string deleteQuery = "DELETE FROM BaiVietDanhGia WHERE maBaiViet = @maBaiViet";

                        using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                        {
                            // Thêm tham số mã bài viết
                            command.Parameters.AddWithValue("@maBaiViet", maBaiViet);

                            try
                            {
                                // Mở kết nối và thực thi câu lệnh xóa
                                connection.Open();
                                int result = command.ExecuteNonQuery();

                                if (result > 0)
                                {
                                    MessageBox.Show("Xóa bài viết thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadData();  // Cập nhật lại dữ liệu trong DataGridView
                                }
                                else
                                {
                                    MessageBox.Show("Không thể xóa bài viết. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bài viết cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void LoadDiaDiemToComboBox()
        {
            string connectionString = "Server=LAPTOP-97E246FS;Database=QuanLyDuLich;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT DISTINCT tenDiaDiem FROM BaiVietDanhGia WHERE Duyet = 0 AND maNguoiDanhGia = @MaDuKhach";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaDuKhach", user.GetMaDuKhach());

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
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            // Lấy địa điểm từ ComboBox
            string selectedDiaDiem = cbbDiaDiem.SelectedItem?.ToString() ?? "Tất cả";

            // Lấy ngày từ DateTimePicker
            DateTime startDate = dateTimePicker2.Value.Date;
            DateTime endDate = dateTimePicker1.Value.Date;

            // Gọi LoadData để lọc dữ liệu
            LoadData(selectedDiaDiem, startDate, endDate);
        }

        private void LoadData(string diaDiem = "Tất cả", DateTime? startDate = null, DateTime? endDate = null)
        {
            string connectionString = "Server=LAPTOP-97E246FS;Database=QuanLyDuLich;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
        SELECT 
            ngay AS N'Ngày', 
            maBaiViet AS N'Mã Bài Viết', 
            tenDiaDiem AS N'Địa Điểm', 
            noiDung AS N'Nội Dung',
            ISNULL(HinhAnh, 'Không có') AS N'Đường Dẫn Hình Ảnh'
        FROM BaiVietDanhGia
        WHERE Duyet = 0 AND maNguoiDanhGia = @MaDuKhach";

                // Thêm điều kiện lọc theo địa điểm
                if (diaDiem != "Tất cả")
                {
                    query += " AND tenDiaDiem = @diaDiem";
                }

                // Thêm điều kiện lọc theo ngày
                if (startDate.HasValue && endDate.HasValue)
                {
                    query += " AND ngay BETWEEN @startDate AND @endDate";
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số mã du khách
                    command.Parameters.AddWithValue("@MaDuKhach", user.GetMaDuKhach());

                    // Thêm tham số địa điểm nếu có
                    if (diaDiem != "Tất cả")
                    {
                        command.Parameters.AddWithValue("@diaDiem", diaDiem);
                    }

                    // Thêm tham số ngày nếu có
                    if (startDate.HasValue && endDate.HasValue)
                    {
                        command.Parameters.AddWithValue("@startDate", startDate.Value.Date);
                        command.Parameters.AddWithValue("@endDate", endDate.Value.Date);
                    }

                    // Tạo DataAdapter và điền dữ liệu vào DataTable
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Xóa các cột hiện có trong DataGridView để tránh chồng dữ liệu
                    dgv_QuanLyDanhGia.Columns.Clear();

                    // Gán dữ liệu vào DataGridView
                    dgv_QuanLyDanhGia.DataSource = dataTable;

                    // Cấu hình DataGridView
                    dgv_QuanLyDanhGia.ReadOnly = true;
                    dgv_QuanLyDanhGia.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    dgv_QuanLyDanhGia.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
                    dgv_QuanLyDanhGia.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    dgv_QuanLyDanhGia.ColumnHeadersHeight = 40;

                    // Cấu hình cột Đường Dẫn Hình Ảnh nếu cần
                    if (dgv_QuanLyDanhGia.Columns.Contains("Đường Dẫn Hình Ảnh"))
                    {
                        dgv_QuanLyDanhGia.Columns["Đường Dẫn Hình Ảnh"].HeaderText = "Đường Dẫn Hình Ảnh";
                        dgv_QuanLyDanhGia.Columns["Đường Dẫn Hình Ảnh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
        }



        private void guna2Button7_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có hàng nào được chọn hay không
                if (dgv_QuanLyDanhGia.SelectedRows.Count > 0)
                {
                    // Lấy hàng được chọn
                    DataGridViewRow selectedRow = dgv_QuanLyDanhGia.SelectedRows[0];

                    // Lấy giá trị cột "Ảnh"
                    var cellValue = selectedRow.Cells["Đường Dẫn Hình Ảnh"].Value;

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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có hàng nào được chọn hay không
                if (dgv_QuanLyDanhGia.SelectedRows.Count > 0)
                {
                    // Lấy hàng được chọn
                    DataGridViewRow selectedRow = dgv_QuanLyDanhGia.SelectedRows[0];
                    if (dgv_QuanLyDanhGia.SelectedRows[0].Cells["Mã Bài Viết"].Value == null)
                    {
                        MessageBox.Show("Không tồn tại bài viết");
                        return; // Dừng lại nếu giá trị không hợp lệ
                    }
                    // Lấy giá trị cột "Mã Bài Viết"
                    var maBaiVietValue = selectedRow.Cells["Mã Bài Viết"].Value;

                    if (maBaiVietValue != null && !string.IsNullOrEmpty(maBaiVietValue.ToString()))
                    {
                        string maBaiViet = maBaiVietValue.ToString();

                        // Mở form SuaDanhGia và truyền mã bài viết
                        SuaDanhGia suaDanhGiaForm = new SuaDanhGia(maBaiViet);
                        suaDanhGiaForm.ShowDialog();

                        // Sau khi form SuaDanhGia được đóng, tải lại dữ liệu
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không thể lấy mã bài viết. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một bài viết để chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserControl_QuangLyDanhGia_Sua_Xoa_Load(object sender, EventArgs e)
        {

        }
    }
}
