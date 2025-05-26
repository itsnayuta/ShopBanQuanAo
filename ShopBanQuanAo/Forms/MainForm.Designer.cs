namespace ShopBanQuanAo
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnManageProducts;
        private System.Windows.Forms.Button btnManageCustomers;
        private System.Windows.Forms.Button btnManageOrders;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblWelcome;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnManageProducts = new System.Windows.Forms.Button();
            this.btnManageCustomers = new System.Windows.Forms.Button();
            this.btnManageOrders = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnManageProducts
            // 
            this.btnManageProducts.Location = new System.Drawing.Point(40, 80);
            this.btnManageProducts.Name = "btnManageProducts";
            this.btnManageProducts.Size = new System.Drawing.Size(140, 40);
            this.btnManageProducts.TabIndex = 0;
            this.btnManageProducts.Text = "Quản lý sản phẩm";
            this.btnManageProducts.UseVisualStyleBackColor = true;
            this.btnManageProducts.Click += new System.EventHandler(this.btnManageProducts_Click);
            // 
            // btnManageCustomers
            // 
            this.btnManageCustomers.Location = new System.Drawing.Point(200, 80);
            this.btnManageCustomers.Name = "btnManageCustomers";
            this.btnManageCustomers.Size = new System.Drawing.Size(140, 40);
            this.btnManageCustomers.TabIndex = 1;
            this.btnManageCustomers.Text = "Quản lý khách hàng";
            this.btnManageCustomers.UseVisualStyleBackColor = true;
            this.btnManageCustomers.Click += new System.EventHandler(this.btnManageCustomers_Click);
            // 
            // btnManageOrders
            // 
            this.btnManageOrders.Location = new System.Drawing.Point(360, 80);
            this.btnManageOrders.Name = "btnManageOrders";
            this.btnManageOrders.Size = new System.Drawing.Size(140, 40);
            this.btnManageOrders.TabIndex = 2;
            this.btnManageOrders.Text = "Quản lý đơn hàng";
            this.btnManageOrders.UseVisualStyleBackColor = true;
            this.btnManageOrders.Click += new System.EventHandler(this.btnManageOrders_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(360, 20);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(140, 30);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(30, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(250, 25);
            this.lblWelcome.TabIndex = 4;
            this.lblWelcome.Text = "Chào mừng đến Shop Quần Áo";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(540, 160);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnManageOrders);
            this.Controls.Add(this.btnManageCustomers);
            this.Controls.Add(this.btnManageProducts);
            this.Name = "MainForm";
            this.Text = "Trang chính - Quản lý Shop Quần Áo";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
