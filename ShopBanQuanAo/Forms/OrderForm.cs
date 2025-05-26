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
                        SELECT d.ID, d.Ngay, k.Ten as KhachHang
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
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (comboCustomer.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn khách hàng.");
                return;
            }

            int idKhachHang = ((ComboboxItem)comboCustomer.SelectedItem).Value;
            DateTime ngay = dtpNgay.Value.Date;

            using (var conn = Helpers.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO DonHang (Ngay, IDKhachHang) VALUES (@ngay, @idKhachHang)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ngay", ngay);
                    cmd.Parameters.AddWithValue("@idKhachHang", idKhachHang);
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
            if (comboCustomer.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn khách hàng.");
                return;
            }

            int id = int.Parse(txtID.Text);
            int idKhachHang = ((ComboboxItem)comboCustomer.SelectedItem).Value;
            DateTime ngay = dtpNgay.Value.Date;

            using (var conn = Helpers.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE DonHang SET Ngay=@ngay, IDKhachHang=@idKhachHang WHERE ID=@id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ngay", ngay);
                    cmd.Parameters.AddWithValue("@idKhachHang", idKhachHang);
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
                DataGridViewRow row = dgvOrders.Rows[e.RowIndex];
                txtID.Text = row.Cells["ID"].Value.ToString();
                dtpNgay.Value = Convert.ToDateTime(row.Cells["Ngay"].Value);
                string tenKhachHang = row.Cells["KhachHang"].Value.ToString();

                // Set combo box theo tên khách hàng
                for (int i = 0; i < comboCustomer.Items.Count; i++)
                {
                    if (((ComboboxItem)comboCustomer.Items[i]).Text == tenKhachHang)
                    {
                        comboCustomer.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }
        public override string ToString()
        {
            return Text;
        }
    }
}
