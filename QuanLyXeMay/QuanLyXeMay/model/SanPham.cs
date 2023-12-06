using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyXeMay.model
{
    class SanPham
    {
        public int MaSanPham { get; set; }
        public string TenSanPham {get; set;}
        public int DonGia {get; set;}
        public int SoLuong {get; set;}
        public string TrangThai {get; set;}
        public int MaLoaiSP { get; set; }
        public string TenLoaiSP { get; set; }
        public string HinhAnh { get; set; }
    }
}
