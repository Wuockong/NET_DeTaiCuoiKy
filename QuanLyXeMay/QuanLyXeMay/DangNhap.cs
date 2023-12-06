using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using QuanLyXeMay.dao;
using QuanLyXeMay.model;

namespace QuanLyXeMay
{
    public partial class DangNhap : Form
    {
        // Khai báo các control như là fields để có thể truy cập chúng từ nhiều phương thức
        private Label labelUsername;
        private TextBox textBoxUsername;
        private Label labelPassword;
        private TextBox textBoxPassword;
        private Button buttonLogin;
        FlowLayoutPanel flowLayout;
        public DangNhap()
        {
            InitializeComponent();
            this.Load += new EventHandler(DangNhap_Load);
            this.SizeChanged += new EventHandler(DangNhap_SizeChanged);
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            
            this.Text = "Xemaytot.com | Đăng nhập";
            flowLayout = new FlowLayoutPanel();

            flowLayout.Size = new Size(300, 300);
            flowLayout.FlowDirection = FlowDirection.TopDown;
            flowLayout.Padding = new Padding(10);
            // Tạo Label
            labelUsername = new Label();
            labelUsername.Text = "Tên đăng nhập:";
            labelUsername.Font = new Font(labelUsername.Font.FontFamily, 14);
            labelUsername.AutoSize = true;

            // Tạo TextBox cho tên đăng nhập
            textBoxUsername = new TextBox();
            textBoxUsername.Text = "buiquoccong";
            textBoxUsername.Width = flowLayout.Width - 20;
            textBoxUsername.Margin = new Padding(0, 10, 0, 0);
            textBoxUsername.Font = new Font(textBoxUsername.Font.FontFamily, 14);

            // Tạo Label
            labelPassword = new Label();
            labelPassword.Text = "Mật khẩu:";
            labelPassword.Font = new Font(labelPassword.Font.FontFamily, 14);
            labelPassword.Margin = new Padding(0, 10, 0, 0);
            labelPassword.AutoSize = true;

            // Tạo TextBox cho mật khẩu
            textBoxPassword = new TextBox();
            textBoxPassword.PasswordChar = '*'; // Để ẩn mật khẩu
            textBoxPassword.Text = "123123";
            textBoxPassword.Width = flowLayout.Width - 20;
            textBoxPassword.Margin = new Padding(0, 10, 0, 0);
            textBoxPassword.Font = new Font(textBoxPassword.Font.FontFamily, 14);
            textBoxPassword.KeyPress += new KeyPressEventHandler(textBoxPassword_KeyPress);


            // Tạo Button đăng nhập
            buttonLogin = new Button();
            buttonLogin.Text = "Đăng nhập";
            buttonLogin.Font = new Font(textBoxPassword.Font.FontFamily, 14);
            buttonLogin.Size = new Size(150, 50);
            buttonLogin.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            buttonLogin.Margin = new Padding(0, 10, 0, 0);
            buttonLogin.Click += new EventHandler(button1_Click);

            // Thêm các control vào form
            flowLayout.Controls.Add(labelUsername);
            flowLayout.Controls.Add(textBoxUsername);
            flowLayout.Controls.Add(labelPassword);
            flowLayout.Controls.Add(textBoxPassword);
            flowLayout.Controls.Add(buttonLogin);
            Controls.Add(flowLayout);

            // Gọi phương thức để cập nhật vị trí của controls
            UpdateControlsPosition();
            this.MinimumSize = new Size(600, 400);
            this.WindowState = FormWindowState.Maximized;
        }

        private void DangNhap_SizeChanged(object sender, EventArgs e)
        {
            // Gọi phương thức để cập nhật vị trí của controls khi kích thước form thay đổi
            UpdateControlsPosition();
        }

        private void UpdateControlsPosition()
        {
            flowLayout.Location = new Point((this.ClientSize.Width - flowLayout.Width) / 2, (this.ClientSize.Height - flowLayout.Height) / 2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NguoiDungDAO userDao = new NguoiDungDAO();
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            NguoiDung user = userDao.LoginProcess(username, password);
            if (user == null)
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu");
            }
            else
            {
                MenuApp menuForm = new MenuApp();
                menuForm.Show();
                this.Hide();
            }
        }

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Trigger sự kiện click của nút Đăng nhập
                buttonLogin.PerformClick();
                e.Handled = true; // Ngăn chặn ký tự Enter được hiển thị trong TextBox
            }
        }
    }
}
