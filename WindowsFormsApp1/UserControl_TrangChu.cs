using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Media;
using LiveCharts.WinForms;

namespace WindowsFormsApp1
{
    public partial class UserControl_TrangChu : UserControl
    {
        private User user;
        public UserControl_TrangChu(User user)
        {
            InitializeComponent();
            CreateGeoMap();
            this.user = user;
            lbl_Ten.Text = "Chào Mừng " + user.GetTenTaiKhoanUser();

        }

        private void CreateGeoMap()
        {
            // 1. Tạo control GeoMap
            GeoMap geoMapVietnam = new GeoMap();

            // 2. Tạo dictionary chứa dữ liệu khách du lịch (Ví dụ: Số lượng khách du lịch đến các tỉnh)
            Dictionary<string, double> valuesVietnam = new Dictionary<string, double>
{
    //{ "3655", 1000000 }, // Tổng thể Việt Nam (giả sử tổng số khách du lịch)
    { "317", 450000 },   // Đồng Bằng Sông Hồng
    { "315", 300000 },    // Hòa Bình
    { "312", 12500000 },    // Thanh Hóa
    { "307", 11000000 },    // Đông Bắc
    { "343", 2000000 },    // Hà Giang
    { "342", 13000000 },    // Cao Bằng
    { "326", 150000 },    // Bắc Giang
    { "313", 350000 },    // Tuyên Quang
    { "309", 450000 },    // Lào Cai
    { "306", 250000 },    // Điện Biên
    { "6366", 400000 },   // Lai Châu
    { "311", 500000 },    // Sơn La
    { "314", 600000 },    // Yên Bái
    { "318", 16800000 },   // Hà Nội
    { "308", 550000 },    // Thái Nguyên
    { "310", 600000 },    // Lạng Sơn
    { "286", 7500000 },    // Quảng Ninh
    { "319", 500000 },    // Bắc Ninh
    { "316", 450000 },    // Hải Dương
    { "3623",600000 },   // Hải Phòng
    { "324", 700000 },    // Nam Định
    { "322", 600000 },    // Ninh Bình
    { "327", 500000 },    // Thái Bình
    { "323", 450000 },    // Hà Nam
    { "320", 400000 },    // Vĩnh Phúc
    { "325", 350000 },    // Phú Thọ
    { "329", 4000000 },    // Nghệ An
    { "328", 500000 },    // Hà Tĩnh
    { "330", 3500000 },    // Quảng Bình
    { "302", 600000 },    // Quảng Trị
    { "303", 14500000 },    // Thừa Thiên Huế
    { "304", 13000000 },    // Đà Nẵng
    { "300", 600000 },    // Quảng Nam
    { "301", 500000 },    // Quảng Ngãi
    { "298", 550000 },    // Bình Định
    { "295", 400000 },    // Phú Yên
    { "218", 400000 },    // Khánh Hòa
    { "294", 500000 },    // Ninh Thuận
    { "176", 12700000 },    // Bình Thuận
    { "175", 18000000 },   // Hồ Chí Minh
    { "38", 650000 },     // Đồng Nai
    { "331", 800000 },    // Đông Nam Bộ
    { "173", 12000000 },    // Bà Rịa - Vũng Tàu
    { "296", 500000 },    // Bình Dương
    { "297", 700000 },    // Bình Phước
    { "305", 600000 },    // Tây Ninh
    { "336", 650000 },    // Long An
    { "6363", 550000 },   // Tiền Giang
    { "171", 5000000 },    // Bến Tre
    { "340", 450000 },    // Trà Vinh
    { "341", 500000 },    // Vĩnh Long
    { "334", 600000 },    // Đồng Tháp
    { "332", 550000 },    // An Giang
    { "335", 11700000 },    // Kiên Giang
    { "51", 600000 },     // Hậu Giang
    { "168", 500000 },    // Sóc Trăng
    { "53", 400000 },     // Bạc Liêu
    { "339", 350000 },    // Cà Mau
    { "723", 600000 },    // Đắk Lắk
    { "6365", 500000 },   // Đắk Nông
    { "724", 400000 },    // Gia Lai
    { "299", 450000 },    // Kon Tum
    { "293", 14900000 },    // Lâm Đồng
    { "333", 600000 },    // Cần Thơ
    { "61", 7000 },     // Tây Nguyên
    { "338", 500000 },    // Bạc Liêu
    { "337", 1550000 }   // Hậu Giang
};
            //geoMapVietnam.DefaultLandFill = new SolidColorBrush(Colors.Gold);
            //GradientStopCollection collection = new GradientStopCollection();
            //collection.Add(new GradientStop() { Color = System.Windows.Media.Color.FromArgb(64,64,64,0),Offset=0 });
            //geoMapVietnam.GradientStopCollection = collection;
            // 3. Tìm giá trị khách du lịch lớn nhất để chuẩn hóa dữ liệu
            double maxTourists = valuesVietnam.Values.Max();

            // 4. Chuẩn hóa số liệu khách du lịch (0 đến 100)
            Dictionary<string, double> normalizedValues = new Dictionary<string, double>();

            foreach (var key in valuesVietnam.Keys)
            {
                normalizedValues[key] = (valuesVietnam[key] / maxTourists) * 100;
            }
            // 5. Tạo một GradientStopCollection với nhiều điểm dừng màu sắc
            GradientStopCollection collection = new GradientStopCollection();

            // Thêm các điểm dừng màu sắc với sự chia đều từ 0 đến 1
            collection.Add(new GradientStop() { Color = System.Windows.Media.Color.FromArgb(255, 255, 0, 0), Offset = 0.0 });  // Đỏ cho thấp nhất (0 - 20%)
            collection.Add(new GradientStop() { Color = System.Windows.Media.Color.FromArgb(255, 255, 165, 0), Offset = 0.2 });  // Cam (20 - 40%)
            collection.Add(new GradientStop() { Color = System.Windows.Media.Color.FromArgb(255, 255, 255, 0), Offset = 0.4 });  // Vàng (40 - 60%)
            collection.Add(new GradientStop() { Color = System.Windows.Media.Color.FromArgb(255, 0, 255, 0), Offset = 0.6 });  // Xanh lá (60 - 80%)
            collection.Add(new GradientStop() { Color = System.Windows.Media.Color.FromArgb(255, 0, 0, 255), Offset = 0.8 });  // Xanh dương (80 - 100%)
            collection.Add(new GradientStop() { Color = System.Windows.Media.Color.FromArgb(255, 75, 0, 130), Offset = 1.0 });  // Tím đậm nhất
            // Áp dụng GradientStopCollection vào GeoMap
            geoMapVietnam.GradientStopCollection = collection;


            // 5. Gán dữ liệu đã chuẩn hóa vào HeatMap của bản đồ
            geoMapVietnam.HeatMap = normalizedValues;

            // 6. Gán file bản đồ (xml của Việt Nam)
            geoMapVietnam.Source = @"C:\Users\LENOVO\Documents\pmdl\pmdl\Vietnam.xml";

            // 7. Thêm control vào UserControl
            this.Controls.Add(geoMapVietnam);

            // 8. Đảm bảo GeoMap chiếm toàn bộ không gian trong UserControl
            geoMapVietnam.Dock = DockStyle.Fill;
        }


        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel8_Click(object sender, EventArgs e)
        {

        }
    }
}
