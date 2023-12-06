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
    class NguoiDungDAO
    {
        private string _connectionString;
        public NguoiDungDAO()
        {
            _connectionString = DataSourceProvider.CONNECT_STRING;
        }

        public List<NguoiDung> GetAllUsers()
        {
            List<NguoiDung> users = new List<NguoiDung>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM nguoidung"; 

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new NguoiDung
                            {
                                MaNguoiDung = Convert.ToInt32(reader["ma_nguoi_dung"]),
                                TenNguoiDung = reader["ten_nguoi_dung"].ToString(),
                                TenDangNhap = reader["ten_dang_nhap"].ToString(),
                                MatKhau = reader["mat_khau"].ToString(),
                                VaiTro = reader["vai_tro"].ToString(),
                            });
                        }
                    }
                }
            }

            return users;
        }

        public List<NguoiDung> GetUserByVaiTro(string vaitro)
        {
            List<NguoiDung> users = new List<NguoiDung>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM nguoidung WHERE trang_thai = 'ACTIVE' AND vai_tro = @vai_tro";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@vai_tro", vaitro);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string ngaySinhString = reader["ngay_sinh"].ToString();
                            DateTime ngaySinhDate = new DateTime();
                            DateTime.TryParse(ngaySinhString, out ngaySinhDate);
                            users.Add(new NguoiDung
                            {
                                MaNguoiDung = Convert.ToInt32(reader["ma_nguoi_dung"]),
                                TenNguoiDung = reader["ten_nguoi_dung"].ToString(),
                                TenDangNhap = reader["ten_dang_nhap"].ToString(),
                                MatKhau = reader["mat_khau"].ToString(),
                                VaiTro = reader["vai_tro"].ToString(),
                                TrangThai = reader["trang_thai"].ToString(),
                                SoDienThoai = reader["so_dien_thoai"].ToString(),
                                Email = reader["email"].ToString(),
                                DiaChi = reader["dia_chi"].ToString(),
                                GioiTinh = reader["gioi_tinh"].ToString(),
                                NgaySinh = ngaySinhDate,
                                HinhAnh = reader["hinh_anh"].ToString(),
                            });
                        }
                    }
                }
            }

            return users;
        }

        public List<NguoiDung> GetUserByKeyword(string keyword, int loaiSearch, string vaitro, int page, int size)
        {
            List<NguoiDung> users = new List<NguoiDung>();
            int offset = (page - 1) * size;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM nguoidung WHERE trang_thai = 'ACTIVE' AND vai_tro = @vai_tro";
                if (loaiSearch <= 0)
                {
                    query += " AND ten_nguoi_dung LIKE @keyword";
                }
                if (loaiSearch == 1)
                {
                    query += " AND so_dien_thoai LIKE @keyword";
                }
                if (loaiSearch == 2)
                {
                    query += " AND ten_dang_nhap LIKE @keyword";
                }
                if (loaiSearch == 3)
                {
                    query += " AND email LIKE @keyword";
                }

                query += " ORDER BY ma_nguoi_dung DESC OFFSET @offset ROWS FETCH NEXT @size ROWS ONLY";
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
                            string ngaySinhString = reader["ngay_sinh"].ToString();
                            DateTime ngaySinhDate = new DateTime();
                            DateTime.TryParse(ngaySinhString, out ngaySinhDate);
                            users.Add(new NguoiDung
                            {
                                MaNguoiDung = Convert.ToInt32(reader["ma_nguoi_dung"]),
                                TenNguoiDung = reader["ten_nguoi_dung"].ToString(),
                                TenDangNhap = reader["ten_dang_nhap"].ToString(),
                                MatKhau = reader["mat_khau"].ToString(),
                                VaiTro = reader["vai_tro"].ToString(),
                                TrangThai = reader["trang_thai"].ToString(),
                                SoDienThoai = reader["so_dien_thoai"].ToString(),
                                Email = reader["email"].ToString(),
                                DiaChi = reader["dia_chi"].ToString(),
                                GioiTinh = reader["gioi_tinh"].ToString(),
                                NgaySinh = ngaySinhDate,
                                HinhAnh = reader["hinh_anh"].ToString(),
                            });
                        }
                    }
                }
            }

            return users;
        }

        public NguoiDung GetNguoiDungById(int id)
        {
            NguoiDung nguoiDung = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM nguoidung WHERE ma_nguoi_dung = @ma_nguoi_dung";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ma_nguoi_dung", id);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string ngaySinhString = reader["ngay_sinh"].ToString();
                            DateTime ngaySinhDate = new DateTime();
                            DateTime.TryParse(ngaySinhString, out ngaySinhDate);
                            nguoiDung = new NguoiDung
                            {
                                MaNguoiDung = Convert.ToInt32(reader["ma_nguoi_dung"]),
                                TenNguoiDung = reader["ten_nguoi_dung"].ToString(),
                                TenDangNhap = reader["ten_dang_nhap"].ToString(),
                                MatKhau = reader["mat_khau"].ToString(),
                                VaiTro = reader["vai_tro"].ToString(),
                                TrangThai = reader["trang_thai"].ToString(),
                                SoDienThoai = reader["so_dien_thoai"].ToString(),
                                Email = reader["email"].ToString(),
                                DiaChi = reader["dia_chi"].ToString(),
                                GioiTinh = reader["gioi_tinh"].ToString(),
                                NgaySinh = ngaySinhDate,
                                HinhAnh = reader["hinh_anh"].ToString(),
                            };
                        }
                    }
                }
            }

            return nguoiDung;
        }

        public void InsertNguoiDung(NguoiDung nguoiDung)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO nguoidung (ten_nguoi_dung, ten_dang_nhap, mat_khau, so_dien_thoai, email, dia_chi, gioi_tinh, ngay_sinh, hinh_anh, vai_tro) " +
                               "VALUES (@ten_nguoi_dung, @ten_dang_nhap, @mat_khau, @so_dien_thoai, @email,@dia_chi, @gioi_tinh, @ngay_sinh, @hinh_anh, @vai_tro)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ten_nguoi_dung", nguoiDung.TenNguoiDung);
                    command.Parameters.AddWithValue("@ten_dang_nhap", nguoiDung.TenDangNhap);
                    command.Parameters.AddWithValue("@mat_khau", nguoiDung.MatKhau);
                    command.Parameters.AddWithValue("@so_dien_thoai", nguoiDung.SoDienThoai);
                    command.Parameters.AddWithValue("@email", nguoiDung.Email);
                    command.Parameters.AddWithValue("@dia_chi", nguoiDung.DiaChi);
                    command.Parameters.AddWithValue("@gioi_tinh", nguoiDung.GioiTinh);
                    command.Parameters.AddWithValue("@ngay_sinh", nguoiDung.NgaySinh);
                    command.Parameters.AddWithValue("@hinh_anh", nguoiDung.HinhAnh);
                    command.Parameters.AddWithValue("@vai_tro", nguoiDung.VaiTro);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateNguoiDung(NguoiDung nguoiDung)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE nguoidung SET " +
                               "ten_nguoi_dung = @ten_nguoi_dung, " +
                               "ten_dang_nhap = @ten_dang_nhap, " +
                               "mat_khau = @mat_khau, " +
                               "so_dien_thoai = @so_dien_thoai, " +
                               "email = @email, " +
                               "dia_chi = @dia_chi, " +
                               "gioi_tinh = @gioi_tinh, " +
                               "ngay_sinh = @ngay_sinh, " +
                               "hinh_anh = @hinh_anh " +
                               "WHERE ma_nguoi_dung = @ma_nguoi_dung";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ma_nguoi_dung", nguoiDung.MaNguoiDung);
                    command.Parameters.AddWithValue("@ten_nguoi_dung", nguoiDung.TenNguoiDung);
                    command.Parameters.AddWithValue("@ten_dang_nhap", nguoiDung.TenDangNhap);
                    command.Parameters.AddWithValue("@mat_khau", nguoiDung.MatKhau);
                    command.Parameters.AddWithValue("@so_dien_thoai", nguoiDung.SoDienThoai);
                    command.Parameters.AddWithValue("@email", nguoiDung.Email);
                    command.Parameters.AddWithValue("@dia_chi", nguoiDung.DiaChi);
                    command.Parameters.AddWithValue("@gioi_tinh", nguoiDung.GioiTinh);
                    command.Parameters.AddWithValue("@ngay_sinh", nguoiDung.NgaySinh);
                    command.Parameters.AddWithValue("@hinh_anh", nguoiDung.HinhAnh);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void XoaNguoiDung(int maNguoiDung)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE nguoiDung " +
                               "SET trang_thai = 'INACTIVE' " +
                               "WHERE ma_nguoi_dung = @ma_nguoi_dung";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ma_nguoi_dung", maNguoiDung);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public NguoiDung GetUserByUsername(string username)
        {
            NguoiDung nguoidung = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM nguoidung WHERE ten_dang_nhap = @username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string ngaySinhString = reader["ngay_sinh"].ToString();
                            DateTime ngaySinhDate = new DateTime();
                            DateTime.TryParse(ngaySinhString, out ngaySinhDate);
                            // Đọc dữ liệu từ SqlDataReader và tạo đối tượng LoaiSP
                            nguoidung = new NguoiDung
                            {
                                MaNguoiDung = Convert.ToInt32(reader["ma_nguoi_dung"]),
                                TenNguoiDung = reader["ten_nguoi_dung"].ToString(),
                                TenDangNhap = reader["ten_dang_nhap"].ToString(),
                                MatKhau = reader["mat_khau"].ToString(),
                                VaiTro = reader["vai_tro"].ToString(),
                                TrangThai = reader["trang_thai"].ToString(),
                                SoDienThoai = reader["so_dien_thoai"].ToString(),
                                Email = reader["email"].ToString(),
                                DiaChi = reader["dia_chi"].ToString(),
                                GioiTinh = reader["gioi_tinh"].ToString(),
                                NgaySinh = ngaySinhDate,
                            };
                        }
                    }
                }
            }

            return nguoidung;
        }

        public NguoiDung LoginProcess(string username, string password)
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM nguoidung WHERE ten_dang_nhap = @username AND mat_khau = @password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Tham số hóa tham số để tránh injection SQL
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            NguoiDung user = new NguoiDung
                            {
                                MaNguoiDung = Convert.ToInt32(reader["ma_nguoi_dung"]),
                                TenNguoiDung = reader["ten_nguoi_dung"].ToString(),
                                TenDangNhap = reader["ten_dang_nhap"].ToString(),
                                VaiTro = reader["vai_tro"].ToString(),
                                MatKhau = "",
                            };

                            return user;
                        }
                    }
                }
            }

            return null;
        }

    }
}
