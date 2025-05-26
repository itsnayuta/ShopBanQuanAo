using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace ShopBanQuanAo.Utils
{
    public static class Helpers
    {
        public static MySqlConnection GetConnection()
        {
            string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            return new MySqlConnection(connStr);
        }
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return true; // Email không bắt buộc

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidPhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return true; // Phone không bắt buộc

            // Kiểm tra định dạng số điện thoại Việt Nam
            return phone.Length >= 10 && phone.Length <= 12 && phone.StartsWith("0");
        }

        public static string FormatCurrency(decimal amount)
        {
            return amount.ToString("N0") + " VNĐ";
        }

        public static bool ConfirmDelete(string itemName)
        {
            return MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa {itemName}?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowError(string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowWarning(string message)
        {
            MessageBox.Show(message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}