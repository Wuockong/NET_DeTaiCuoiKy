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
    public partial class QLBanHang : Form
    {
        // Khai báo các control như là fields để có thể truy cập chúng từ nhiều phương thức
        private TextBox txtTenSP, txtDonGia, txtSoLuong, txtSearch, txtSL1;
        private Label lblHinhAnh;
        private ComboBox cbxLoaiSP, cbxLoaiSPList;
        FlowLayoutPanel flowLayout, flowLayoutTop, flowLayoutTopLeft, flowLayoutTopRight, flowLayoutBottom, flowLayoutSearchBar;
        PictureBox avtSanPham;
        DataGridView dataGridView;
        Button btnThoat, btnSearch, btnPrev, btnNext, btnBanHang, btnThemGioHang, btnThanhToan;
        private SanPhamDAO sanPhamDAO;
        SanPham sanPham;
        int idSelected = 0;
        int page = 1;
        int size = 10;
        List<SanPhamItemBH> listSanPhamItem;
        List<TextBox> listTxtSoLuong;
        public QLBanHang(int maSanPham)
        {
            sanPhamDAO = new SanPhamDAO();
            listSanPhamItem = new List<SanPhamItemBH>();
            listTxtSoLuong = new List<TextBox>();
            InitializeComponent();
            sanPham = sanPhamDAO.GetSanPhamById(maSanPham);
            this.Load += new EventHandler(QLBanHang_Load);
            this.SizeChanged += new EventHandler(QLBanHang_SizeChanged);
        }

        private void QLBanHang_Load(object sender, EventArgs e)
        {
            //INIT VIEW
            LoaiSPDAO loaiSpDao = new LoaiSPDAO();
            btnThoat = new Button();
            btnPrev = new Button();
            btnNext = new Button();
            btnSearch = new Button();
            btnBanHang = new Button();
            btnThemGioHang = new Button();
            btnThanhToan = new Button();
            txtTenSP = new TextBox();
            txtDonGia = new TextBox();
            txtSoLuong = new TextBox();
            txtSearch = new TextBox();
            txtSL1 = new TextBox();
            cbxLoaiSP = new ComboBox();
            cbxLoaiSPList = new ComboBox();
            lblHinhAnh = CreateView.CreateLabel("");

            this.Text = "Xemaytot.com | Quản lý bán hàng";
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
            flowLayoutTopRight.AutoScroll = true;
            flowLayoutTopRight.WrapContents = false;

            avtSanPham = new PictureBox();
            //avtSanPham.Image = Image.FromFile("images\\" + "exciter.jpg");
            avtSanPham.SizeMode = PictureBoxSizeMode.Zoom;

            flowLayoutTopLeft.Controls.Add(avtSanPham);

            flowLayoutTop.Controls.Add(flowLayoutTopLeft);
            flowLayoutTop.Controls.Add(flowLayoutTopRight);
            flowLayoutBottom = new FlowLayoutPanel();
            flowLayoutSearchBar = CreateView.CreateFlowRightToLeft();
            flowLayoutSearchBar.Size = new Size(500, 40);

            flowLayoutTopRight.Controls.Add(createItemGioHang(sanPham));


            CreateView.CreateButton("<", btnPrev);
            CreateView.CreateButton(">", btnNext);
            CreateView.CreateButton("Thêm vào giỏ", btnThemGioHang);
            CreateView.CreateButton("Thanh toán", btnThanhToan);
            btnPrev.Size = new Size(50, 30);
            btnNext.Size = new Size(50, 30);
            btnNext.Margin = new Padding(0, 3, 5, 0);
            btnPrev.Click += new EventHandler(btnPrev_Click);
            btnNext.Click += new EventHandler(btnNext_Click);

            txtSearch.Font = new Font(txtSearch.Font.FontFamily, 12);
            txtSearch.Size = new Size(250, 30);
            txtSearch.Margin = new Padding(5, 5, 0, 0);
            CreateView.CreateButton("Tìm kiếm", btnSearch);
            btnSearch.Click += btnSearch_Click;
            CreateView.CreateComboBoxLoaiSPNoLabel(cbxLoaiSPList, loaiSpDao.GetAllLoaiSP());
            cbxLoaiSPList.SelectedIndexChanged += cbxLoaiSPList_SelectedIndexChanged;

            flowLayoutSearchBar.Controls.Add(btnSearch);
            flowLayoutSearchBar.Controls.Add(txtSearch);
            flowLayoutSearchBar.Controls.Add(cbxLoaiSPList);
            flowLayoutSearchBar.Controls.Add(btnNext);
            flowLayoutSearchBar.Controls.Add(btnPrev);
            flowLayoutSearchBar.Controls.Add(btnThemGioHang);
            flowLayoutSearchBar.Controls.Add(btnThanhToan);
            flowLayoutBottom.Controls.Add(flowLayoutSearchBar);
            btnThemGioHang.Click += btnThemGioHang_Click;
            btnThanhToan.Click += btnThanhToan_Click;

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

        private FlowLayoutPanel createItemGioHang(SanPham sp)
        {
            foreach(SanPhamItemBH item in listSanPhamItem)
            {
                if (item.MaSanPham == sp.MaSanPham)
                {
                    MessageBox.Show("Sản phẩm đã có trong giỏ hàng");
                    return null;
                }
            }
            TextBox txtSoLuong = new TextBox();
            FlowLayoutPanel flowLayout = CreateView.CreateFlowTopDown();
            FlowLayoutPanel flowLayoutSL = CreateView.CreateFlowLeftToRight();
            flowLayout.Width = 500;
            flowLayout.Height = 150;
            flowLayoutSL.Width = 500;
            flowLayoutSL.Height = 50;
            Button btnRemove = new Button();
            CreateView.CreateButton("Xóa", btnRemove);

            flowLayout.Controls.Add(CreateView.CreateLabelInfo("Tên sản phẩm:", sp.TenSanPham + " (" + sanPham.TenLoaiSP + ")"));
            flowLayout.Controls.Add(CreateView.CreateLabelInfo("Đơn giá:", sp.DonGia.ToString()));
            flowLayoutSL.Controls.Add(CreateView.CreateInput("Số lượng:", txtSoLuong, btnRemove));
            flowLayout.Controls.Add(flowLayoutSL);
            txtSoLuong.Text = "1";
            txtSoLuong.Size = new Size(100, 30);
            listTxtSoLuong.Add(txtSoLuong);


            SanPhamItemBH sanPhamItem = new SanPhamItemBH
            {
                MaSanPham = sp.MaSanPham,
                TenSanPham = sp.TenSanPham,
                DonGia = sp.DonGia,
                SoLuong = 1,
                HinhAnh = sp.HinhAnh
            };
            btnRemove.Click += (sender, e) =>
            {
                FlowLayoutPanel parentFlow = (FlowLayoutPanel)flowLayout.Parent;
                listSanPhamItem.Remove(sanPhamItem);
                listTxtSoLuong.Remove(txtSoLuong);
                parentFlow.Controls.Remove(flowLayout);
            };

            listSanPhamItem.Add(sanPhamItem);
            return flowLayout;
        }

        private void btnThemGioHang_Click(object sender, EventArgs e)
        {
            SanPham sp = sanPhamDAO.GetSanPhamById(idSelected);
            FlowLayoutPanel flowItem = createItemGioHang(sp);
            if (flowItem != null)
            {
                flowLayoutTopRight.Controls.Add(flowItem);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (listSanPhamItem.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < listTxtSoLuong.Count; i++)
            {
                int soluong = 1;
                if (!int.TryParse(listTxtSoLuong[i].Text, out soluong))
                {
                    MessageBox.Show("Số lượng không hợp lệ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (soluong < 1)
                {
                    MessageBox.Show("Số lượng không hợp lệ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                listSanPhamItem[i].SoLuong = soluong;
            }
            QLThanhToan menuForm = new QLThanhToan(listSanPhamItem);
            menuForm.Show();
            this.Hide();
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            QLBanHang menuForm = new QLBanHang(idSelected);
            menuForm.Show();
            this.Hide();
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
            string selectedValue = cbxLoaiSPList.SelectedValue.ToString();
            int maLoaiSP = 0;
            int.TryParse(selectedValue, out maLoaiSP);
            List<SanPham> listSP = sanPhamDAO.GetByKeyword(keyword, maLoaiSP, page, size);
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
            string selectedValue = cbxLoaiSPList.SelectedValue.ToString();
            int maLoaiSP = 0;
            int.TryParse(selectedValue, out maLoaiSP);
            List<SanPham> listSP = sanPhamDAO.GetByKeyword(keyword, maLoaiSP, page, size);
            if (listSP.Count > 0)
            {
                dataGridView.DataSource = listSP;
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
            string selectedValue = cbxLoaiSPList.SelectedValue.ToString();
            int maLoaiSP = 0;
            int.TryParse(selectedValue, out maLoaiSP);
            List<SanPham> listSP = sanPhamDAO.GetByKeyword(keyword, maLoaiSP, page, size);
            if (listSP.Count > 0)
            {
                dataGridView.DataSource = listSP;
            }
            else
            {
                page -= 1;
            }
        }

        private void cbxLoaiSPList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Xử lý sự kiện thay đổi trong ComboBox ở đây
            if (cbxLoaiSPList.SelectedItem != null)
            {
                page = 1;
                // Lấy giá trị đã chọn
                string keyword = txtSearch.Text;
                string selectedValue = cbxLoaiSPList.SelectedValue.ToString();
                int maLoaiSP = 0;
                int.TryParse(selectedValue, out maLoaiSP);
                List<SanPham> listSP = sanPhamDAO.GetByKeyword(keyword, maLoaiSP, page, size);
                dataGridView.DataSource = listSP;
            }
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Lấy dòng đầu tiên được chọn (nếu có)
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                string maSPStr = selectedRow.Cells[0].Value.ToString();
                int maSP = 0;
                int.TryParse(maSPStr, out maSP);
                idSelected = maSP;
                // Lấy giá trị từ các ô trong dòng được chọn
                txtTenSP.Text = selectedRow.Cells[1].Value.ToString();
                txtDonGia.Text = selectedRow.Cells[2].Value.ToString();
                txtSoLuong.Text = selectedRow.Cells[3].Value.ToString();
                cbxLoaiSP.SelectedIndex = cbxLoaiSP.FindStringExact(selectedRow.Cells[6].Value.ToString());
                string hinhAnh = selectedRow.Cells[7].Value.ToString();
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
            string tenSP = txtTenSP.Text;
            int donGia = 0;
            int soLuong = 0;
            if (tenSP.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(txtDonGia.Text, out donGia))
            {
                MessageBox.Show("Đơn giá không hợp lệ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(txtSoLuong.Text, out soLuong))
            {
                MessageBox.Show("Số lượng không hợp lệ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string path = lblHinhAnh.Text;
            if (path == "")
            {
                MessageBox.Show("Vui lòng chọn ảnh cho sản phẩm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string fileName = GenerateRandomFileName();

            var selectedValue = cbxLoaiSP.SelectedValue;

            string loaisp = "";
            // Kiểm tra null trước khi sử dụng để tránh lỗi NullReferenceException
            if (selectedValue != null)
            {
                loaisp = selectedValue.ToString();
            }
            int maLoaiSP = 1;
            if (!int.TryParse(loaisp, out maLoaiSP))
            {
                MessageBox.Show("Loại sản phẩm không hợp lệ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (storageImage(path, fileName))
            {
                sanPhamDAO.InsertSanPham(tenSP, donGia, soLuong, maLoaiSP, fileName);
                string selectedValueSearch = cbxLoaiSPList.SelectedValue.ToString();
                int maLoaiSPList = 0;
                int.TryParse(selectedValueSearch, out maLoaiSPList);
                List<SanPham> listSP = sanPhamDAO.GetByKeyword(txtSearch.Text, maLoaiSPList, page, size);
                dataGridView.DataSource = listSP;
                MessageBox.Show("Thêm sản phẩm thành công");
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            string tenSP = txtTenSP.Text;
            int donGia = 0;
            int soLuong = 0;
            if (tenSP.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(txtDonGia.Text, out donGia))
            {
                MessageBox.Show("Đơn giá không hợp lệ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(txtSoLuong.Text, out soLuong))
            {
                MessageBox.Show("Số lượng không hợp lệ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string path = lblHinhAnh.Text;
            string fileName;


            var selectedValue = cbxLoaiSP.SelectedValue;

            string loaisp = "";
            // Kiểm tra null trước khi sử dụng để tránh lỗi NullReferenceException
            if (selectedValue != null)
            {
                loaisp = selectedValue.ToString();
            }
            int maLoaiSP = 1;
            if (!int.TryParse(loaisp, out maLoaiSP))
            {
                MessageBox.Show("Loại sản phẩm không hợp lệ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (path == "")
            {
                SanPham sanPhamOld = sanPhamDAO.GetSanPhamById(idSelected);
                fileName = sanPhamOld.HinhAnh;
            }
            else
            {
                fileName = GenerateRandomFileName();
                storageImage(path, fileName);
            }

            sanPhamDAO.UpdateSanPham(idSelected, tenSP, donGia, soLuong, maLoaiSP, fileName);
            string selectedValueSearch = cbxLoaiSPList.SelectedValue.ToString();
            int maLoaiSPList = 0;
            int.TryParse(selectedValueSearch, out maLoaiSPList);
            List<SanPham> listSP = sanPhamDAO.GetByKeyword(txtSearch.Text, maLoaiSPList, page, size);
            dataGridView.DataSource = listSP;
            MessageBox.Show("Sửa thông tin sản phẩm thành công");
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            sanPhamDAO.XoaSanPham(idSelected);
            string selectedValueSearch = cbxLoaiSPList.SelectedValue.ToString();
            int maLoaiSPList = 0;
            int.TryParse(selectedValueSearch, out maLoaiSPList);
            List<SanPham> listSP = sanPhamDAO.GetByKeyword(txtSearch.Text, maLoaiSPList, page, size);
            dataGridView.DataSource = listSP;
            MessageBox.Show("Xóa sản phẩm thành công");
        }

        public string GenerateRandomFileName()
        {
            // Sử dụng hàm Path.GetRandomFileName để tạo chuỗi ngẫu nhiên
            string randomFileName = Path.GetRandomFileName();

            // Loại bỏ ký tự không hợp lệ trong tên tệp tin
            randomFileName = randomFileName.Replace(".", "");

            return randomFileName;
        }

        private bool storageImage(string imagePath, string fileName)
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

        private void QLBanHang_SizeChanged(object sender, EventArgs e)
        {
            UpdateControlsPosition();
        }

        private void UpdateControlsPosition()
        {
            flowLayout.Width = this.ClientSize.Width;
            flowLayout.Height = this.ClientSize.Height;
            flowLayoutTop.Width = this.flowLayout.Width;
            flowLayoutTop.Height = this.flowLayout.Height / 2 - 20;
            flowLayoutTopLeft.Width = flowLayoutTop.Width / 2;
            flowLayoutTopLeft.Height = flowLayoutTop.Height;
            flowLayoutTopRight.Width = flowLayoutTop.Width / 2 - 20;
            flowLayoutTopRight.Height = flowLayoutTop.Height;
            flowLayoutBottom.Width = this.flowLayout.Width;
            flowLayoutBottom.Height = this.flowLayout.Height / 2 - 60;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.Width = this.flowLayoutBottom.Width;
            dataGridView.Height = this.flowLayoutBottom.Height;
            avtSanPham.Width = this.flowLayoutTopLeft.Width;
            avtSanPham.Height = this.flowLayoutTopLeft.Height;
            flowLayoutSearchBar.Width = flowLayout.Width - 20;
        }
        private void DisplayProductList()
        {
            List<SanPham> listSP = sanPhamDAO.GetAllSanPham(page, size);
            dataGridView.DataSource = listSP;
            string projectPath = System.IO.Directory.GetCurrentDirectory(); // Đường dẫn thư mục hiện tại của dự án
            string targetDirectory = Path.Combine(projectPath, "image_upload");
            if (sanPham.HinhAnh != "")
            {
                avtSanPham.Image = Image.FromFile(targetDirectory + "\\" + sanPham.HinhAnh + ".jpg");
            }
        }

        private void setupGridDataView()
        {
            // Thêm cột cho DataGridView
            DataGridViewTextBoxColumn colMaSP = new DataGridViewTextBoxColumn();
            colMaSP.DataPropertyName = "MaSanPham"; // Liên kết với thuộc tính MaSanPham của class SanPham
            colMaSP.HeaderText = "Mã sản phẩm";

            // Thêm cột cho DataGridView
            DataGridViewTextBoxColumn colTenSP = new DataGridViewTextBoxColumn();
            colTenSP.DataPropertyName = "TenSanPham"; // Liên kết với thuộc tính TenSanPham của class SanPham
            colTenSP.HeaderText = "Tên sản phẩm";

            DataGridViewTextBoxColumn colDonGia = new DataGridViewTextBoxColumn();
            colDonGia.DataPropertyName = "DonGia"; // Liên kết với thuộc tính DonGia của class SanPham
            colDonGia.HeaderText = "Đơn giá";

            DataGridViewTextBoxColumn colSoLuong = new DataGridViewTextBoxColumn();
            colSoLuong.DataPropertyName = "SoLuong"; // Liên kết với thuộc tính SoLuong của class SanPham
            colSoLuong.HeaderText = "Số lượng";

            DataGridViewTextBoxColumn colMaLoaiSP = new DataGridViewTextBoxColumn();
            colMaLoaiSP.DataPropertyName = "MaLoaiSP"; // Liên kết với thuộc tính TenLoaiSP của class SanPham
            colMaLoaiSP.HeaderText = "Mã loại sản phẩm";

            // Thêm cột TenLoaiSP nếu muốn hiển thị
            DataGridViewTextBoxColumn colTenLoaiSP = new DataGridViewTextBoxColumn();
            colTenLoaiSP.DataPropertyName = "TenLoaiSP"; // Liên kết với thuộc tính TenLoaiSP của class SanPham
            colTenLoaiSP.HeaderText = "Tên loại sản phẩm";

            DataGridViewTextBoxColumn colHinhAnh = new DataGridViewTextBoxColumn();
            colHinhAnh.DataPropertyName = "HinhAnh"; // Liên kết với thuộc tính TenLoaiSP của class SanPham
            colHinhAnh.HeaderText = "Hình ảnh";

            DataGridViewTextBoxColumn colTrangThai = new DataGridViewTextBoxColumn();
            colTrangThai.DataPropertyName = "TrangThai"; // Liên kết với thuộc tính TenLoaiSP của class SanPham
            colTrangThai.HeaderText = "Trạng thái";

            // Thêm các cột vào DataGridView
            dataGridView = new DataGridView();
            dataGridView.ReadOnly = true;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.Columns.Add(colMaSP);
            dataGridView.Columns.Add(colTenSP);
            dataGridView.Columns.Add(colDonGia);
            dataGridView.Columns.Add(colSoLuong);
            dataGridView.Columns.Add(colMaLoaiSP);
            dataGridView.Columns.Add(colTenLoaiSP);
            dataGridView.Columns.Add(colHinhAnh);
            dataGridView.Columns.Add(colTrangThai);
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.SelectionChanged += dataGridView_SelectionChanged;
        }

    }
}
