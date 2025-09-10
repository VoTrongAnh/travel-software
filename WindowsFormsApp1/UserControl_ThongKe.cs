using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class UserControl_ThongKe : UserControl
    {
        public UserControl_ThongKe()
        {
            InitializeComponent();
            InitializeTouristData();  // Gọi phương thức để nạp dữ liệu từ cơ sở dữ liệu
        }

        private List<TouristData> touristStatistics = new List<TouristData>();

        public class TouristData
        {
            public string Province { get; set; }
            public DateTime Date { get; set; }
            public int TouristCount { get; set; }
        }

        // Khởi tạo dữ liệu từ cơ sở dữ liệu
        private void InitializeTouristData()
        {
            // Kết nối đến cơ sở dữ liệu
            string connectionString = "Server=LAPTOP-97E246FS;Database=QuanLyDuLich;Trusted_Connection=True;";
            string query = "SELECT Province, Date, TouristCount FROM TouristData";  // Truy vấn dữ liệu từ bảng TouristData

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    // Đọc dữ liệu từ SqlDataReader và thêm vào danh sách touristStatistics
                    while (reader.Read())
                    {
                        string province = reader["Province"].ToString();
                        DateTime date = Convert.ToDateTime(reader["Date"]);
                        int touristCount = Convert.ToInt32(reader["TouristCount"]);

                        touristStatistics.Add(new TouristData
                        {
                            Province = province,
                            Date = date,
                            TouristCount = touristCount
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi nạp dữ liệu từ cơ sở dữ liệu: {ex.Message}");
                }
            }
        }

        // Sự kiện khi nút "Xem" được nhấn
        private void guna2Button7_Click(object sender, EventArgs e)
        {
            string selectedProvince = comboBox2.SelectedItem.ToString();
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;

            DateTime currentDate = DateTime.Now;
            DateTime startLimit = new DateTime(2024, 1, 1); // Giới hạn bắt đầu từ 01/01/2024

            if (startDate < startLimit)
            {
                MessageBox.Show("Ngày bắt đầu không thể trước ngày 01/01/2024. Vui lòng chọn lại.");
                dateTimePicker1.Value = startLimit;
                return;
            }

            if (endDate > currentDate)
            {
                MessageBox.Show("Ngày kết thúc không thể vượt quá ngày hiện tại. Vui lòng chọn lại.");
                dateTimePicker2.Value = currentDate;
                return;
            }

            if (startDate > currentDate)
            {
                startDate = currentDate;
                dateTimePicker1.Value = currentDate;
            }

            // Lọc dữ liệu khách du lịch theo tỉnh và khoảng thời gian đã chọn
            var filteredData = touristStatistics
                .Where(data => data.Province == selectedProvince && data.Date >= startDate && data.Date <= endDate)
                .ToList();

            if (filteredData.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu cho khoảng thời gian và tỉnh này.");
            }

            // Cập nhật biểu đồ với dữ liệu đã lọc
            UpdateChart(filteredData);
        }

        // Cập nhật biểu đồ với dữ liệu khách du lịch đã lọc
        private void UpdateChart(List<TouristData> filteredData)
        {
            chart1.Series["Khách du lịch"].Points.Clear();

            var timePeriod = comboBox1.SelectedItem.ToString();
            var groupedData = GroupData(filteredData, timePeriod);

            if (groupedData.Count() == 0)
            {
                MessageBox.Show("Không có dữ liệu sau khi nhóm.");
                return;
            }

            foreach (var group in groupedData)
            {
                chart1.Series["Khách du lịch"].Points.AddXY(group.Key, group.Sum(x => x.TouristCount));
            }
        }

        // Nhóm dữ liệu theo thời gian đã chọn (Tháng, Quý, Năm)
        private IEnumerable<IGrouping<string, TouristData>> GroupData(List<TouristData> data, string timePeriod)
        {
            switch (timePeriod)
            {
                case "Tháng":
                    return data.GroupBy(x => x.Date.ToString("MMMM yyyy"));
                case "Quý":
                    return data.GroupBy(x =>
                        "Quý " + ((x.Date.Month - 1) / 3 + 1) + " " + x.Date.Year);
                case "Năm":
                    return data.GroupBy(x => x.Date.Year.ToString());
                default:
                    return data.GroupBy(x => x.Date.ToString("MMMM yyyy"));
            }
        }

        // Sự kiện khi UserControl được tải
        private void UserControl_ThongKe_Load(object sender, EventArgs e)
        {
            comboBox2.Items.AddRange(new object[]
            {
                "Tất cả tỉnh", "Hà Nội", "Hồ Chí Minh", "Đà Nẵng", "Cần Thơ", "Hải Phòng",
                // Thêm các tỉnh khác nếu cần
            });

            comboBox2.SelectedItem = "Hà Nội";
            comboBox1.SelectedItem = "Tháng";

            // Khởi tạo dữ liệu từ cơ sở dữ liệu
            InitializeTouristData();
        }
    }
}
