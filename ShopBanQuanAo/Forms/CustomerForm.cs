using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ShopBanQuanAo.Utils;
namespace ShopBanQuanAo
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            using (var conn = Helpers.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ID, Ten, DiaChi, SDT FROM KhachHang";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvCustomers.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải khách hàng: " + ex.Message);
                }
            }
        }

        private void ClearInputs()
        {
            txtID.Text = "";
            txtTen.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTen.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            using (var conn = Helpers.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO KhachHang (Ten, DiaChi, SDT) VALUES (@ten, @diaChi, @sdt)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ten", txtTen.Text);
                    cmd.Parameters.AddWithValue("@diaChi", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("@sdt", txtSDT.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm khách hàng thành công.");
                    LoadCustomers();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm khách hàng: " + ex.Message);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Vui lòng chọn khách hàng để sửa.");
                return;
            }
            using (var conn = Helpers.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE KhachHang SET Ten=@ten, DiaChi=@diaChi, SDT=@sdt WHERE ID=@id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ten", txtTen.Text);
                    cmd.Parameters.AddWithValue("@diaChi", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("@sdt", txtSDT.Text);
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtID.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật khách hàng thành công.");
                    LoadCustomers();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật khách hàng: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa.");
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var conn = Helpers.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM KhachHang WHERE ID=@id";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", int.Parse(txtID.Text));
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Xóa khách hàng thành công.");
                        LoadCustomers();
                        ClearInputs();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xóa khách hàng: " + ex.Message);
                    }
                }
            }
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
                txtID.Text = row.Cells["ID"].Value.ToString();
                txtTen.Text = row.Cells["Ten"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
            }
        }
    }
}
