using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Device.Location;
using System.Net.Http;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    public partial class DuongDi : Form
    {
        private string tenDiaDiem;
        private GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
        private double lat;
        private double lon;

        public DuongDi(string tenDiaDiem)
        {
            InitializeComponent();
            this.tenDiaDiem = tenDiaDiem;

            // Cấu hình ban đầu cho gmap_DuongDi
            gmap_DuongDi.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            UpdateGMapPosition(tenDiaDiem);
            gmap_DuongDi.MinZoom = 5;
            gmap_DuongDi.MaxZoom = 100;
            gmap_DuongDi.Zoom = 10;
            gmap_DuongDi.ShowCenter = false;
        }


        // Hàm cập nhật vị trí dựa trên tên địa điểm
        private void UpdateGMapPosition(string tenDiaDiem)
        {
            // Kết nối đến database
            string connectionString = "Server=LAPTOP-97E246FS;Database=QuanLyDuLich;Trusted_Connection=True;";
            string query = "SELECT viDo, kinhDo FROM LocationDiaDiem WHERE tenDiaDiem = @tenDiaDiem";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@tenDiaDiem", tenDiaDiem);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Lấy tọa độ từ database
                    double viDo = reader.GetDouble(0);
                    double kinhDo = reader.GetDouble(1);

                    // Cập nhật vị trí của gmap_DuongDi
                    gmap_DuongDi.Position = new PointLatLng(viDo, kinhDo);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy địa điểm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Tạo một đối tượng GeoCoordinateWatcher
            watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);

            // Đăng ký sự kiện PositionChanged
            watcher.PositionChanged += Watcher_PositionChanged;

            // Bắt đầu theo dõi
            watcher.Start();

            // Kiểm tra trạng thái
            if (watcher.Status == GeoPositionStatus.Disabled)
            {
                MessageBox.Show("Theo dõi vị trí bị vô hiệu hóa. Vui lòng kiểm tra cài đặt quyền truy cập vị trí.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            //Dừng theo dõi khi đã có tọa độ
            watcher.Stop();

            this.lat = e.Position.Location.Latitude;
            this.lon = e.Position.Location.Longitude;
            MessageBox.Show($"Vị trí của bạn là:\nVĩ độ: {this.lat}\nKinh độ: {this.lon}", "Vị trí", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu vị trí chưa được lấy (lat hoặc lon null)
                if (this.lat == 0 || this.lon == 0)
                {
                    MessageBox.Show("Vui lòng lấy vị trí hiện tại trước!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Dừng hàm nếu chưa có vị trí
                }

                // Tạo URL chỉ đường trên Google Maps
                string url = $"https://www.google.com/maps/dir/?api=1&origin={this.lat},{this.lon}&destination={Uri.EscapeDataString(tenDiaDiem)}";

                // Mở URL trong trình duyệt mặc định
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
