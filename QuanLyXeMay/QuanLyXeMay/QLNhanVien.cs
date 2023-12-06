using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using QuanLyXeMay.dao;
using QuanLyXeMay.model;
using QuanLyXeMay.common;
using System.IO;

namespace QuanLyXeMay
{
    public partial class QLNhanVien : Form
    {
        // Khai báo các control như là fields để có thể truy cập chúng từ nhiều phương thức
        private TextBox txtTenKH, txtTenDangNhap, txtMatKhau, txtSDT, txtEmail, txtDiaChi, txtSearch;
        private Label lblHinhAnh;
        private ComboBox cbxLoaiSP, cbxLoaiSearchList;
        FlowLayoutPanel flowLayout, flowLayoutTop, flowLayoutTopLeft, flowLayoutTopRight, flowLayoutBottom, flowLayoutSearchBar;
        PictureBox avtSanPham;
        DataGridView dataGridView;
        Button btnThem, btnSua, btnXoa, btnThoat, btnSearch, btnPrev, btnNext;
        DateTimePicker dateTimePicker;
        private SanPhamDAO sanPhamDAO;
        private NguoiDungDAO nguoiDungDAO;
        int idSelected = 0;
        int page = 1;
        int size = 10;
        RadioButton maleRadioButton, femaleRadioButton;
        public QLNhanVien()
        {
            nguoiDungDAO = new NguoiDungDAO();
            InitializeComponent();
            this.Load += new EventHandler(QLNhanVien_Load);
            this.SizeChanged += new EventHandler(QLNhanVien_SizeChanged);
        }

        private void QLNhanVien_Load(object sender, EventArgs e)
        {
            //INIT VIEW
            LoaiSPDAO loaiSpDao = new LoaiSPDAO();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnThoat = new Button();
            btnPrev = new Button();
            btnNext = new Button();
            btnSearch = new Button();
            txtTenKH = new TextBox();
            txtTenDangNhap = new TextBox();
            txtMatKhau = new TextBox();
            txtSDT = new TextBox();
            txtEmail = new TextBox();
            txtDiaChi = new TextBox();
            txtSearch = new TextBox();
            cbxLoaiSP = new ComboBox();
            cbxLoaiSearchList = new ComboBox();
            maleRadioButton = new RadioButton();
            femaleRadioButton = new RadioButton();
            dateTimePicker = new DateTimePicker();
            lblHinhAnh = CreateView.CreateLabel("");

            this.Text = "Xemaytot.com | Quản lý nhân viên";
            flowLayout = new FlowLayoutPanel();
            flowLayout.FlowDirection = FlowDirection.TopDown;

            FlowLayoutPanel topHeaderLayout = CreateView.CreateFlowLeftToRight();
            topHeaderLayout.Size = new Size(300, 40);
            topHeaderLayout.Controls.Add(CreateView.CreateButton("Trở về", btnThoat));
            flowLayout.Controls.Add(topHeaderLayout);
            btnThoat.Click += btnThoat_Click;

            flowLayoutTop = CreateView.CreateFlowLeftToRight();
            flowLayoutTopLeft = CreateView.CreateFlowTopDown();
            flowLayoutTopRight = CreateView.CreateFlowTopDown();

            avtSanPham = new PictureBox();
            avtSanPham.Image = Image.FromFile("images\\" + "exciter.jpg");
            avtSanPham.SizeMode = PictureBoxSizeMode.Zoom;

            flowLayoutTopLeft.Controls.Add(avtSanPham);
            
            flowLayoutTop.Controls.Add(flowLayoutTopLeft);
            flowLayoutTop.Controls.Add(flowLayoutTopRight);
            flowLayoutBottom = new FlowLayoutPanel();
            flowLayoutSearchBar = CreateView.CreateFlowRightToLeft();
            flowLayoutSearchBar.Size = new Size(500, 40);

            flowLayoutTopRight.Controls.Add(CreateView.CreateInput("Tên nhân viên", txtTenKH));
            flowLayoutTopRight.Controls.Add(CreateView.CreateInput("Số điện thoại", txtSDT));
            flowLayoutTopRight.Controls.Add(CreateView.CreateInput("Email", txtEmail));
            flowLayoutTopRight.Controls.Add(CreateView.CreateDateInput("Ngày sinh", dateTimePicker));
            flowLayoutTopRight.Controls.Add(CreateView.CreateInput("Địa chỉ", txtDiaChi));
            flowLayoutTopRight.Controls.Add(CreateView.CreateRadioButtons("Giới tính", maleRadioButton, femaleRadioButton));
            flowLayoutTopRight.Controls.Add(CreateView.CreateInput("Tên đăng nhập", txtTenDangNhap));
            flowLayoutTopRight.Controls.Add(CreateView.CreateInput("Mật khẩu", txtMatKhau));
            txtMatKhau.PasswordChar = '*';
            flowLayoutTopRight.Controls.Add(CreateView.CreateFileInput("Ảnh đại diện", lblHinhAnh, avtSanPham));

            FlowLayoutPanel btnLayout = CreateView.CreateFlowLeftToRight();
            btnLayout.Size = new Size(500, 50);

            btnLayout.Controls.Add(CreateView.CreateButton("Thêm mới", btnThem));
            btnLayout.Controls.Add(CreateView.CreateButton("Chỉnh sửa", btnSua));
            btnLayout.Controls.Add(CreateView.CreateButton("Xóa", btnXoa));
            CreateView.CreateButton("<", btnPrev);
            CreateView.CreateButton(">", btnNext);
            btnPrev.Size = new Size(50, 30);
            btnNext.Size = new Size(50, 30);
            btnNext.Margin = new Padding(0,3, 5 ,0);
            btnThem.Click += new EventHandler(btnThem_Click);
            btnSua.Click += new EventHandler(btnSua_Click);
            btnXoa.Click += new EventHandler(btnXoa_Click);
            btnPrev.Click += new EventHandler(btnPrev_Click);
            btnNext.Click += new EventHandler(btnNext_Click);
            flowLayoutTopRight.Controls.Add(btnLayout);

            

            txtSearch.Font = new Font(txtSearch.Font.FontFamily, 12);
            txtSearch.Size = new Size(250, 30);
            txtSearch.Margin = new Padding(5, 5, 0, 0);
            CreateView.CreateButton("Tìm kiếm",btnSearch);
            btnSearch.Click += btnSearch_Click;
            List<ComboBoxItem> listItem = new List<ComboBoxItem>();
            listItem.Add(new ComboBoxItem
            {
                Value = -1,
                Text = "Tất cả"
            });
            listItem.Add( new ComboBoxItem
            {
                Value = 0,
                Text = "Tên nhân viên"
            });
            listItem.Add(new ComboBoxItem
            {
                Value = 1,
                Text = "Số điện thoại"
            });
            listItem.Add(new ComboBoxItem
            {
                Value = 2,
                Text = "Tên đăng nhập"
            });
            listItem.Add(new ComboBoxItem
            {
                Value = 3,
                Text = "Email"
            });
            CreateView.CreateComboBoxCustom(cbxLoaiSearchList, listItem);
            cbxLoaiSearchList.SelectedIndexChanged += cbxLoaiSearchList_SelectedIndexChanged;

            flowLayoutSearchBar.Controls.Add(btnSearch);
            flowLayoutSearchBar.Controls.Add(txtSearch);
            flowLayoutSearchBar.Controls.Add(cbxLoaiSearchList);
            flowLayoutSearchBar.Controls.Add(btnNext);
            flowLayoutSearchBar.Controls.Add(btnPrev);
            flowLayoutBottom.Controls.Add(flowLayoutSearchBar);

            setupGridDataView();
            flowLayoutBottom.Controls.Add(dataGridView);


            flowLayout.Controls.Add(flowLayoutTop);
            flowLayout.Controls.Add(flowLayoutBottom);

            Controls.Add(flowLayout);

            UpdateControlsPosition();
            this.MinimumSize = new Size(600, 400);
            this.WindowState = FormWindowState.Maximized;
            DisplayProductList();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            MenuApp menuForm = new MenuApp();
            menuForm.Show();
            this.Hide();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            page = 1;
            string keyword = txtSearch.Text;
            string selectedValue = cbxLoaiSearchList.SelectedValue.ToString();
            int maLoaiSP = 0;
            int.TryParse(selectedValue, out maLoaiSP);
            
            List<NguoiDung> listSP = nguoiDungDAO.GetUserByKeyword(keyword, maLoaiSP, "nhanvien", page, size);
            dataGridView.DataSource = listSP;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (page == 1)
            {
                return;
            }
            page -= 1;
            string keyword = txtSearch.Text;
            string selectedValue = cbxLoaiSearchList.SelectedValue.ToString();
            int maLoaiSP = 0;
            int.TryParse(selectedValue, out maLoaiSP);
            List<NguoiDung> listKH = nguoiDungDAO.GetUserByKeyword(keyword, maLoaiSP, "nhanvien", page, size);
            if (listKH.Count > 0)
            {
                dataGridView.DataSource = listKH;
            }
            else
            {
                page += 1;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            page += 1;
            string keyword = txtSearch.Text;
            string selectedValue = cbxLoaiSearchList.SelectedValue.ToString();
            int maLoaiSP = 0;
            int.TryParse(selectedValue, out maLoaiSP);
            List<NguoiDung> listKH = nguoiDungDAO.GetUserByKeyword(keyword, maLoaiSP, "nhanvien", page, size);
            if (listKH.Count > 0)
            {
                dataGridView.DataSource = listKH;
            }
            else
            {
                page -= 1;
            }
        }

        private void cbxLoaiSearchList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Xử lý sự kiện thay đổi trong ComboBox ở đây
            if (cbxLoaiSearchList.SelectedItem != null)
            {
                page = 1;
                // Lấy giá trị đã chọn
                string keyword = txtSearch.Text;
                string selectedValue = cbxLoaiSearchList.SelectedValue.ToString();
                int maLoaiSP = 0;
                int.TryParse(selectedValue, out maLoaiSP);
                if (maLoaiSP == -1)
                {
                    keyword = "";
                    txtSearch.Text = "";
                }
                List<NguoiDung> listUser = nguoiDungDAO.GetUserByKeyword(keyword, maLoaiSP, "nhanvien", page, size);
                dataGridView.DataSource = listUser;
            }
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Lấy dòng đầu tiên được chọn (nếu có)
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                string maKHStr = selectedRow.Cells[0].Value.ToString();
                int maKH = 0;
                int.TryParse(maKHStr, out maKH);
                idSelected = maKH;
                // Lấy giá trị từ các ô trong dòng được chọn
                txtTenDangNhap.Text = selectedRow.Cells[1].Value.ToString();
                txtTenKH.Text = selectedRow.Cells[2].Value.ToString();
                txtSDT.Text = selectedRow.Cells[3].Value.ToString();
                txtEmail.Text = selectedRow.Cells[4].Value.ToString();

                string gioiTinh = selectedRow.Cells[5].Value.ToString();
                if (gioiTinh == "Nam")
                {
                    maleRadioButton.Checked = true;
                }
                else
                {
                    femaleRadioButton.Checked = true;
                }

                string ngaySinhStr = selectedRow.Cells[7].Value.ToString();
                DateTime ngaySinh;
                if (DateTime.TryParse(ngaySinhStr, out ngaySinh))
                {
                    dateTimePicker.Value = ngaySinh;
                }
                txtMatKhau.Text = "";
                txtDiaChi.Text = selectedRow.Cells[6].Value.ToString();
                string hinhAnh = selectedRow.Cells[8].Value.ToString();
                string projectPath = System.IO.Directory.GetCurrentDirectory(); // Đường dẫn thư mục hiện tại của dự án
                string targetDirectory = Path.Combine(projectPath, "image_upload");
                if (hinhAnh != "")
                {
                    avtSanPham.Image = Image.FromFile(targetDirectory + "\\" + hinhAnh + ".jpg");
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenKH = txtTenKH.Text;
            string sdt = txtSDT.Text;
            string email = txtEmail.Text;
            string diaChi = txtDiaChi.Text;
            string tenDangNhap = txtTenDangNhap.Text;
            string matKhau = txtMatKhau.Text;
            DateTime ngaySinh = dateTimePicker.Value;
            string gioiTinh = "Nam";
            if (femaleRadioButton.Checked)
            {
                gioiTinh = "Nữ";
            }
            if (tenKH.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (sdt.Trim() == "" || sdt.Trim().Length < 8)
            {
                MessageBox.Show("Vui lòng nhập số điện thoại hợp lệ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (email.Trim() == "" || !email.Contains("@") || email.Trim().Length < 4)
            {
                MessageBox.Show("Vui lòng nhập email hợp lệ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (diaChi.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập địa chỉ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tenDangNhap.Trim() == "" || tenDangNhap.Trim().Length < 6)
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập dài hơn 6 kí tự", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            NguoiDung found = nguoiDungDAO.GetUserByUsername(tenDangNhap.Trim());
            if (found != null)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (matKhau.Trim() == "" || matKhau.Trim().Length < 6)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu dài hơn 6 kí tự", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ngaySinh >= DateTime.Now)
            {
                MessageBox.Show("Vui lòng nhập ngày sinh nhỏ hơn hôm nay", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string path = lblHinhAnh.Text;
            if (path == "")
            {
                MessageBox.Show("Vui lòng chọn ảnh đại diện", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string fileName = GenerateRandomFileName();

            if (storageImage(path, fileName))
            {
                NguoiDung nguoiDung = new NguoiDung();
                nguoiDung.TenNguoiDung = tenKH.Trim();
                nguoiDung.TenDangNhap = tenDangNhap.Trim();
                nguoiDung.MatKhau = matKhau;
                nguoiDung.SoDienThoai = sdt.Trim();
                nguoiDung.Email = email.Trim();
                nguoiDung.GioiTinh = gioiTinh;
                nguoiDung.NgaySinh = ngaySinh;
                nguoiDung.DiaChi = diaChi;
                nguoiDung.HinhAnh = fileName;
                nguoiDung.VaiTro = "nhanvien";
                nguoiDungDAO.InsertNguoiDung(nguoiDung);

                string selectedValueSearch = cbxLoaiSearchList.SelectedValue.ToString();
                int loaiSearch = 0;
                int.TryParse(selectedValueSearch, out loaiSearch);
                List<NguoiDung> listKH = nguoiDungDAO.GetUserByKeyword(txtSearch.Text, loaiSearch, "nhanvien", page, size);
                dataGridView.DataSource = listKH;

                MessageBox.Show("Tạo mới khách hàng thành công", "Thông báo");
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            string tenKH = txtTenKH.Text;
            string sdt = txtSDT.Text;
            string email = txtEmail.Text;
            string diaChi = txtDiaChi.Text;
            string tenDangNhap = txtTenDangNhap.Text;
            string matKhau = txtMatKhau.Text;
            DateTime ngaySinh = dateTimePicker.Value;
            string gioiTinh = "Nam";
            if (femaleRadioButton.Checked)
            {
                gioiTinh = "Nữ";
            }
            if (tenKH.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (sdt.Trim() == "" || sdt.Trim().Length < 8)
            {
                MessageBox.Show("Vui lòng nhập số điện thoại hợp lệ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (email.Trim() == "" || !email.Contains("@") || email.Trim().Length < 4)
            {
                MessageBox.Show("Vui lòng nhập email hợp lệ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (diaChi.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập địa chỉ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tenDangNhap.Trim() == "" || tenDangNhap.Trim().Length < 6)
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập dài hơn 6 kí tự", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (matKhau.Trim() != "" && matKhau.Trim().Length < 6)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu dài hơn 6 kí tự", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ngaySinh >= DateTime.Now)
            {
                MessageBox.Show("Vui lòng nhập ngày sinh nhỏ hơn hôm nay", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string path = lblHinhAnh.Text;
            string fileName = "";
            NguoiDung nguoiDung = nguoiDungDAO.GetNguoiDungById(idSelected);
            if (path == "")
            {
                fileName = nguoiDung.HinhAnh;
            }
            else
            {
                fileName = GenerateRandomFileName();
                storageImage(path, fileName);
            }

            nguoiDung.TenNguoiDung = tenKH.Trim();
            nguoiDung.TenDangNhap = tenDangNhap.Trim();
            if (matKhau != "")
            {
                nguoiDung.MatKhau = matKhau;
            }
            nguoiDung.SoDienThoai = sdt.Trim();
            nguoiDung.Email = email.Trim();
            nguoiDung.GioiTinh = gioiTinh;
            nguoiDung.NgaySinh = ngaySinh;
            nguoiDung.DiaChi = diaChi;
            nguoiDung.HinhAnh = fileName;

            nguoiDungDAO.UpdateNguoiDung(nguoiDung);

            string selectedValueSearch = cbxLoaiSearchList.SelectedValue.ToString();
            int loaiSearch = 0;
            int.TryParse(selectedValueSearch, out loaiSearch);
            List<NguoiDung> listKH = nguoiDungDAO.GetUserByKeyword(txtSearch.Text, loaiSearch, "nhanvien", page, size);
            dataGridView.DataSource = listKH;

            MessageBox.Show("Sửa thông tin khách hàng thành công", "Thông báo");
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            nguoiDungDAO.XoaNguoiDung(idSelected);
            string selectedValueSearch = cbxLoaiSearchList.SelectedValue.ToString();
            int loaiSearch = 0;
            int.TryParse(selectedValueSearch, out loaiSearch);
            List<NguoiDung> listKH = nguoiDungDAO.GetUserByKeyword(txtSearch.Text, loaiSearch, "nhanvien", page, size);
            dataGridView.DataSource = listKH;
            MessageBox.Show("Xóa người dùng thành công");
        }

        public string GenerateRandomFileName()
        {
            // Sử dụng hàm Path.GetRandomFileName để tạo chuỗi ngẫu nhiên
            string randomFileName = Path.GetRandomFileName();

            // Loại bỏ ký tự không hợp lệ trong tên tệp tin
            randomFileName = randomFileName.Replace(".", "");

            return randomFileName;
        }

        private bool storageImage(string imagePath,string fileName)
        {
            string projectPath = System.IO.Directory.GetCurrentDirectory(); // Đường dẫn thư mục hiện tại của dự án
            try
            {
                // Tạo đường dẫn đến thư mục trong dự án để lưu hình ảnh
                string targetDirectory = Path.Combine(projectPath, "image_upload");

                // Kiểm tra xem thư mục đã tồn tại chưa, nếu không thì tạo mới
                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }

                // Tạo đường dẫn đến nơi bạn muốn lưu hình ảnh trong thư mục của dự án
                string targetPath = Path.Combine(targetDirectory, fileName + ".jpg");

                // Sao chép hình ảnh từ đường dẫn nguồn đến đường dẫn đích
                File.Copy(imagePath, targetPath, true);

                return true;
                //MessageBox.Show("Hình ảnh đã được lưu thành công trong thư mục của dự án.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Đã xảy ra lỗi khi lưu hình ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void QLNhanVien_SizeChanged(object sender, EventArgs e)
        {
            UpdateControlsPosition();
        }

        private void UpdateControlsPosition()
        {
            flowLayout.Width = this.ClientSize.Width;
            flowLayout.Height = this.ClientSize.Height;
            flowLayoutTop.Width = this.flowLayout.Width;
            flowLayoutTop.Height = this.flowLayout.Height / 2 + 50;
            flowLayoutTopLeft.Width = flowLayoutTop.Width / 2;
            flowLayoutTopLeft.Height = flowLayoutTop.Height;
            flowLayoutTopRight.Width = flowLayoutTop.Width / 2 - 20;
            flowLayoutTopRight.Height = flowLayoutTop.Height;
            flowLayoutBottom.Width = this.flowLayout.Width;
            flowLayoutBottom.Height = this.flowLayout.Height / 2 - 150;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.Width = this.flowLayoutBottom.Width;
            dataGridView.Height = this.flowLayoutBottom.Height;
            avtSanPham.Width = this.flowLayoutTopLeft.Width;
            avtSanPham.Height = this.flowLayoutTopLeft.Height;
            flowLayoutSearchBar.Width = flowLayout.Width - 20;
        }
        private void DisplayProductList()
        {
            List<NguoiDung> listKhachHang = nguoiDungDAO.GetUserByKeyword("", -1, "nhanvien", page, size);
            dataGridView.DataSource = listKhachHang;
        }

        private void setupGridDataView()
        {
            dataGridView = new DataGridView();
            dataGridView.AutoGenerateColumns = false;

            // Thêm cột cho DataGridView
            DataGridViewTextBoxColumn colMaKH = new DataGridViewTextBoxColumn();
            colMaKH.DataPropertyName = "MaNguoiDung"; // Liên kết với thuộc tính MaSanPham của class SanPham
            colMaKH.HeaderText = "Mã khách hàng";
            dataGridView.Columns.Add(colMaKH);

            DataGridViewTextBoxColumn colTenDangNhap = new DataGridViewTextBoxColumn();
            colTenDangNhap.DataPropertyName = "TenDangNhap"; 
            colTenDangNhap.HeaderText = "Tên đăng nhập";
            dataGridView.Columns.Add(colTenDangNhap);

            DataGridViewTextBoxColumn colTenKH = new DataGridViewTextBoxColumn();
            colTenKH.DataPropertyName = "TenNguoiDung"; 
            colTenKH.HeaderText = "Tên khách hàng";
            dataGridView.Columns.Add(colTenKH);

            DataGridViewTextBoxColumn colSDT = new DataGridViewTextBoxColumn();
            colSDT.DataPropertyName = "SoDienThoai"; 
            colSDT.HeaderText = "Số điện thoại";
            dataGridView.Columns.Add(colSDT);


            DataGridViewTextBoxColumn colEmail = new DataGridViewTextBoxColumn();
            colEmail.DataPropertyName = "Email"; 
            colEmail.HeaderText = "Email";
            dataGridView.Columns.Add(colEmail);

            DataGridViewTextBoxColumn colGioiTinh = new DataGridViewTextBoxColumn();
            colGioiTinh.DataPropertyName = "GioiTinh"; 
            colGioiTinh.HeaderText = "Giới tính";
            dataGridView.Columns.Add(colGioiTinh);

            DataGridViewTextBoxColumn colDiaChi = new DataGridViewTextBoxColumn();
            colDiaChi.DataPropertyName = "DiaChi"; 
            colDiaChi.HeaderText = "Địa chỉ";
            dataGridView.Columns.Add(colDiaChi);

            DataGridViewTextBoxColumn colNgaySinh = new DataGridViewTextBoxColumn();
            colNgaySinh.DataPropertyName = "NgaySinh"; 
            colNgaySinh.HeaderText = "Ngày sinh";
            dataGridView.Columns.Add(colNgaySinh);

            DataGridViewTextBoxColumn colHinhAnh = new DataGridViewTextBoxColumn();
            colHinhAnh.DataPropertyName = "HinhAnh";
            colHinhAnh.HeaderText = "Hình ảnh";
            dataGridView.Columns.Add(colHinhAnh);
            
            dataGridView.ReadOnly = true;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.SelectionChanged += dataGridView_SelectionChanged;
        }
       
    }
}
