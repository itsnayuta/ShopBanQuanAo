using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ShopBanQuanAo.Utils;
namespace ShopBanQuanAo
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            using (var conn = Helpers.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ID, Ten, Size, Mau, Gia, SoLuong FROM SanPham";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvProducts.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải sản phẩm: " + ex.Message);
                }
            }
        }

        private void ClearInputs()
        {
            txtID.Text = "";
            txtTen.Text = "";
            txtSize.Text = "";
            txtMau.Text = "";
            txtGia.Text = "";
            txtSoLuong.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTen.Text == "" || txtSize.Text == "" || txtMau.Text == "" || txtGia.Text == "" || txtSoLuong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            using (var conn = Helpers.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO SanPham (Ten, Size, Mau, Gia, SoLuong) VALUES (@ten, @size, @mau, @gia, @soLuong)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ten", txtTen.Text);
                    cmd.Parameters.AddWithValue("@size", txtSize.Text);
                    cmd.Parameters.AddWithValue("@mau", txtMau.Text);
                    cmd.Parameters.AddWithValue("@gia", decimal.Parse(txtGia.Text));
                    cmd.Parameters.AddWithValue("@soLuong", int.Parse(txtSoLuong.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm sản phẩm thành công.");
                    LoadProducts();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm sản phẩm: " + ex.Message);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để sửa.");
                return;
            }
            using (var conn = Helpers.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE SanPham SET Ten=@ten, Size=@size, Mau=@mau, Gia=@gia, SoLuong=@soLuong WHERE ID=@id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ten", txtTen.Text);
                    cmd.Parameters.AddWithValue("@size", txtSize.Text);
                    cmd.Parameters.AddWithValue("@mau", txtMau.Text);
                    cmd.Parameters.AddWithValue("@gia", decimal.Parse(txtGia.Text));
                    cmd.Parameters.AddWithValue("@soLuong", int.Parse(txtSoLuong.Text));
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtID.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật sản phẩm thành công.");
                    LoadProducts();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật sản phẩm: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xóa.");
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var conn = Helpers.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM SanPham WHERE ID=@id";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", int.Parse(txtID.Text));
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Xóa sản phẩm thành công.");
                        LoadProducts();
                        ClearInputs();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xóa sản phẩm: " + ex.Message);
                    }
                }
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];// Dereference of a possibly null reference.
                txtID.Text = row.Cells["ID"].Value.ToString();
                txtTen.Text = row.Cells["Ten"].Value.ToString();
                txtSize.Text = row.Cells["Size"].Value.ToString();
                txtMau.Text = row.Cells["Mau"].Value.ToString();
                txtGia.Text = row.Cells["Gia"].Value.ToString();
                txtSoLuong.Text = row.Cells["SoLuong"].Value.ToString();
            }
        }
    }
}
