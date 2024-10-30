using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banking
{
    public partial class Withdraw : Form
    {
        public Withdraw()
        {
            InitializeComponent();
            LoadAccountData(); // Tải tài khoản vào ComboBox
            LoadBranchData();
        }

        private void LoadBranchData()
        {
            using (SqlConnection connection = new SqlConnection("Server=DESKTOP-KQS8PTG;Database=NET;Integrated Security=True;"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT id, name FROM branch", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable branchesTable = new DataTable();
                adapter.Fill(branchesTable);

                comboBoxBranchID.DataSource = branchesTable;
                comboBoxBranchID.DisplayMember = "id"; // Hiển thị ID chi nhánh
                comboBoxBranchID.ValueMember = "id"; // Giá trị ID chi nhánh
            }
        }


        private void Withdraw_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxBranchID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBranchID.SelectedValue != null)
            {
                // Kiểm tra kiểu dữ liệu của SelectedValue
                object selectedValue = comboBoxBranchID.SelectedValue;
                if (selectedValue is int selectedBranchId)
                {
                    // Giá trị có thể ép kiểu thành int
                    txtBranchName.Text = ((DataRowView)comboBoxBranchID.SelectedItem)["name"].ToString(); // Hiển thị tên chi nhánh
                }
                else if (selectedValue is string)
                {
                    // Nếu SelectedValue là string, bạn có thể cần ép kiểu thành int từ string
                    if (int.TryParse(selectedValue.ToString(), out int parsedBranchId))
                    {
                        // Thành công, sử dụng parsedBranchId
                    }
                    else
                    {
                        MessageBox.Show("Error.");
                    }
                }
            }
        }
        private SqlConnection connection = new SqlConnection("Server=DESKTOP-KQS8PTG;Database=NET;Integrated Security=True;");
        private void LoadAccountData()
        {
            using (SqlConnection connection = new SqlConnection("Server=DESKTOP-KQS8PTG;Database=NET;Integrated Security=True;"))
            {
                connection.Open();

                // Lấy danh sách tài khoản
                SqlCommand command = new SqlCommand("SELECT id, customerid FROM account", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                comboBoxAccountID.DataSource = dataTable;
                comboBoxAccountID.DisplayMember = "customerid"; // Tên hiển thị
                comboBoxAccountID.ValueMember = "id"; // Giá trị của ComboBox

                // Đăng ký sự kiện SelectedIndexChanged
                comboBoxAccountID.SelectedIndexChanged += comboBoxAccountID_SelectedIndexChanged;
            }
        }
        private void DisplayAccountHolderName(int accountId, TextBox textBox)
        {
            string query = @"SELECT Customer.name 
                     FROM Customer 
                     INNER JOIN Account ON Customer.id = Account.customerid
                     WHERE Account.id = @AccountID";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@AccountID", accountId);
                connection.Open();
                string accountHolderName = command.ExecuteScalar()?.ToString();
                connection.Close();

                textBox.Text = accountHolderName ?? "Unknown";
            }
        }

        private void txtFromAccountHolderName_TextChanged(object sender, EventArgs e)
        {
            int selectedAccountId = Convert.ToInt32(comboBoxAccountID.SelectedValue);
            DisplayAccountHolderName(selectedAccountId, txtFromAccountHolderName);
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            WithdrawMoney();
        }

        private void WithdrawMoney()
        {
            if (decimal.TryParse(txtTransferAmount.Text, out decimal withdrawAmount))
            {
                int accountId = (int)comboBoxAccountID.SelectedValue; // Lấy ID tài khoản từ ComboBox
                string pin = txtPin.Text; // Lấy mã PIN từ TextBox

                // Kiểm tra mã PIN
                if (pin == GetPinForAccount(accountId))
                {
                    // Lấy số dư hiện tại của tài khoản
                    decimal currentBalance = GetBalance(accountId);

                    // Kiểm tra số dư có đủ để rút tiền không
                    if (currentBalance >= withdrawAmount)
                    {
                        // Cập nhật số dư mới sau khi rút tiền
                        UpdateAccountBalance(accountId, currentBalance - withdrawAmount);

                        // Ghi lại giao dịch vào bảng Transaction
                        int branchId = (int)comboBoxBranchID.SelectedValue; 

                        // Thông báo thành công
                        MessageBox.Show("Successful withdraw!");
                    }
                    else
                    {
                        MessageBox.Show("Insufficient balance!");
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect PIN.");
                }
            }
            else
            {
                MessageBox.Show("Invalid money amount.");
            }
        }
        private decimal GetBalance(int accountId)
        {
            // Truy vấn để lấy số dư của tài khoản từ cơ sở dữ liệu
            decimal balance = 0;
            string connectionString = "Server=DESKTOP-KQS8PTG;Database=NET;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT balance FROM Account WHERE id = @accountId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@accountId", accountId);
                connection.Open();

                // Kiểm tra nếu giá trị trả về là DBNull
                var result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    balance = Convert.ToDecimal(result); // Chuyển đổi sang decimal
                }
                else
                {
                    // Xử lý trường hợp balance không tồn tại
                    MessageBox.Show("Invalid balance.");
                }
            }
            return balance;
        }
        private string GetPinForAccount(int accountId)
        {
            // Truy vấn để lấy mã PIN của tài khoản từ cơ sở dữ liệu
            string pin = string.Empty;
            string connectionString = "Server=DESKTOP-KQS8PTG;Database=NET;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT PIN FROM Account WHERE id = @accountId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@accountId", accountId);
                connection.Open();
                pin = command.ExecuteScalar()?.ToString(); // Lấy mã PIN
            }
            return pin;
        }
        private void UpdateAccountBalance(int accountId, decimal newBalance)
        {
            // Cập nhật số dư tài khoản trong cơ sở dữ liệu
            string connectionString = "Server=DESKTOP-KQS8PTG;Database=NET;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Account SET balance = @newBalance WHERE id = @accountId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@newBalance", newBalance);
                command.Parameters.AddWithValue("@accountId", accountId);
                connection.Open();
                command.ExecuteNonQuery(); // Thực hiện cập nhật
            }
        }

        private void comboBoxAccountID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAccountID.SelectedValue != null)
            {
                // Sử dụng nullable int
                int? selectedAccountId = comboBoxAccountID.SelectedValue as int?;

                if (selectedAccountId.HasValue)
                {
                    using (SqlConnection connection = new SqlConnection("Server=DESKTOP-KQS8PTG;Database=NET;Integrated Security=True;"))
                    {
                        connection.Open();

                        // Truy vấn tên khách hàng
                        SqlCommand command = new SqlCommand("SELECT c.name FROM customer c JOIN account a ON c.id = a.customerid WHERE a.id = @AccountId", connection);
                        command.Parameters.AddWithValue("@AccountId", selectedAccountId.Value);

                        object result = command.ExecuteScalar();
                        txtFromAccountHolderName.Text = result != null ? result.ToString() : "N/A"; // Hiển thị tên khách hàng
                    }
                }
            }
            else
            {
                txtFromAccountHolderName.Text = string.Empty; // Xóa tên khách hàng nếu không có giá trị
            }
        }
    }
}
