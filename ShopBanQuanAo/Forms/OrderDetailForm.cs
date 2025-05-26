using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ShopBanQuanAo.Utils;

namespace ShopBanQuanAo
{
    public partial class OrderDetailForm : Form
    {
        private int orderId;
        private int? selectedDetailId = null; // lưu ID chi tiết đơn hàng đang sửa

        public OrderDetailForm(int orderId)
        {
            InitializeComponent();
            this.orderId = orderId;
            LoadProducts();
            LoadOrderDetails();
        }

        private void LoadProducts()
        {
            using (var conn = Helpers.GetConnection())
            {
                conn.Open();
                string query = "SELECT ID, Ten FROM SanPham";
                var cmd = new MySqlCommand(query, conn);
                var reader = cmd.ExecuteReader();
                comboProducts.Items.Clear();

                while (reader.Read())
                {
                    comboProducts.Items.Add(new ComboboxItem
                    {
                        Text = reader.GetString("Ten"),
                        Value = reader.GetInt32("ID")
                    });
                }
            }
        }

        private void LoadOrderDetails()
        {
            using (var conn = Helpers.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT ct.ID, ct.IDSanPham, sp.Ten AS TenSanPham, ct.SoLuong, sp.Gia AS GiaSanPham
                    FROM chitietdonhang ct
                    JOIN sanpham sp ON ct.IDSanPham = sp.ID
                    WHERE ct.IDDonHang = @id";
                var adapter = new MySqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@id", orderId);
                var dt = new DataTable();
                adapter.Fill(dt);
                dgvDetails.DataSource = dt;

                // Ẩn cột IDSanPham nếu muốn, hoặc giữ lại cho dễ xử lý
                if (dgvDetails.Columns["IDSanPham"] != null)
                    dgvDetails.Columns["IDSanPham"].Visible = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (comboProducts.SelectedIndex == -1 ||
                !decimal.TryParse(txtGia.Text, out decimal gia) ||
                !int.TryParse(txtSoLuong.Text, out int soLuong))
            {
                MessageBox.Show("Dữ liệu không hợp lệ.");
                return;
            }

            var selectedProduct = (ComboboxItem)comboProducts.SelectedItem;

            using (var conn = Helpers.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd;

                if (selectedDetailId.HasValue)
                {
                    // Cập nhật
                    cmd = new MySqlCommand(
                        @"UPDATE chitietdonhang 
                            SET IDSanPham = @idSanPham, SoLuong = @soLuong, GiaBan = @gia 
                            WHERE ID = @id", conn);
                    cmd.Parameters.AddWithValue("@id", selectedDetailId.Value);
                }
                else
                {
                    // Thêm mới
                    cmd = new MySqlCommand(
                        @"INSERT INTO chitietdonhang (IDDonHang, IDSanPham, SoLuong, GiaBan) 
                            VALUES (@idDonHang, @idSanPham, @soLuong, @gia)", conn);
                    cmd.Parameters.AddWithValue("@idDonHang", orderId);
                }

                cmd.Parameters.AddWithValue("@idSanPham", selectedProduct.Value);
                cmd.Parameters.AddWithValue("@soLuong", soLuong);
                cmd.Parameters.AddWithValue("@gia", gia);

                cmd.ExecuteNonQuery();
            }

            LoadOrderDetails();
            UpdateTongTien();

            // Reset form
            selectedDetailId = null;
            comboProducts.SelectedIndex = -1;
            txtSoLuong.Clear();
            txtGia.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDetails.SelectedRows.Count == 0) return;
            int idDetail = Convert.ToInt32(dgvDetails.SelectedRows[0].Cells["ID"].Value);

            using (var conn = Helpers.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM chitietdonhang WHERE ID = @id", conn);
                cmd.Parameters.AddWithValue("@id", idDetail);
                cmd.ExecuteNonQuery();
            }

            LoadOrderDetails();
            UpdateTongTien();

            // Reset form
            selectedDetailId = null;
            comboProducts.SelectedIndex = -1;
            txtSoLuong.Clear();
            txtGia.Clear();
        }

        private void UpdateTongTien()
        {
            using (var conn = Helpers.GetConnection())
            {
                conn.Open();
                string query = @"
                    UPDATE DonHang d
                    SET TongTien = (
                        SELECT IFNULL(SUM(ct.SoLuong * ct.GiaBan), 0)
                        FROM chitietdonhang ct
                        JOIN sanpham sp ON ct.IDSanPham = sp.ID
                        WHERE ct.IDDonHang = d.ID
                    )
                    WHERE d.ID = @idDonHang";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idDonHang", orderId);
                cmd.ExecuteNonQuery();
            }
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvDetails.Rows[e.RowIndex];
                txtSoLuong.Text = row.Cells["SoLuong"].Value.ToString();
                txtGia.Text = row.Cells["GiaSanPham"].Value.ToString();

                selectedDetailId = Convert.ToInt32(row.Cells["ID"].Value);

                int productId = Convert.ToInt32(row.Cells["IDSanPham"].Value);
                for (int i = 0; i < comboProducts.Items.Count; i++)
                {
                    var item = (ComboboxItem)comboProducts.Items[i];
                    if (item.Value == productId)
                    {
                        comboProducts.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
        private void comboProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboProducts.SelectedItem is ComboboxItem selected)
            {
                int productId = selected.Value;
                using (var conn = Helpers.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT Gia FROM SanPham WHERE ID = @id";
                    var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", productId);
                    var gia = cmd.ExecuteScalar();
                    txtGia.Text = gia != null ? gia.ToString() : "0";
                }
            }
        }
        
    }
}
