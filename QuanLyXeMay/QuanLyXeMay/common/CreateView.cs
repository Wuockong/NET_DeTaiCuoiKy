using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using QuanLyXeMay.model;
namespace QuanLyXeMay.common
{
    class CreateView
    {
        static public Button CreateButton(string title,Button btn)
        {
            btn.Text = title;
            btn.Size = new Size(130, 30);
            btn.Font = new Font(btn.Font.FontFamily, 12);
            return btn;
        }
        static public Label CreateLabel(string labelTitle)
        {
            Label labelUsername = new Label();
            labelUsername.Text = labelTitle;
            labelUsername.Font = new Font(labelUsername.Font.FontFamily, 12);
            labelUsername.AutoSize = true;
            return labelUsername;
        }

        static public FlowLayoutPanel CreateFlowTopDown()
        {
            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.FlowDirection = FlowDirection.TopDown;
            return flow;
        }

        static public FlowLayoutPanel CreateFlowLeftToRight()
        {
            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.FlowDirection = FlowDirection.LeftToRight;
            return flow;
        }

        static public FlowLayoutPanel CreateFlowRightToLeft()
        {
            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.FlowDirection = FlowDirection.RightToLeft;
            return flow;
        }

        static public FlowLayoutPanel CreateInput(string labelTitle, TextBox txt)
        {
            FlowLayoutPanel flowLayout = CreateFlowLeftToRight();
            flowLayout.Size = new Size(620,30);
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Padding = new Padding(0, 5, 0, 0);
            panel.Size = new Size(150, 30);
            Label lbl = CreateLabel(labelTitle);
            lbl.Font = new Font(lbl.Font.FontFamily, 12);
            txt.Size = new Size(450, 30);
            txt.Margin = new Padding(0, 5, 0, 0);
            txt.Font = new Font(txt.Font.FontFamily, 12);
            panel.Controls.Add(lbl);
            flowLayout.Controls.Add(panel);
            flowLayout.Controls.Add(txt);
            return flowLayout;
        }

        static public FlowLayoutPanel CreateInput(string labelTitle, TextBox txt, Button btn)
        {
            FlowLayoutPanel flowLayout = CreateFlowLeftToRight();
            flowLayout.Size = new Size(620, 35);
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Padding = new Padding(0, 5, 0, 0);
            panel.Size = new Size(150, 30);
            Label lbl = CreateLabel(labelTitle);
            lbl.Font = new Font(lbl.Font.FontFamily, 12);
            txt.Size = new Size(450, 30);
            txt.Margin = new Padding(0, 5, 0, 0);
            txt.Font = new Font(txt.Font.FontFamily, 12);
            panel.Controls.Add(lbl);
            flowLayout.Controls.Add(panel);
            flowLayout.Controls.Add(txt);
            flowLayout.Controls.Add(CreateButton("Xóa", btn));
            return flowLayout;
        }

        static public FlowLayoutPanel CreateLabelInfo(string labelTitle, string labelValue)
        {
            FlowLayoutPanel flowLayout = CreateFlowLeftToRight();
            flowLayout.Size = new Size(620, 30);
            FlowLayoutPanel panel = new FlowLayoutPanel();
            FlowLayoutPanel panelValue = new FlowLayoutPanel();
            panel.Padding = new Padding(0, 5, 0, 0);
            panel.Size = new Size(150, 30);
            panelValue.Padding = new Padding(0, 5, 0, 0);
            panelValue.Size = new Size(450, 30);
            Label lbl = CreateLabel(labelTitle);
            lbl.ForeColor = Color.Blue;
            lbl.Font = new Font(lbl.Font.FontFamily, 12, FontStyle.Bold);

            Label lblValue = CreateLabel(labelValue);
            lblValue.Font = new Font(lblValue.Font.FontFamily, 12);
            panel.Controls.Add(lbl);
            panelValue.Controls.Add(lblValue);
            flowLayout.Controls.Add(panel);
            flowLayout.Controls.Add(panelValue);
            return flowLayout;
        }

        static public FlowLayoutPanel CreateLabelInfo(string labelTitle, Label lblValue)
        {
            FlowLayoutPanel flowLayout = CreateFlowLeftToRight();
            flowLayout.Size = new Size(620, 30);
            FlowLayoutPanel panel = new FlowLayoutPanel();
            FlowLayoutPanel panelValue = new FlowLayoutPanel();
            panel.Padding = new Padding(0, 5, 0, 0);
            panel.Size = new Size(150, 30);
            panelValue.Padding = new Padding(0, 5, 0, 0);
            panelValue.Size = new Size(450, 30);
            Label lbl = CreateLabel(labelTitle);
            lbl.ForeColor = Color.Blue;
            lbl.Font = new Font(lbl.Font.FontFamily, 12, FontStyle.Bold);

            lblValue.Font = new Font(lblValue.Font.FontFamily, 12);
            panel.Controls.Add(lbl);
            panelValue.Controls.Add(lblValue);
            flowLayout.Controls.Add(panel);
            flowLayout.Controls.Add(panelValue);
            return flowLayout;
        }

        static public FlowLayoutPanel CreateRadioButtons(string labelTitle, RadioButton maleRadioButton, RadioButton femaleRadioButton)
        {
            FlowLayoutPanel flowLayout = CreateFlowLeftToRight();
            flowLayout.Size = new Size(620, 30); // Đã điều chỉnh kích thước để chứa nút radio

            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Padding = new Padding(0, 5, 0, 0);
            panel.Size = new Size(150, 30); // Đã điều chỉnh kích thước để chứa nút radio

            Label lbl = CreateLabel(labelTitle);
            lbl.Font = new Font(lbl.Font.FontFamily, 12);

            maleRadioButton.Text = "Nam";
            maleRadioButton.Font = new Font(maleRadioButton.Font.FontFamily, 12);

            femaleRadioButton.Text = "Nữ";
            femaleRadioButton.Font = new Font(femaleRadioButton.Font.FontFamily, 12);

            panel.Controls.Add(lbl);
            flowLayout.Controls.Add(panel);
            flowLayout.Controls.Add(maleRadioButton);
            flowLayout.Controls.Add(femaleRadioButton);

            maleRadioButton.Checked = true;

            return flowLayout;
        }

        static public FlowLayoutPanel CreateDateInput(string labelTitle, DateTimePicker dateTimePicker)
        {
            FlowLayoutPanel flowLayout = CreateFlowLeftToRight();
            flowLayout.Size = new Size(620, 30); // Đã điều chỉnh kích thước để chứa DateTimePicker

            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Padding = new Padding(0, 5, 0, 0);
            panel.Size = new Size(150, 30); // Đã điều chỉnh kích thước để chứa DateTimePicker

            Label lbl = CreateLabel(labelTitle);
            lbl.Font = new Font(lbl.Font.FontFamily, 12);

            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "dd/MM/yyyy"; // Định dạng ngày tháng
            dateTimePicker.Font = new Font(dateTimePicker.Font.FontFamily, 12);

            panel.Controls.Add(lbl);
            flowLayout.Controls.Add(panel);
            flowLayout.Controls.Add(dateTimePicker);

            return flowLayout;
        }


        static public FlowLayoutPanel CreateComboBoxLoaiSP(string labelTitle, ComboBox comboBox, List<LoaiSP> listItem)
        {
            FlowLayoutPanel flowLayout = CreateFlowLeftToRight();
            flowLayout.Size = new Size(620, 30);

            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Padding = new Padding(0, 5, 0, 0);
            panel.Size = new Size(150, 30);

            Label lbl = CreateLabel(labelTitle);
            lbl.Font = new Font(lbl.Font.FontFamily, 12);

            comboBox.Size = new Size(450, 30);
            comboBox.Margin = new Padding(0, 5, 0, 0);
            comboBox.Font = new Font(comboBox.Font.FontFamily, 12);

            List<ComboBoxItem> items = new List<ComboBoxItem>();
            // Thêm các item mẫu (bạn có thể thay thế bằng dữ liệu thực từ nguồn dữ liệu của bạn)
            foreach (LoaiSP item in listItem)
            {
                ComboBoxItem cbxItem = new ComboBoxItem();
                cbxItem.Value = item.MaLoaiSP;
                cbxItem.Text = item.TenLoaiSP;
                items.Add(cbxItem);
            }
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.DisplayMember = "Text";
            comboBox.ValueMember = "Value";
            comboBox.DataSource = items;

            panel.Controls.Add(lbl);
            flowLayout.Controls.Add(panel);
            flowLayout.Controls.Add(comboBox);
            return flowLayout;
        }

        static public void CreateComboBoxLoaiSPNoLabel(ComboBox comboBox, List<LoaiSP> listItem)
        {
            comboBox.Size = new Size(150, 30);
            comboBox.Margin = new Padding(0, 4, 0, 0);
            comboBox.Font = new Font(comboBox.Font.FontFamily, 12);

            List<ComboBoxItem> items = new List<ComboBoxItem>();
            ComboBoxItem cbxItemAll = new ComboBoxItem();
            cbxItemAll.Value = 0;
            cbxItemAll.Text = "Tất cả";
            items.Add(cbxItemAll);
            foreach (LoaiSP item in listItem)
            {
                ComboBoxItem cbxItem = new ComboBoxItem();
                cbxItem.Value = item.MaLoaiSP;
                cbxItem.Text = item.TenLoaiSP;
                items.Add(cbxItem);
            }
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.DisplayMember = "Text";
            comboBox.ValueMember = "Value";
            comboBox.DataSource = items;
        }

        static public void CreateComboBoxCustom(ComboBox comboBox, List<ComboBoxItem> listItem)
        {
            comboBox.Size = new Size(150, 30);
            comboBox.Margin = new Padding(0, 4, 0, 0);
            comboBox.Font = new Font(comboBox.Font.FontFamily, 12);

            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.DisplayMember = "Text";
            comboBox.ValueMember = "Value";
            comboBox.DataSource = listItem;
        }

        static public FlowLayoutPanel CreateFileInput(string labelTitle, Label txt, PictureBox avtSanPham)
        {
            FlowLayoutPanel flowLayout = CreateFlowLeftToRight();
            flowLayout.Size = new Size(620, 35);

            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Padding = new Padding(0, 5, 0, 0);
            panel.Size = new Size(150, 30);

            Label lbl = CreateLabel(labelTitle);
            lbl.Font = new Font(lbl.Font.FontFamily, 12);

            txt.Padding = new Padding(0, 5, 0, 0);
            // Sử dụng Button thay vì TextBox
            Button btnBrowse = new Button();
            btnBrowse.Text = "Chọn File";
            btnBrowse.Size = new Size(150, 30);
            btnBrowse.Font = new Font(btnBrowse.Font.FontFamily, 12);
            btnBrowse.Click += (sender, e) => { OpenFile(txt, avtSanPham); }; // Khi nhấp vào nút, mở OpenFileDialog

            panel.Controls.Add(lbl);
            flowLayout.Controls.Add(panel);
            flowLayout.Controls.Add(btnBrowse);
            flowLayout.Controls.Add(txt);

            return flowLayout;
        }

        static private void OpenFile(Label txt, PictureBox pictureBox)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn File";
                openFileDialog.Filter = "Tất cả các tệp (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn của tệp tin đã chọn và hiển thị trong TextBox
                    string selectedFilePath = openFileDialog.FileName;
                    txt.Text = selectedFilePath;
                    try
                    {
                        // Load ảnh từ đường dẫn vào PictureBox
                        pictureBox.Image = Image.FromFile(selectedFilePath);
                    }
                    catch (Exception ex)
                    {
                        // Xử lý nếu có lỗi khi load ảnh
                        MessageBox.Show("Không thể mở ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}
