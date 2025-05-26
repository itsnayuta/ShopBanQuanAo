using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using ShopBanQuanAo.Models;

namespace ShopBanQuanAo.Data
{
    public class KhachHangDAO
    {
        public List<KhachHang> GetAll()
        {
            List<KhachHang> list = new List<KhachHang>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM KhachHang ORDER BY ID DESC";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new KhachHang
                                {
                                    ID = reader.GetInt32("ID"),
                                    Ten = reader.GetString("Ten"),
                                    DiaChi = reader.IsDBNull("DiaChi") ? "" : reader.GetString("DiaChi"),
                                    SDT = reader.IsDBNull("SDT") ? "" : reader.GetString("SDT"),
                                    Email = reader.IsDBNull("Email") ? "" : reader.GetString("Email"),
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
                MessageBox.Show($"Lỗi khi lấy danh sách khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }

        public bool Insert(KhachHang khachHang)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO KhachHang (Ten, DiaChi, SDT, Email) VALUES (@Ten, @DiaChi, @SDT, @Email)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Ten", khachHang.Ten);
                        command.Parameters.AddWithValue("@DiaChi", khachHang.DiaChi ?? "");
                        command.Parameters.AddWithValue("@SDT", khachHang.SDT ?? "");
                        command.Parameters.AddWithValue("@Email", khachHang.Email ?? "");
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Update(KhachHang khachHang)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE KhachHang SET Ten=@Ten, DiaChi=@DiaChi, SDT=@SDT, Email=@Email WHERE ID=@ID";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", khachHang.ID);
                        command.Parameters.AddWithValue("@Ten", khachHang.Ten);
                        command.Parameters.AddWithValue("@DiaChi", khachHang.DiaChi ?? "");
                        command.Parameters.AddWithValue("@SDT", khachHang.SDT ?? "");
                        command.Parameters.AddWithValue("@Email", khachHang.Email ?? "");
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string query = "DELETE FROM KhachHang WHERE ID=@ID";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public List<KhachHang> Search(string keyword)
        {
            List<KhachHang> list = new List<KhachHang>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM KhachHang WHERE Ten LIKE @keyword OR SDT LIKE @keyword OR Email LIKE @keyword";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@keyword", $"%{keyword}%");
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new KhachHang
                                {
                                    ID = reader.GetInt32("ID"),
                                    Ten = reader.GetString("Ten"),
                                    DiaChi = reader.IsDBNull("DiaChi") ? "" : reader.GetString("DiaChi"),
                                    SDT = reader.IsDBNull("SDT") ? "" : reader.GetString("SDT"),
                                    Email = reader.IsDBNull("Email") ? "" : reader.GetString("Email"),
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
                MessageBox.Show($"Lỗi khi tìm kiếm khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
    }
}