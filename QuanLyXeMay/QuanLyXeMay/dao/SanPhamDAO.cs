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
    class SanPhamDAO
    {
        private string _connectionString;
        public SanPhamDAO()
        {
            _connectionString = DataSourceProvider.CONNECT_STRING;
        }

        public List<SanPham> GetAllSanPham(int page, int size)
        {
            List<SanPham> listSanPham = new List<SanPham>();
            int offset = (page - 1) * size;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "select sp.*, lsp.ten_loai_sp from sanpham sp JOIN loaisanpham lsp ON sp.ma_loai_sp = lsp.ma_loai_sp WHERE sp.trang_thai = 'ACTIVE' ORDER BY sp.ma_san_pham DESC OFFSET @offset ROWS FETCH NEXT @size ROWS ONLY;"; 

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@size", size);
                    command.Parameters.AddWithValue("@offset", offset);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listSanPham.Add(new SanPham
                            {
                                MaSanPham = Convert.ToInt32(reader["ma_san_pham"]),
                                TenSanPham = reader["ten_san_pham"].ToString(),
                                DonGia = Convert.ToInt32(reader["don_gia"].ToString()),
                                SoLuong = Convert.ToInt32(reader["so_luong_ton"].ToString()),
                                TrangThai = reader["trang_thai"].ToString(),
                                MaLoaiSP = Convert.ToInt32(reader["ma_loai_sp"]),
                                TenLoaiSP = reader["ten_loai_sp"].ToString(),
                                HinhAnh = reader["hinh_anh"].ToString(),
                            });
                        }
                    }
                }
            }

            return listSanPham;
        }

        public List<SanPham> GetByMaLoaiSP(int maLoaiSP)
        {
            List<SanPham> listSanPham = new List<SanPham>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "select TOP 10 sp.*, lsp.ten_loai_sp from sanpham sp JOIN loaisanpham lsp ON sp.ma_loai_sp = lsp.ma_loai_sp WHERE sp.trang_thai = 'ACTIVE' ";
                if (maLoaiSP != 0)
                {
                    query += "AND lsp.ma_loai_sp = @ma_loai_sp";
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ma_loai_sp", maLoaiSP);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listSanPham.Add(new SanPham
                            {
                                MaSanPham = Convert.ToInt32(reader["ma_san_pham"]),
                                TenSanPham = reader["ten_san_pham"].ToString(),
                                DonGia = Convert.ToInt32(reader["don_gia"].ToString()),
                                SoLuong = Convert.ToInt32(reader["so_luong_ton"].ToString()),
                                TrangThai = reader["trang_thai"].ToString(),
                                MaLoaiSP = Convert.ToInt32(reader["ma_loai_sp"]),
                                TenLoaiSP = reader["ten_loai_sp"].ToString(),
                                HinhAnh = reader["hinh_anh"].ToString(),
                            });
                        }
                    }
                }
            }

            return listSanPham;
        }

        public List<SanPham> GetByKeyword(string keyword, int maLoaiSP, int page, int size)
        {
            List<SanPham> listSanPham = new List<SanPham>();
            int offset = (page - 1) * size;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "select sp.*, lsp.ten_loai_sp from sanpham sp JOIN loaisanpham lsp ON sp.ma_loai_sp = lsp.ma_loai_sp WHERE sp.trang_thai = 'ACTIVE' AND sp.ten_san_pham like @keyword";
                if (maLoaiSP != 0)
                {
                    query += " AND lsp.ma_loai_sp = @ma_loai_sp";
                }

                query += " ORDER BY sp.ma_san_pham DESC OFFSET @offset ROWS FETCH NEXT @size ROWS ONLY";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    command.Parameters.AddWithValue("@ma_loai_sp", maLoaiSP);
                    command.Parameters.AddWithValue("@size", size);
                    command.Parameters.AddWithValue("@offset", offset);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listSanPham.Add(new SanPham
                            {
                                MaSanPham = Convert.ToInt32(reader["ma_san_pham"]),
                                TenSanPham = reader["ten_san_pham"].ToString(),
                                DonGia = Convert.ToInt32(reader["don_gia"].ToString()),
                                SoLuong = Convert.ToInt32(reader["so_luong_ton"].ToString()),
                                TrangThai = reader["trang_thai"].ToString(),
                                MaLoaiSP = Convert.ToInt32(reader["ma_loai_sp"]),
                                TenLoaiSP = reader["ten_loai_sp"].ToString(),
                                HinhAnh = reader["hinh_anh"].ToString(),
                            });
                        }
                    }
                }
            }

            return listSanPham;
        }


        public SanPham GetSanPhamById(int id)
        {
            SanPham sp = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "select sp.*, lsp.ten_loai_sp from sanpham sp JOIN loaisanpham lsp ON sp.ma_loai_sp = lsp.ma_loai_sp WHERE sp.trang_thai = 'ACTIVE' AND sp.ma_san_pham = @ma_san_pham;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ma_san_pham", id);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            sp = new SanPham
                            {
                                MaSanPham = Convert.ToInt32(reader["ma_san_pham"]),
                                TenSanPham = reader["ten_san_pham"].ToString(),
                                DonGia = Convert.ToInt32(reader["don_gia"].ToString()),
                                SoLuong = Convert.ToInt32(reader["so_luong_ton"].ToString()),
                                TrangThai = reader["trang_thai"].ToString(),
                                MaLoaiSP = Convert.ToInt32(reader["ma_loai_sp"]),
                                TenLoaiSP = reader["ten_loai_sp"].ToString(),
                                HinhAnh = reader["hinh_anh"].ToString(),
                            };
                        }
                    }
                }
            }

            return sp;
        }

        public void InsertSanPham(string tenSP, int donGia, int soLuong, int maLoaiSP, string hinhAnh)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO sanpham (ten_san_pham, don_gia, so_luong_ton, ma_loai_sp, hinh_anh) " +
                               "VALUES (@ten_san_pham, @don_gia, @so_luong_ton, @ma_loai_sp, @hinh_anh)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ten_san_pham", tenSP);
                    command.Parameters.AddWithValue("@don_gia", donGia);
                    command.Parameters.AddWithValue("@so_luong_ton", soLuong);
                    command.Parameters.AddWithValue("@ma_loai_sp", maLoaiSP);
                    command.Parameters.AddWithValue("@hinh_anh", hinhAnh);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateSanPham(int maSanPham, string tenSP, int donGia, int soLuong, int maLoaiSP, string hinhAnh)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE sanpham " +
                               "SET ten_san_pham = @ten_san_pham, " +
                               "don_gia = @don_gia, " +
                               "so_luong_ton = @so_luong_ton, " +
                               "ma_loai_sp = @ma_loai_sp, " +
                               "hinh_anh = @hinh_anh " +
                               "WHERE ma_san_pham = @ma_san_pham";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ma_san_pham", maSanPham);
                    command.Parameters.AddWithValue("@ten_san_pham", tenSP);
                    command.Parameters.AddWithValue("@don_gia", donGia);
                    command.Parameters.AddWithValue("@so_luong_ton", soLuong);
                    command.Parameters.AddWithValue("@ma_loai_sp", maLoaiSP);
                    command.Parameters.AddWithValue("@hinh_anh", hinhAnh);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void XoaSanPham(int maSanPham)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            { 
                string query = "UPDATE sanpham " +
                               "SET trang_thai = 'INACTIVE' " +
                               "WHERE ma_san_pham = @ma_san_pham";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ma_san_pham", maSanPham);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
