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
    public partial class QLHoaDon : Form
    {
        // Khai báo các control như là fields để có thể truy cập chúng từ nhiều phương thức
        private Label txtTenKH, txtTenDangNhap, txtMatKhau, txtSDT, txtEmail, txtDiaChi, txtNgaySinh, txtGioiTinh, txtTongTien;
        private TextBox txtSearch;
        private Label lblHinhAnh;
        private ComboBox cbxLoaiSP, cbxLoaiSearchList;
        FlowLayoutPanel flowLayout, flowLayoutTop, flowLayoutTopLeft, flowLayoutTopRight, flowLayoutBottom, flowLayoutSearchBar;
        PictureBox avtSanPham;
        DataGridView dataGridView;
        Button btnThoat, btnSearch, btnPrev, btnNext;
        DateTimePicker dateTimePicker;
        private SanPhamDAO sanPhamDAO;
        private NguoiDungDAO nguoiDungDAO;
        private HoaDonDAO hoaDonDAO;
        int idSelected = 0;
        int page = 1;
        int size = 10;
        int tongThanhToan = 0;
        RadioButton maleRadioButton, femaleRadioButton;
        List<SanPhamItemBH> listSanPhamItem;
        public QLHoaDon()
        {
            nguoiDungDAO = new NguoiDungDAO();
            hoaDonDAO = new HoaDonDAO();
            InitializeComponent();
            this.Load += new EventHandler(QLHoaDon_Load);
            this.SizeChanged += new EventHandler(QLHoaDon_SizeChanged);
        }

        private void QLHoaDon_Load(object sender, EventArgs e)
        {
            //INIT VIEW
            LoaiSPDAO loaiSpDao = new LoaiSPDAO();
            btnThoat = new Button();
            btnPrev = new Button();
            btnNext = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            cbxLoaiSP = new ComboBox();

            txtTenKH = CreateView.CreateLabel("");
            txtTenDangNhap = CreateView.CreateLabel("");
            txtSDT = CreateView.CreateLabel("");
            txtEmail = CreateView.CreateLabel("");
            txtDiaChi = CreateView.CreateLabel("");
            txtNgaySinh = CreateView.CreateLabel("");
            txtGioiTinh = CreateView.CreateLabel("");
            txtTongTien = CreateView.CreateLabel("");
            
            cbxLoaiSearchList = new ComboBox();
            maleRadioButton = new RadioButton();
            femaleRadioButton = new RadioButton();
            dateTimePicker = new DateTimePicker();
            lblHinhAnh = CreateView.CreateLabel("");

            this.Text = "Xemaytot.com | Quản lý hóa đơn";
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

            flowLayoutTopLeft.Controls.Add(CreateView.CreateLabelInfo("Tổng tiền: ", tongThanhToan.ToString() + " VNĐ"));

            flowLayoutTop.Controls.Add(flowLayoutTopLeft);
            flowLayoutTop.Controls.Add(flowLayoutTopRight);
            flowLayoutBottom = new FlowLayoutPanel();
            flowLayoutSearchBar = CreateView.CreateFlowRightToLeft();
            flowLayoutSearchBar.Size = new Size(500, 40);

            flowLayoutTopRight.Controls.Add(CreateView.CreateLabelInfo("Tên khách hàng",txtTenKH));
            flowLayoutTopRight.Controls.Add(CreateView.CreateLabelInfo("Số điện thoại", txtSDT));
            flowLayoutTopRight.Controls.Add(CreateView.CreateLabelInfo("Email", txtEmail));
            flowLayoutTopRight.Controls.Add(CreateView.CreateLabelInfo("Ngày sinh", txtNgaySinh));
            flowLayoutTopRight.Controls.Add(CreateView.CreateLabelInfo("Địa chỉ", txtDiaChi));
            flowLayoutTopRight.Controls.Add(CreateView.CreateLabelInfo("Giới tính", txtGioiTinh));
        
            FlowLayoutPanel btnLayout = CreateView.CreateFlowLeftToRight();
            btnLayout.Size = new Size(500, 50);

            CreateView.CreateButton("<", btnPrev);
            CreateView.CreateButton(">", btnNext);
            btnPrev.Size = new Size(50, 30);
            btnNext.Size = new Size(50, 30);
            btnNext.Margin = new Padding(0,3, 5 ,0);
            btnPrev.Click += new EventHandler(btnPrev_Click);
            btnNext.Click += new EventHandler(btnNext_Click);
            flowLayoutTopRight.Controls.Add(btnLayout);
            flowLayoutTopRight.BackColor = Color.White;

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
                Text = "Tên khách hàng"
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
            DisplayHoaDonList();
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

            List<HoaDon> listHoaDon = hoaDonDAO.GetHoaDonByKeyword(keyword, maLoaiSP, "nguoidung", page, size);
            dataGridView.DataSource = listHoaDon;
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
            List<HoaDon> listHoaDon = hoaDonDAO.GetHoaDonByKeyword(keyword, maLoaiSP, "nguoidung", page, size);
            if (listHoaDon.Count > 0)
            {
                dataGridView.DataSource = listHoaDon;
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
            List<HoaDon> listHoaDon = hoaDonDAO.GetHoaDonByKeyword(keyword, maLoaiSP, "nguoidung", page, size);
            if (listHoaDon.Count > 0)
            {
                dataGridView.DataSource = listHoaDon;
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
                List<HoaDon> listHoaDon = hoaDonDAO.GetHoaDonByKeyword(keyword, maLoaiSP, "nguoidung", page, size);
                dataGridView.DataSource = listHoaDon;
            }
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                int maKH = 0;
                int.TryParse(selectedRow.Cells[2].Value.ToString(), out maKH);
                NguoiDung nguoiDung = nguoiDungDAO.GetNguoiDungById(maKH);

                int maHD = 0;
                int.TryParse(selectedRow.Cells[0].Value.ToString(), out maHD);
                idSelected = maHD;
                flowLayoutTopLeft.Controls.Clear();
                tongThanhToan = 0;
                List<SanPhamItemBH> listSanPhamItem = hoaDonDAO.GetCTHDByMaHD(maHD);
                foreach (SanPhamItemBH item in listSanPhamItem)
                {
                    flowLayoutTopLeft.Controls.Add(CreateItemSanPham(item));
                    tongThanhToan += (item.SoLuong * item.DonGia);
                }
                flowLayoutTopLeft.Controls.Add(CreateView.CreateLabelInfo("Tổng tiền: ", tongThanhToan.ToString() + " VNĐ"));

                txtTenKH.Text = nguoiDung.TenNguoiDung;
                txtEmail.Text = nguoiDung.Email;
                txtGioiTinh.Text = nguoiDung.GioiTinh;
                txtDiaChi.Text = nguoiDung.DiaChi;
                txtSDT.Text = nguoiDung.SoDienThoai;
                txtNgaySinh.Text = nguoiDung.NgaySinh.ToString("dd-MM-yyyy"); 
            }
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

        private FlowLayoutPanel CreateItemSanPham(SanPhamItemBH sp)
        {
            FlowLayoutPanel flowLayout = CreateView.CreateFlowLeftToRight();
            flowLayout.Size = new Size(800, 60);
            PictureBox pictureBox = new PictureBox();
            pictureBox = new PictureBox();
            string projectPath = System.IO.Directory.GetCurrentDirectory(); // Đường dẫn thư mục hiện tại của dự án
            string targetDirectory = Path.Combine(projectPath, "image_upload");
            pictureBox.Image = Image.FromFile(targetDirectory + "\\" + sp.HinhAnh + ".jpg");
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            FlowLayoutPanel flowLayoutTenSP = CreateView.CreateFlowTopDown();
            flowLayoutTenSP.Size = new Size(150, 60);
            Label labelTenSp = CreateView.CreateLabel(sp.TenSanPham);
            flowLayoutTenSP.Controls.Add(labelTenSp);
            Label labelTenDonGia = CreateView.CreateLabel("Giá: " + sp.DonGia.ToString());
            flowLayoutTenSP.Controls.Add(labelTenDonGia);

            FlowLayoutPanel flowLayoutSL = CreateView.CreateFlowTopDown();
            flowLayoutSL.Size = new Size(150, 60);
            Label lblSoLuong = CreateView.CreateLabel("Số lượng mua: " + sp.SoLuong.ToString());
            Label lblDVT = CreateView.CreateLabel("ĐV tính: Chiếc");
            flowLayoutSL.Controls.Add(lblSoLuong);
            flowLayoutSL.Controls.Add(lblDVT);

            FlowLayoutPanel flowThanhTien = CreateView.CreateFlowTopDown();
            flowLayoutSL.Size = new Size(200, 60);
            Label lblThanhTien = CreateView.CreateLabel("Thành tiền: " + (sp.SoLuong * sp.DonGia) + "VNĐ");
            flowThanhTien.Controls.Add(lblThanhTien);

            flowLayout.Controls.Add(pictureBox);
            flowLayout.Controls.Add(flowLayoutTenSP);
            flowLayout.Controls.Add(flowLayoutSL);
            flowLayout.Controls.Add(flowThanhTien);
            return flowLayout;
        }
        private void QLHoaDon_SizeChanged(object sender, EventArgs e)
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
            //avtSanPham.Width = this.flowLayoutTopLeft.Width;
            //avtSanPham.Height = this.flowLayoutTopLeft.Height;
            flowLayoutSearchBar.Width = flowLayout.Width - 20;
        }
        private void DisplayHoaDonList()
        {
            List<HoaDon> listHoaDon = hoaDonDAO.GetHoaDonByKeyword("", -1, "nguoidung", page, size);
            dataGridView.DataSource = listHoaDon;
        }

        private void setupGridDataView()
        {
            dataGridView = new DataGridView();
            dataGridView.AutoGenerateColumns = false;

            // Thêm cột cho DataGridView
            DataGridViewTextBoxColumn colMaHD = new DataGridViewTextBoxColumn();
            colMaHD.DataPropertyName = "MaHoaDon"; // Liên kết với thuộc tính MaSanPham của class SanPham
            colMaHD.HeaderText = "Mã Hóa đơn";
            dataGridView.Columns.Add(colMaHD);

            DataGridViewTextBoxColumn colNgayLap = new DataGridViewTextBoxColumn();
            colNgayLap.DataPropertyName = "NgayLap";
            colNgayLap.HeaderText = "Ngày lập";
            dataGridView.Columns.Add(colNgayLap);

            DataGridViewTextBoxColumn colMaKH = new DataGridViewTextBoxColumn();
            colMaKH.DataPropertyName = "MaKhachHang";
            colMaKH.HeaderText = "Mã khách hàng";
            dataGridView.Columns.Add(colMaKH);

            DataGridViewTextBoxColumn colTenKH = new DataGridViewTextBoxColumn();
            colTenKH.DataPropertyName = "TenKhachHang"; 
            colTenKH.HeaderText = "Tên khách hàng";
            dataGridView.Columns.Add(colTenKH);

            DataGridViewTextBoxColumn colSDT = new DataGridViewTextBoxColumn();
            colSDT.DataPropertyName = "SoDienThoai"; 
            colSDT.HeaderText = "Số điện thoại";
            dataGridView.Columns.Add(colSDT);

            DataGridViewTextBoxColumn colTenNV = new DataGridViewTextBoxColumn();
            colTenNV.DataPropertyName = "TenNhanVien";
            colTenNV.HeaderText = "Tên nhân viên";
            dataGridView.Columns.Add(colTenNV);

            DataGridViewTextBoxColumn colHinhThucTT = new DataGridViewTextBoxColumn();
            colHinhThucTT.DataPropertyName = "HinhThucThanhToan";
            colHinhThucTT.HeaderText = "Hình thức thanh toán";
            dataGridView.Columns.Add(colHinhThucTT);

            DataGridViewTextBoxColumn colTongTien = new DataGridViewTextBoxColumn();
            colTongTien.DataPropertyName = "TongTien";
            colTongTien.HeaderText = "Tổng tiền";
            dataGridView.Columns.Add(colTongTien);

            dataGridView.ReadOnly = true;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.SelectionChanged += dataGridView_SelectionChanged;
        }
       
    }
}
