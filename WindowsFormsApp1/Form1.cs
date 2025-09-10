using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private User user;
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(User user)
        {
            InitializeComponent();
            this.user = user;
            if (user.GetMaUser().StartsWith("QT"))
            {
                lbl_role.Text = "Admin";
                lbl_ten.Text = user.GetTenTaiKhoanUser();
            }
            else if(user.GetMaUser().StartsWith("TV"))
            {
                lbl_role.Text = "Thành Viên";
                lbl_ten.Text = user.GetTenTaiKhoanUser();

            }
            else
                    {
                lbl_role.Text = "Khách";
                lbl_ten.Text = "Du Khách";
                buttonDangXuat.Text = "Đăng Nhập";
            }

            UserControl_TrangChu ucTC = new UserControl_TrangChu(user);
            addUserControl(ucTC);

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            userControlPanel.Controls.Clear();
            userControlPanel.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void userControlPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonTrangchu_Click(object sender, EventArgs e)
        {
            if (user.GetMaUser().StartsWith("QT"))
            {
                lbl_role.Text = "Admin";
                lbl_ten.Text = user.GetTenTaiKhoanUser();


            }
            else if (user.GetMaUser().StartsWith("TV"))
            {
                lbl_role.Text = "Thành Viên";
                lbl_ten.Text = user.GetTenTaiKhoanUser();


            }
            else
            {
                lbl_role.Text = "Khách";
                lbl_ten.Text = "Du Khách";
                buttonDangXuat.Text = "Đăng Nhập";
            }

            UserControl_TrangChu ucTC = new UserControl_TrangChu(user);
            addUserControl(ucTC);
        }

        private void buttonMienBac_Click(object sender, EventArgs e)
        {
            UserControl_MienBac ucDD = new UserControl_MienBac(user);
            ucDD.Dock = DockStyle.None;
            addUserControl(ucDD);
        }

        private void buttonMienTrung_Click(object sender, EventArgs e)
        {
            UserControl_MienTrung ucDD = new UserControl_MienTrung(user);
            ucDD.Dock = DockStyle.None;
            addUserControl(ucDD);
        }

        private void buttonMienNam_Click(object sender, EventArgs e)
        {
            UserControl_MienNam ucDD = new UserControl_MienNam(user);
            ucDD.Dock = DockStyle.None;
            addUserControl(ucDD);
        }

        private void buttonThongKe_Click(object sender, EventArgs e)
        {
            // Giả sử user.GetMaUser là phương thức trả về mã người dùng hiện tại
            string maUser = user.GetMaUser();

            if (maUser.StartsWith("TV") || maUser.StartsWith("DK"))
            {
                MessageBox.Show("Bạn không đủ quyền hạn, chức năng này chỉ dành riêng cho Admin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UserControl_ThongKe ucDD = new UserControl_ThongKe();
            addUserControl(ucDD);
        }


        private void buttonGoiY_Click(object sender, EventArgs e)
        {
            UserControl_GoiY ucGY = new UserControl_GoiY();
            addUserControl(ucGY);
        }

        private void buttonQuanLy_Click(object sender, EventArgs e)
        {
            // Lấy tên tài khoản hiện tại
            string tenTaiKhoan = user.GetMaDuKhach();

            if (tenTaiKhoan.Contains("DK004")) // Kiểm tra nếu tên tài khoản bắt đầu bằng "DK"
            {
                MessageBox.Show("Vui lòng đăng nhập để sử dụng chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else if (tenTaiKhoan.Contains("DK001")) // Kiểm tra nếu tên tài khoản chứa "DK001" (Admin)
            {
                // Hiển thị UserControl dành cho Admin
                UserControl_QuanLyDanhGia_Admin ucQLDG_Admin = new UserControl_QuanLyDanhGia_Admin();
                addUserControl(ucQLDG_Admin);
            }
            else
            {
                // Hiển thị UserControl dành cho Thành viên
                UserControl_QuangLyDanhGia_Sua_Xoa ucQLDG_ThanhVien = new UserControl_QuangLyDanhGia_Sua_Xoa(user);
                addUserControl(ucQLDG_ThanhVien);
            }
        }


        private void buttonDangXuat_Click(object sender, EventArgs e)
        {
            // Ẩn Form hiện tại (ví dụ: Form chính)
            this.Hide();

            // Hiển thị lại Form đăng nhập (Form đăng nhập phải là một Form đã tạo sẵn)
            Login formDangNhap = new Login();
            formDangNhap.Show();

            // Xóa các thông tin đăng nhập (nếu có lưu trữ, ví dụ: trong biến hoặc session)
            user = null; // Đặt lại đối tượng user nếu cần
        }

        bool menuExpand = false;
        private void menuTrans_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                flowLayoutPanel1.Width += 10;
                if (flowLayoutPanel1.Width == flowLayoutPanel1.MaximumSize.Width)
                {
                    menuTrans.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                flowLayoutPanel1.Width -= 10;
                if (flowLayoutPanel1.Width == flowLayoutPanel1.MinimumSize.Width)
                {
                    menuTrans.Stop();
                    menuExpand = false;
                }
            }
        }
        private void buttonMenu_Click(object sender, EventArgs e)
        {
            menuTrans.Start();
        }
        private bool isExiting = false; // Biến cờ để kiểm soát

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Kiểm tra nếu ứng dụng đang thoát
            if (isExiting)
            {
                return; // Không làm gì nếu đã kích hoạt thoát ứng dụng
            }

            // Hiển thị hộp thoại xác nhận trước khi thoát
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng không?",
                                                  "Xác nhận thoát",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                isExiting = true; // Đặt cờ để tránh gọi lại sự kiện
                Application.Exit(); // Thoát hoàn toàn ứng dụng
            }
            else
            {
                e.Cancel = true; // Hủy sự kiện đóng nếu người dùng chọn "No"
            }
        }


        bool diadiemExpand = false;
        private void diadiemTrans_Tick(object sender, EventArgs e)
        {
            if (diadiemExpand == false)
            {
                panel4.Height += 10;
                if (panel4.Height == panel4.MaximumSize.Height)
                {
                    diadiemTrans.Stop();
                    diadiemExpand = true;
                }
            }
            else
            {
                panel4.Height -= 10;
                if (panel4.Height == panel4.MinimumSize.Height)
                {
                    diadiemTrans.Stop();
                    diadiemExpand = false;
                }
            }
        }
        private void buttonDiadiem_Click(object sender, EventArgs e)
        {
            diadiemTrans.Start();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            yeuCauHoTro ycht = new yeuCauHoTro();
            ycht.Show();
        }
    }
}
