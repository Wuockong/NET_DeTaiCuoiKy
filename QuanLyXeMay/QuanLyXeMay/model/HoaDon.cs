using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyXeMay.model
{
    class HoaDon
    {
        public int MaHoaDon { get; set; }
        public DateTime NgayLap {get; set;}
        public int MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public int MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public int TongTien {get; set;}
        public string HinhThucThanhToan { get; set; }
    }
}
