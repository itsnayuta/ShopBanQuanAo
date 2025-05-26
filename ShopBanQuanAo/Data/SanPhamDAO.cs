using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using ShopBanQuanAo.Models;

namespace ShopBanQuanAo.Data
{
    public class SanPhamDAO
    {
        public List<SanPham> GetAll()
        {
            List<SanPham> list = new List<SanPham>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM SanPham ORDER BY ID DESC";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new SanPham
                                {
                                    ID = reader.GetInt32("ID"),
                                    Ten = reader.GetString("Ten"),
                                    Size = reader.IsDBNull("Size") ? "" : reader.GetString("Size"),
                                    Mau = reader.IsDBNull("Mau") ? "" : reader.GetString("Mau"),
                                    Gia = reader.GetDecimal("Gia"),
                                    SoLuong = reader.GetInt32("SoLuong"),
                                    CreateDate = reader.GetDateTime("CreateDate"),
                                    UpdateDate = reader.GetDateTime("UpdateDate")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy danh sách sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }

        public bool Insert(SanPham sanPham)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO SanPham (Ten, Size, Mau, Gia, SoLuong) VALUES (@Ten, @Size, @Mau, @Gia, @SoLuong)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Ten", sanPham.Ten);
                        command.Parameters.AddWithValue("@Size", sanPham.Size ?? "");
                        command.Parameters.AddWithValue("@Mau", sanPham.Mau ?? "");
                        command.Parameters.AddWithValue("@Gia", sanPham.Gia);
                        command.Parameters.AddWithValue("@SoLuong", sanPham.SoLuong);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Update(SanPham sanPham)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE SanPham SET Ten=@Ten, Size=@Size, Mau=@Mau, Gia=@Gia, SoLuong=@SoLuong WHERE ID=@ID";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", sanPham.ID);
                        command.Parameters.AddWithValue("@Ten", sanPham.Ten);
                        command.Parameters.AddWithValue("@Size", sanPham.Size ?? "");
                        command.Parameters.AddWithValue("@Mau", sanPham.Mau ?? "");
                        command.Parameters.AddWithValue("@Gia", sanPham.Gia);
                        command.Parameters.AddWithValue("@SoLuong", sanPham.SoLuong);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM SanPham WHERE ID=@ID";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public List<SanPham> Search(string keyword)
        {
            List<SanPham> list = new List<SanPham>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM SanPham WHERE Ten LIKE @keyword OR Mau LIKE @keyword OR Size LIKE @keyword";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@keyword", $"%{keyword}%");
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new SanPham
                                {
                                    ID = reader.GetInt32("ID"),
                                    Ten = reader.GetString("Ten"),
                                    Size = reader.IsDBNull("Size") ? "" : reader.GetString("Size"),
                                    Mau = reader.IsDBNull("Mau") ? "" : reader.GetString("Mau"),
                                    Gia = reader.GetDecimal("Gia"),
                                    SoLuong = reader.GetInt32("SoLuong"),
                                    CreateDate = reader.GetDateTime("CreateDate"),
                                    UpdateDate = reader.GetDateTime("UpdateDate")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
    }
}