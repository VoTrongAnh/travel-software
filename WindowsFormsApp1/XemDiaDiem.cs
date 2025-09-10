using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
namespace WindowsFormsApp1
{
    public partial class XemDiaDiem : Form
    {


        private string tenDiaDiem;
        private User user;
        public XemDiaDiem(User user)
        {
            InitializeComponent();
            this.user = user;

        }
        public XemDiaDiem(User user,string tenDiaDiem)
        {
            InitializeComponent();
            this.user = user;
            CapNhatThongTinDiaDiem(tenDiaDiem);

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel21_Paint(object sender, PaintEventArgs e)
        {

        }

        private void XemDiaDiem_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            XemDanhGia form4 = new XemDanhGia(tenDiaDiem,user);
            form4.Show();
            this.Hide();
        }

        private void guna2PictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            DuongDi duong = new DuongDi(this.tenDiaDiem);
            duong.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            DuongDi duong = new DuongDi(this.tenDiaDiem);
            duong.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            XemDanhGia form4 = new XemDanhGia(this.tenDiaDiem,user);
            form4.Show();
            this.Hide();
        }

        public List<string> GetHinhAnhByDiaDiem(string tenDiaDiem)
        {
            List<string> danhSachHinhAnh = new List<string>();

            try
            {
                string connectionString = "Data Source=LAPTOP-97E246FS;Initial Catalog=QuanLyDuLich;Integrated Security=True;TrustServerCertificate=True"; // Cập nhật chuỗi kết nối của bạn
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT HinhAnh FROM HinhAnh WHERE TenDiaDiem = @TenDiaDiem";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenDiaDiem", tenDiaDiem);

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            
                            string urlHinhAnh = reader.GetString(0);
                            danhSachHinhAnh.Add(urlHinhAnh);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi truy vấn cơ sở dữ liệu: " + ex.Message);
            }

            return danhSachHinhAnh;
        }
        public void HienThiHinhAnh(string tenDiaDiem)
        {
            // Lấy danh sách các hình ảnh từ cơ sở dữ liệu
            List<string> danhSachHinhAnh = GetHinhAnhByDiaDiem(tenDiaDiem);
            // Hiển thị hình ảnh vào các PictureBox từ pic_DiaDiem1 đến pic_DiaDiem5
            if (danhSachHinhAnh.Count > 0)
            {
                pic_DiaDiem1.ImageLocation = danhSachHinhAnh[0];
                pic_DiaDiem1.SizeMode = PictureBoxSizeMode.StretchImage;
            
            }

            if (danhSachHinhAnh.Count > 1)
            {
                pic_DiaDiem2.ImageLocation = danhSachHinhAnh[1];
                pic_DiaDiem2.SizeMode = PictureBoxSizeMode.StretchImage;
       
            }

            if (danhSachHinhAnh.Count > 2)
            {
                pic_DiaDiem3.ImageLocation = danhSachHinhAnh[2];
                pic_DiaDiem3.SizeMode = PictureBoxSizeMode.StretchImage;
  
            }

            if (danhSachHinhAnh.Count > 3)
            {
                pic_DiaDiem4.ImageLocation = danhSachHinhAnh[3];
                pic_DiaDiem4.SizeMode = PictureBoxSizeMode.StretchImage;
       
            }

            if (danhSachHinhAnh.Count > 4)
            {
                pic_DiaDiem5.ImageLocation = danhSachHinhAnh[4];
                pic_DiaDiem5.SizeMode = PictureBoxSizeMode.StretchImage;
    
            }
            if(danhSachHinhAnh.Count > 5)
            {
                pic_DiaDiem6.ImageLocation = danhSachHinhAnh[5];
                pic_DiaDiem6.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            if (danhSachHinhAnh.Count > 6)
            {
                pic_DiaDiem7.ImageLocation = danhSachHinhAnh[6];
                pic_DiaDiem7.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }


        public string LayMoTa(string tenDiaDiem)
        {
            string moTa = string.Empty;

            // Kết nối cơ sở dữ liệu
            using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-97E246FS;Initial Catalog=QuanLyDuLich;Integrated Security=True;TrustServerCertificate=True"))
            {
                try
                {
                    // Mở kết nối
                    conn.Open();

                    // Câu truy vấn lấy mô tả của địa điểm
                    string query = "SELECT moTa FROM DiaDiem WHERE tenDiaDiem = @tenDiaDiem";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm tham số để tránh SQL Injection
                        cmd.Parameters.AddWithValue("@tenDiaDiem", tenDiaDiem);

                        // Thực thi câu truy vấn và lấy kết quả
                        var result = cmd.ExecuteScalar();

                        // Nếu có kết quả, gán vào biến mô tả
                        if (result != null)
                        {
                            moTa = result.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu có
                    MessageBox.Show("Lỗi khi truy vấn cơ sở dữ liệu: " + ex.Message);
                }
            }

            return moTa;
        }


        public void CapNhatThongTinDiaDiem(string tenDiaDiem)
        {
            this.tenDiaDiem = tenDiaDiem;
            lbl_TenDiaDiem.Text = tenDiaDiem;
            lbl_TenDiaDiem2.Text = tenDiaDiem+",Việt Nam";
            HienThiHinhAnh(tenDiaDiem);

            // Lấy mô tả và xử lý để in đậm các từ giữa cặp ** **
            string moTa = LayMoTa(tenDiaDiem);
            lbl_MoTa.Text = System.Text.RegularExpressions.Regex.Replace(moTa, @"\*\*(.*?)\*\*", "$1");


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
