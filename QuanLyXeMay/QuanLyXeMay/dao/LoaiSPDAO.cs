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
    class LoaiSPDAO
    {
        private string _connectionString;
        public LoaiSPDAO()
        {
            _connectionString = DataSourceProvider.CONNECT_STRING;
        }

        public List<LoaiSP> GetAllLoaiSP()
        {
            List<LoaiSP> listLoaiSP = new List<LoaiSP>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM loaisanpham"; 

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listLoaiSP.Add(new LoaiSP
                            {
                                MaLoaiSP = Convert.ToInt32(reader["ma_loai_sp"]),
                                TenLoaiSP = reader["ten_loai_sp"].ToString(),
                            });
                        }
                    }
                }
            }

            return listLoaiSP;
        }

        public LoaiSP GetLoaiSPByName(string name)
        {
            LoaiSP loaisp = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM loaisanpham WHERE ten_loai_sp = @ten_loai_sp";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ten_loai_sp", name);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Đọc dữ liệu từ SqlDataReader và tạo đối tượng LoaiSP
                            loaisp = new LoaiSP
                            {
                                MaLoaiSP = Convert.ToInt32(reader["ma_loai_sp"]),
                                TenLoaiSP = reader["ten_loai_sp"].ToString()
                            };
                        }
                    }
                }
            }

            return loaisp;
        }



        public List<string> GetAllLoaiSPStr()
        {
            List<string> listLoaiSP = new List<string>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM loaisanpham";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listLoaiSP.Add(reader["ten_loai_sp"].ToString());
                        }
                    }
                }
            }

            return listLoaiSP;
        }



    }
}
