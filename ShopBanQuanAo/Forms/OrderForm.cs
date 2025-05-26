using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ShopBanQuanAo.Utils;

namespace ShopBanQuanAo
{
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
            LoadOrders();
            LoadCustomersToComboBox();
        }

        private void LoadOrders()
        {
            using (var conn = Helpers.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT d.ID, d.NgayDat, k.Ten as KhachHang,
                                d.TongTien, d.TrangThai, d.GhiChu
                        FROM DonHang d
                        JOIN KhachHang k ON d.IDKhachHang = k.ID";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvOrders.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải đơn hàng: " + ex.Message);
                }
            }
        }

        private void LoadCustomersToComboBox()
        {
            using (var conn = Helpers.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ID, Ten FROM KhachHang";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    comboCustomer.Items.Clear();
                    while (reader.Read())
                    {
                        comboCustomer.Items.Add(new ComboboxItem
                        {
                            Text = reader.GetString("Ten"),
                            Value = reader.GetInt32("ID")
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải khách hàng: " + ex.Message);
                }
            }
        }

        private void ClearInputs()
        {
            txtID.Text = "";
            dtpNgay.Value = DateTime.Now;
            comboCustomer.SelectedIndex = -1;
            txtTongTien.Text = "0";
            txtTrangThai.Text = "Chờ xử lý";
            txtGhiChu.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (comboCustomer.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn khách hàng.");
                return;
            }

            if (comboCustomer.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng.");
                return;
            }
            var selected = (ComboboxItem)comboCustomer.SelectedItem;
            int idKhachHang = selected.Value;
            DateTime ngay = dtpNgay.Value;
            decimal tongTien = decimal.TryParse(txtTongTien.Text, out var tTien) ? tTien : 0;
            string trangThai = txtTrangThai.Text;
            string ghiChu = txtGhiChu.Text;

            using (var conn = Helpers.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO DonHang (NgayDat, IDKhachHang, TongTien, TrangThai, GhiChu)
                        VALUES (@ngay, @idKhachHang, @tongTien, @trangThai, @ghiChu)";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ngay", ngay);
                    cmd.Parameters.AddWithValue("@idKhachHang", idKhachHang);
                    cmd.Parameters.AddWithValue("@tongTien", tongTien);
                    cmd.Parameters.AddWithValue("@trangThai", trangThai);
                    cmd.Parameters.AddWithValue("@ghiChu", ghiChu);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Thêm đơn hàng thành công.");
                    LoadOrders();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm đơn hàng: " + ex.Message);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Vui lòng chọn đơn hàng để sửa.");
                return;
            }

            if (comboCustomer.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng.");
                return;
            }
            var selected = (ComboboxItem)comboCustomer.SelectedItem;
            int id = int.Parse(txtID.Text);
            int idKhachHang = selected.Value;
            DateTime ngay = dtpNgay.Value;
            decimal tongTien = decimal.TryParse(txtTongTien.Text, out var tTien) ? tTien : 0;
            string trangThai = txtTrangThai.Text;
            string ghiChu = txtGhiChu.Text;

            using (var conn = Helpers.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"
                        UPDATE DonHang
                        SET NgayDat=@ngay, IDKhachHang=@idKhachHang,
                            TongTien=@tongTien, TrangThai=@trangThai, GhiChu=@ghiChu
                        WHERE ID=@id";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ngay", ngay);
                    cmd.Parameters.AddWithValue("@idKhachHang", idKhachHang);
                    cmd.Parameters.AddWithValue("@tongTien", tongTien);
                    cmd.Parameters.AddWithValue("@trangThai", trangThai);
                    cmd.Parameters.AddWithValue("@ghiChu", ghiChu);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cập nhật đơn hàng thành công.");
                    LoadOrders();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật đơn hàng: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Vui lòng chọn đơn hàng để xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa đơn hàng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var conn = Helpers.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM DonHang WHERE ID=@id";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", int.Parse(txtID.Text));
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Xóa đơn hàng thành công.");
                        LoadOrders();
                        ClearInputs();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xóa đơn hàng: " + ex.Message);
                    }
                }
            }
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvOrders.Rows[e.RowIndex];
                txtID.Text = row.Cells["ID"].Value.ToString();
                if (row.Cells["NgayDat"].Value != DBNull.Value && row.Cells["NgayDat"].Value != null)
                    dtpNgay.Value = Convert.ToDateTime(row.Cells["NgayDat"].Value);
                else dtpNgay.Value = DateTime.Now;
                txtTongTien.Text = row.Cells["TongTien"].Value.ToString();
                txtTrangThai.Text = row.Cells["TrangThai"].Value.ToString();
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString() ?? "";

                string tenKhach = row.Cells["KhachHang"].Value?.ToString() ?? string.Empty;
                for (int i = 0; i < comboCustomer.Items.Count; i++)
                {
                    var item = comboCustomer.Items[i] as ComboboxItem;
                    if (item != null && item.Text == tenKhach)
                    {
                        comboCustomer.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Vui lòng chọn đơn hàng để xem chi tiết.");
                return;
            }

            int orderId = int.Parse(txtID.Text);

            OrderDetailForm detailForm = new OrderDetailForm(orderId);
            detailForm.ShowDialog();
        }
        private void btnRefreshTotal_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Vui lòng chọn đơn hàng để cập nhật tổng tiền.");
                return;
            }

            int orderId = int.Parse(txtID.Text);

            using (var conn = Helpers.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Tính lại tổng tiền từ bảng ChiTietDonHang
                    string updateTotalQuery = @"
                        UPDATE DonHang
                        SET TongTien = (
                            SELECT IFNULL(SUM(SoLuong * GiaBan), 0)
                            FROM ChiTietDonHang
                            WHERE IDDonHang = @orderId
                        )
                        WHERE ID = @orderId";

                    MySqlCommand cmd = new MySqlCommand(updateTotalQuery, conn);
                    cmd.Parameters.AddWithValue("@orderId", orderId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Đã cập nhật tổng tiền.");
                    LoadOrders(); // Refresh lại bảng
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật tổng tiền: " + ex.Message);
                }
            }
        }       
    }

    public class ComboboxItem
    {
        public required string Text { get; set; }
        public int Value { get; set; }
        public override string ToString() => Text;
    }
}
