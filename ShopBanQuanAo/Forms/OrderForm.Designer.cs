

namespace ShopBanQuanAo
{
    partial class OrderForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.txtID = new System.Windows.Forms.TextBox();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.comboCustomer = new System.Windows.Forms.ComboBox();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.txtTrangThai = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();

            this.lblID = new System.Windows.Forms.Label();
            this.lblNgay = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblGhiChu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();

            // dgvOrders
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(20, 300);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RowTemplate.Height = 24;
            this.dgvOrders.Size = new System.Drawing.Size(740, 200);
            this.dgvOrders.TabIndex = 0;
            this.dgvOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellClick);

            // Labels
            this.lblID.Text = "ID:";
            this.lblID.Location = new System.Drawing.Point(20, 20);
            this.lblID.Size = new System.Drawing.Size(100, 23);

            this.lblNgay.Text = "Ngày đặt:";
            this.lblNgay.Location = new System.Drawing.Point(20, 60);
            this.lblNgay.Size = new System.Drawing.Size(100, 23);

            this.lblCustomer.Text = "Khách hàng:";
            this.lblCustomer.Location = new System.Drawing.Point(20, 100);
            this.lblCustomer.Size = new System.Drawing.Size(100, 23);

            this.lblTongTien.Text = "Tổng tiền:";
            this.lblTongTien.Location = new System.Drawing.Point(400, 20);
            this.lblTongTien.Size = new System.Drawing.Size(100, 23);

            this.lblTrangThai.Text = "Trạng thái:";
            this.lblTrangThai.Location = new System.Drawing.Point(400, 60);
            this.lblTrangThai.Size = new System.Drawing.Size(100, 23);

            this.lblGhiChu.Text = "Ghi chú:";
            this.lblGhiChu.Location = new System.Drawing.Point(400, 100);
            this.lblGhiChu.Size = new System.Drawing.Size(100, 23);

            // TextBox: ID
            this.txtID.Location = new System.Drawing.Point(130, 20);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(200, 22);

            // DateTimePicker: Ngay
            this.dtpNgay.Location = new System.Drawing.Point(130, 60);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(200, 22);

            // ComboBox: Customer
            this.comboCustomer.Location = new System.Drawing.Point(130, 100);
            this.comboCustomer.Name = "comboCustomer";
            this.comboCustomer.Size = new System.Drawing.Size(200, 24);

            // TextBox: TongTien
            this.txtTongTien.Location = new System.Drawing.Point(510, 20);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(200, 22);

            // TextBox: TrangThai
            this.txtTrangThai.Location = new System.Drawing.Point(510, 60);
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.Size = new System.Drawing.Size(200, 22);

            // TextBox: GhiChu
            this.txtGhiChu.Location = new System.Drawing.Point(510, 100);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(200, 22);

            // Button: Add
            this.btnAdd.Location = new System.Drawing.Point(130, 160);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 30);
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // Button: Update
            this.btnUpdate.Location = new System.Drawing.Point(250, 160);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(90, 30);
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // Button: Delete
            this.btnDelete.Location = new System.Drawing.Point(370, 160);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 30);
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // Button: View Details
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnViewDetails.Location = new System.Drawing.Point(600, 150);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(120, 40);
            this.btnViewDetails.Text = "Xem Chi Tiết";
            this.btnViewDetails.UseVisualStyleBackColor = true;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            this.Controls.Add(this.btnViewDetails);
            // OrderForm
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.dtpNgay);
            this.Controls.Add(this.comboCustomer);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.txtTrangThai);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblNgay);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.lblGhiChu);
            this.Name = "OrderForm";
            this.Text = "Quản lý Đơn Hàng";
            // Refresh Button

            this.btnRefreshTotal = new System.Windows.Forms.Button();
            this.btnRefreshTotal.Text = "Cập nhật tổng tiền";
            this.btnRefreshTotal.Location = new System.Drawing.Point(600, 200);
            this.btnRefreshTotal.Size = new System.Drawing.Size(150, 30);
            this.btnRefreshTotal.Click += new System.EventHandler(this.btnRefreshTotal_Click);
            this.Controls.Add(this.btnRefreshTotal);
            
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.ComboBox comboCustomer;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.TextBox txtTrangThai;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;

        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label lblGhiChu;

        private System.Windows.Forms.Button btnViewDetails;
        private Control btnRefreshTotal;
    }
}
