using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using ShopBanQuanAo.Models;

namespace ShopBanQuanAo.Data
{
    public class DonHangDAO
    {
        public List<DonHang> GetAll()
        {
            List<DonHang> list = new List<DonHang>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT d.*, k.Ten as TenKhachHang 
                                    FROM DonHang d 
                                    LEFT JOIN KhachHang k ON d.IDKhachHang = k.ID 
                                    ORDER BY d.ID DESC";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new DonHang
                                {
                                    ID = reader.GetInt32("ID"),
                                    NgayDat = reader.GetDateTime("NgayDat"),
                                    IDKhachHang = reader.GetInt32("IDKhachHang"),
                                    TenKhachHang = reader.IsDBNull("TenKhachHang") ? "N/A" : reader.GetString("TenKhachHang"),
                                    TongTien = reader.GetDecimal("TongTien"),
                                    TrangThai = reader.IsDBNull("TrangThai") ? "" : reader.GetString("TrangThai"),
                                    GhiChu = reader.IsDBNull("GhiChu") ? "" : reader.GetString("GhiChu")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy danh sách đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }

        public bool Insert(DonHang donHang)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO DonHang (IDKhachHang, TongTien, TrangThai, GhiChu) VALUES (@IDKhachHang, @TongTien, @TrangThai, @GhiChu)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IDKhachHang", donHang.IDKhachHang);
                        command.Parameters.AddWithValue("@TongTien", donHang.TongTien);
                        command.Parameters.AddWithValue("@TrangThai", donHang.TrangThai ?? "Chờ xử lý");
                        command.Parameters.AddWithValue("@GhiChu", donHang.GhiChu ?? "");
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Update(DonHang donHang)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE DonHang SET IDKhachHang=@IDKhachHang, TongTien=@TongTien, TrangThai=@TrangThai, GhiChu=@GhiChu WHERE ID=@ID";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", donHang.ID);
                        command.Parameters.AddWithValue("@IDKhachHang", donHang.IDKhachHang);
                        command.Parameters.AddWithValue("@TongTien", donHang.TongTien);
                        command.Parameters.AddWithValue("@TrangThai", donHang.TrangThai ?? "Chờ xử lý");
                        command.Parameters.AddWithValue("@GhiChu", donHang.GhiChu ?? "");
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string query = "DELETE FROM DonHang WHERE ID=@ID";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}