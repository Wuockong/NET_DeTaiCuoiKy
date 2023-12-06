using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using QuanLyXeMay.model;
namespace QuanLyXeMay.dao
{
    class HoaDonDAO
    {
        private string _connectionString;
        public HoaDonDAO()
        {
            _connectionString = DataSourceProvider.CONNECT_STRING;
        }

        public List<SanPhamItemBH> GetCTHDByMaHD(int maHD)
        {
            List<SanPhamItemBH> listCTHD = new List<SanPhamItemBH>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT ct.ma_hoa_don, ct.ten_san_pham, ct.don_gia, ct.so_luong, ct.hinh_anh FROM chitiethoadon ct WHERE ct.ma_hoa_don = @ma_hoa_don;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ma_hoa_don", maHD);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listCTHD.Add(new SanPhamItemBH
                            {
                                MaSanPham = Convert.ToInt32(reader["ma_hoa_don"]),
                                TenSanPham = reader["ten_san_pham"].ToString(),
                                DonGia = Convert.ToInt32(reader["don_gia"].ToString()),
                                SoLuong = Convert.ToInt32(reader["so_luong"].ToString()),
                                HinhAnh = reader["hinh_anh"].ToString(),
                            });
                        }
                    }
                }
            }

            return listCTHD;
        }

        public List<HoaDon> GetAllHoaDon()
        {
            List<HoaDon> listHoaDon = new List<HoaDon>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT hd.ma_hoa_don, hd.ngay_lap, hd.ma_khach_hang, kh.ten_nguoi_dung as ten_khach_hang, kh.so_dien_thoai, hd.ma_nhan_vien, nv.ten_nguoi_dung as ten_nhan_vien, hd.tong_tien, hd.hinh_thuc_thanh_toan FROM hoadon hd JOIN nguoidung kh ON kh.ma_nguoi_dung = hd.ma_khach_hang JOIN nguoidung nv ON nv.ma_nguoi_dung = hd.ma_nhan_vien;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string ngayLapString = reader["ngay_lap"].ToString();
                            DateTime ngayLapDate = new DateTime();
                            DateTime.TryParse(ngayLapString, out ngayLapDate);
                            listHoaDon.Add(new HoaDon
                            {
                                MaHoaDon = Convert.ToInt32(reader["ma_hoa_don"]),
                                NgayLap = ngayLapDate,
                                MaKhachHang = Convert.ToInt32(reader["ma_khach_hang"].ToString()),
                                TenKhachHang = reader["ten_khach_hang"].ToString(),
                                SoDienThoai = reader["so_dien_thoai"].ToString(),
                                MaNhanVien = Convert.ToInt32(reader["ma_nhan_vien"]),
                                TenNhanVien = reader["ten_nhan_vien"].ToString(),
                                TongTien = Convert.ToInt32(reader["tong_tien"]),
                                HinhThucThanhToan = reader["hinh_thuc_thanh_toan"].ToString(),
                            });
                        }
                    }
                }
            }

            return listHoaDon;
        }

        public List<HoaDon> GetHoaDonByKeyword(string keyword, int loaiSearch, string vaitro, int page, int size)
        {
            List<HoaDon> listHoaDon = new List<HoaDon>();
            int offset = (page - 1) * size;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT hd.ma_hoa_don, hd.ngay_lap, hd.ma_khach_hang, kh.ten_nguoi_dung as ten_khach_hang, kh.so_dien_thoai, hd.ma_nhan_vien, nv.ten_nguoi_dung as ten_nhan_vien, hd.tong_tien, hd.hinh_thuc_thanh_toan FROM hoadon hd JOIN nguoidung kh ON kh.ma_nguoi_dung = hd.ma_khach_hang JOIN nguoidung nv ON nv.ma_nguoi_dung = hd.ma_nhan_vien WHERE kh.trang_thai = 'ACTIVE' AND kh.vai_tro = @vai_tro";
                if (loaiSearch <= 0)
                {
                    query += " AND kh.ten_nguoi_dung LIKE @keyword";
                }
                if (loaiSearch == 1)
                {
                    query += " AND kh.so_dien_thoai LIKE @keyword";
                }
                if (loaiSearch == 2)
                {
                    query += " AND kh.ten_dang_nhap LIKE @keyword";
                }
                if (loaiSearch == 3)
                {
                    query += " AND kh.email LIKE @keyword";
                }
                query += " ORDER BY hd.ma_hoa_don DESC OFFSET @offset ROWS FETCH NEXT @size ROWS ONLY";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    command.Parameters.AddWithValue("@ma_loai_sp", loaiSearch);
                    command.Parameters.AddWithValue("@vai_tro", vaitro);
                    command.Parameters.AddWithValue("@size", size);
                    command.Parameters.AddWithValue("@offset", offset);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string ngayLapString = reader["ngay_lap"].ToString();
                            DateTime ngayLapDate = new DateTime();
                            DateTime.TryParse(ngayLapString, out ngayLapDate);
                            listHoaDon.Add(new HoaDon
                            {
                                MaHoaDon = Convert.ToInt32(reader["ma_hoa_don"]),
                                NgayLap = ngayLapDate,
                                MaKhachHang = Convert.ToInt32(reader["ma_khach_hang"].ToString()),
                                TenKhachHang = reader["ten_khach_hang"].ToString(),
                                SoDienThoai = reader["so_dien_thoai"].ToString(),
                                MaNhanVien = Convert.ToInt32(reader["ma_nhan_vien"]),
                                TenNhanVien = reader["ten_nhan_vien"].ToString(),
                                TongTien = Convert.ToInt32(reader["tong_tien"]),
                                HinhThucThanhToan = reader["hinh_thuc_thanh_toan"].ToString(),
                            });
                        }
                    }
                }
            }

            return listHoaDon;
        }

        public int InsertHoaDon(int maKH, int maNV, int tongTien)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO hoadon (ma_khach_hang, ma_nhan_vien, tong_tien) " +
                               "VALUES (@ma_khach_hang, @ma_nhan_vien, @tong_tien); " +
                               "SELECT SCOPE_IDENTITY();";  // Lấy mã hóa đơn vừa thêm

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ma_khach_hang", maKH);
                    command.Parameters.AddWithValue("@ma_nhan_vien", maNV);
                    command.Parameters.AddWithValue("@tong_tien", tongTien);
                    connection.Open();

                    // Thực hiện lệnh INSERT và lấy giá trị của mã hóa đơn vừa thêm
                    int maHoaDon = Convert.ToInt32(command.ExecuteScalar());

                    return maHoaDon;
                }
            }
        }


        public void InsertCTHoaDon(int maHD, int maSP, string tenSP, int soLuong, int donGia, int thanhTien, string hinhAnh)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO chitiethoadon (ma_san_pham, ma_hoa_don, ten_san_pham, so_luong, don_gia, thanh_tien, hinh_anh) " +
                               "VALUES (@ma_san_pham, @ma_hoa_don, @ten_san_pham, @so_luong, @don_gia, @thanh_tien, @hinh_anh )";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ma_san_pham", maSP);
                    command.Parameters.AddWithValue("@ma_hoa_don", maHD);
                    command.Parameters.AddWithValue("@ten_san_pham", tenSP);
                    command.Parameters.AddWithValue("@so_luong", soLuong);
                    command.Parameters.AddWithValue("@don_gia", donGia);
                    command.Parameters.AddWithValue("@thanh_tien", thanhTien);
                    command.Parameters.AddWithValue("@hinh_anh", hinhAnh);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
