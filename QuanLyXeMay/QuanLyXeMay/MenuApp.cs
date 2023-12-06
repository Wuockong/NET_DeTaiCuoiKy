using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyXeMay.dao;
using QuanLyXeMay.model;
using QuanLyXeMay.common;
namespace QuanLyXeMay
{
    public partial class MenuApp : Form
    {
        FlowLayoutPanel flowLayout;
        public MenuApp()
        {
            InitializeComponent();
            this.Load += new EventHandler(MenuApp_Load);
            this.SizeChanged += new EventHandler(MenuApp_SizeChanged);
        }
        private void MenuApp_Load(object sender, EventArgs e)
        {

            this.Text = "Xemaytot.com | Trang chủ";
            flowLayout = new FlowLayoutPanel();

            flowLayout.Size = new Size(770, 400);
            flowLayout.Padding = new Padding(10);

            FlowLayoutPanel flowXeMayLayout = CreateItemMenu("icons8-bike-100.png", "Quản lý xe máy", "xemay");
            FlowLayoutPanel flowHoaDonLayout = CreateItemMenu("icons8-order-100.png", "Quản lý hóa đơn", "hoadon");
            FlowLayoutPanel flowNhanVienLayout = CreateItemMenu("icons8-employee-100.png", "Quản lý nhân viên", "nhanvien");
            FlowLayoutPanel flowKhachHangLayout = CreateItemMenu("icons8-customer-100.png", "Quản lý khách hàng", "khachhang");
            FlowLayoutPanel flowDangXuatLayout = CreateItemMenu("icons8-logout-100.png", "Trang đăng nhập", "logout");


            flowLayout.Controls.Add(flowXeMayLayout);
            flowLayout.Controls.Add(flowHoaDonLayout);
            flowLayout.Controls.Add(flowNhanVienLayout);
            flowLayout.Controls.Add(flowKhachHangLayout);
            flowLayout.Controls.Add(flowDangXuatLayout);
            Controls.Add(flowLayout);

            // Gọi phương thức để cập nhật vị trí của controls
            UpdateControlsPosition();
            this.MinimumSize = new Size(800, 450);
            this.WindowState = FormWindowState.Maximized;
        }
        private void nhanvien_Click(object sender, EventArgs e)
        {
            QLNhanVien menuForm = new QLNhanVien();
            menuForm.Show();
            this.Hide();
        }
        private void hoadon_Click(object sender, EventArgs e)
        {
            QLHoaDon menuForm = new QLHoaDon();
            menuForm.Show();
            this.Hide();
        }
        private void xemay_Click(object xemay_Clicksender, EventArgs e)
        {
            QLXeMay menuForm = new QLXeMay();
            menuForm.Show();
            this.Hide();
        }
        private void logout_Click(object sender, EventArgs e)
        {
            DangNhap menuForm = new DangNhap();
            menuForm.Show();
            this.Hide();
        }
        private void khachhang_Click(object sender, EventArgs e)
        {
            QLKhachHang menuForm = new QLKhachHang();
            menuForm.Show();
            this.Hide();
        }
        private void MenuApp_SizeChanged(object sender, EventArgs e)
        {
            // Gọi phương thức để cập nhật vị trí của controls khi kích thước form thay đổi
            UpdateControlsPosition();
        }
        private void UpdateControlsPosition()
        {
            flowLayout.Location = new Point((this.ClientSize.Width - flowLayout.Width) / 2, (this.ClientSize.Height - flowLayout.Height) / 2);
        }

        private FlowLayoutPanel CreateItemMenu(string iconImage, string title, string type)
        {
            FlowLayoutPanel flowCustomLayout = new FlowLayoutPanel();
            flowCustomLayout.Size = new Size(200, 160);
            flowCustomLayout.Padding = new Padding(0);
            flowCustomLayout.FlowDirection = FlowDirection.TopDown;
            flowCustomLayout.Margin = new Padding(25, 25, 25, 25);

            PictureBox pictureBox1 = new PictureBox();
            pictureBox1.Height = 100;
            //pictureBox1.Image = Image.FromFile("images\\icons8-bike-100.png");
            pictureBox1.Image = Image.FromFile("images\\" + iconImage);
            pictureBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Padding = new Padding(25, 0, 30, 0);
            //Label labelUsername = CreateView.CreateLabel("Quản lý xe máy");
            FlowLayoutPanel flowLabel = CreateView.CreateFlowTopDown();
            flowLabel.Size = new Size(180, 30);
            Label labelUsername = CreateView.CreateLabel(title);
            labelUsername.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            pictureBox1.MouseEnter += PictureBox1_MouseEnter;
            pictureBox1.MouseLeave += PictureBox1_MouseLeave;

            // Thêm sự kiện cho Label
            labelUsername.MouseEnter += LabelUsername_MouseEnter;
            labelUsername.MouseLeave += LabelUsername_MouseLeave;

            flowCustomLayout.Controls.Add(pictureBox1);
            flowLabel.Controls.Add(labelUsername);
            flowCustomLayout.Controls.Add(flowLabel);
            flowCustomLayout.MouseEnter += FlowLayoutPanel_MouseEnter;
            flowCustomLayout.MouseLeave += FlowLayoutPanel_MouseLeave;

            if (type == "xemay")
            {
                flowCustomLayout.Click += new EventHandler(xemay_Click);
                pictureBox1.Click += new EventHandler(xemay_Click);
                labelUsername.Click += new EventHandler(xemay_Click);
            }
            if (type == "logout")
            {
                flowCustomLayout.Click += new EventHandler(logout_Click);
                pictureBox1.Click += new EventHandler(logout_Click);
                labelUsername.Click += new EventHandler(logout_Click);
            }
            if (type == "khachhang")
            {
                flowCustomLayout.Click += new EventHandler(khachhang_Click);
                pictureBox1.Click += new EventHandler(khachhang_Click);
                labelUsername.Click += new EventHandler(khachhang_Click);
            }
            if (type == "hoadon")
            {
                flowCustomLayout.Click += new EventHandler(hoadon_Click);
                pictureBox1.Click += new EventHandler(hoadon_Click);
                labelUsername.Click += new EventHandler(hoadon_Click);
            }
            if (type == "nhanvien")
            {
                flowCustomLayout.Click += new EventHandler(nhanvien_Click);
                pictureBox1.Click += new EventHandler(nhanvien_Click);
                labelUsername.Click += new EventHandler(nhanvien_Click);
            }
            return flowCustomLayout;
        }

        private void FlowLayoutPanel_MouseEnter(object sender, EventArgs e)
        {
            // Thay đổi màu khi chuột hover vào FlowLayoutPanel
            FlowLayoutPanel flowPanel = sender as FlowLayoutPanel;
            if (flowPanel != null)
            {
                flowPanel.BackColor = Color.LightGray;
                flowPanel.Cursor = Cursors.Hand; 
            }
        }

        private void FlowLayoutPanel_MouseLeave(object sender, EventArgs e)
        {
            // Thay đổi màu khi chuột rời khỏi FlowLayoutPanel
            FlowLayoutPanel flowPanel = sender as FlowLayoutPanel;
            if (flowPanel != null)
            {
                flowPanel.BackColor = Color.Transparent; // Hoặc màu nền mặc định của bạn
            }
        }
        private void PictureBox1_MouseEnter(object sender, EventArgs e)
        {
            // Thay đổi màu khi chuột hover vào PictureBox1
            FlowLayoutPanel flowPanel = ((Control)sender).Parent as FlowLayoutPanel;
            if (flowPanel != null)
            {
                flowPanel.BackColor = Color.LightGray;
                flowPanel.Cursor = Cursors.Hand; 
            }
        }

        private void PictureBox1_MouseLeave(object sender, EventArgs e)
        {
            // Thay đổi màu khi chuột rời khỏi PictureBox1
            FlowLayoutPanel flowPanel = ((Control)sender).Parent as FlowLayoutPanel;
            if (flowPanel != null)
            {
                flowPanel.BackColor = Color.Transparent; // Hoặc màu nền mặc định của bạn
            }
        }

        private void LabelUsername_MouseEnter(object sender, EventArgs e)
        {
            // Thay đổi màu khi chuột hover vào PictureBox1
            FlowLayoutPanel flowPanel = ((Control)sender).Parent.Parent as FlowLayoutPanel;
            if (flowPanel != null)
            {
                flowPanel.BackColor = Color.LightGray;
                flowPanel.Cursor = Cursors.Hand; 
            }
        }

        private void LabelUsername_MouseLeave(object sender, EventArgs e)
        {
            // Thay đổi màu khi chuột rời khỏi PictureBox1
            FlowLayoutPanel flowPanel = ((Control)sender).Parent.Parent as FlowLayoutPanel;
            if (flowPanel != null)
            {
                flowPanel.BackColor = Color.Transparent; // Hoặc màu nền mặc định của bạn
            }
        }
    }
}
