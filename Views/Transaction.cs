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
    public partial class Transaction : Form
    {
        
        public Transaction()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Transaction_Load(object sender, EventArgs e)
        {
            LoadAccountComboBox();
            LoadBranchData();
            
        }
        private SqlConnection connection = new SqlConnection("Server=DESKTOP-KQS8PTG;Database=NET;Integrated Security=True;");
        private void LoadAccountComboBox()
        {
            string query = "SELECT id FROM Account";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable accountData = new DataTable();
            adapter.Fill(accountData);

            // Gán dữ liệu cho các ComboBox
            comboBoxFromAccount.DisplayMember = "id";
            comboBoxFromAccount.ValueMember = "id";
            comboBoxFromAccount.DataSource = accountData.Copy();

            comboBoxToAccount.DisplayMember = "id";
            comboBoxToAccount.ValueMember = "id";
            comboBoxToAccount.DataSource = accountData;
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


        // Phương thức để hiển thị tên người sở hữu
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
            int selectedAccountId = Convert.ToInt32(comboBoxFromAccount.SelectedValue);
            DisplayAccountHolderName(selectedAccountId, txtFromAccountHolderName); // Sử dụng txtFromAccountHolderName
        }

        private void txtToAccountHolderName_TextChanged(object sender, EventArgs e)
        {
            int selectedAccountId = Convert.ToInt32(comboBoxToAccount.SelectedValue);
            DisplayAccountHolderName(selectedAccountId, txtToAccountHolderName);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
        private void btnTransfer_Click(object sender, EventArgs e)
        {
           
            int fromAccountId = Convert.ToInt32(comboBoxFromAccount.SelectedValue);
            int recipientAccountId = (int)comboBoxToAccount.SelectedValue; // ID tài khoản nhận
            int selectedBranchId = (int)comboBoxBranchID.SelectedValue;
            string pin = txtPin.Text;
            decimal transferAmount;
            int employeeId = Login.LoggedInEmployeeId;

            // Kiểm tra xem số tiền có hợp lệ không
            if (!decimal.TryParse(txtTransferAmount.Text, out transferAmount) || transferAmount <= 0)
            {
                MessageBox.Show("Please enter a valid transfer amount.");
                return;
            }

            // Kiểm tra mã PIN
            if (ValidatePin(fromAccountId, pin))
            {
                // Kiểm tra số dư tài khoản gửi
                if (IsBalanceSufficient(fromAccountId, transferAmount))
                {
                    // Hiện thông báo xác nhận
                    var confirmResult = MessageBox.Show("Are you sure you want to transfer " + transferAmount + "?",
                                                         "Confirm Transfer",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        TransferFunds(fromAccountId, transferAmount);
                        SaveTransaction(fromAccountId, selectedBranchId, DateTime.Now, transferAmount, recipientAccountId,employeeId);

                    }
                }
                else
                {
                    MessageBox.Show("Insufficient balance. Please check your account balance.");
                }
            }
            else
            {
                MessageBox.Show("Incorrect PIN. Please try again.");
            }
        }
        private bool IsBalanceSufficient(int accountId, decimal amount)
        {
            string query = "SELECT Balance FROM Account WHERE id = @AccountID"; // Giả sử bạn có cột Balance trong bảng Account
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@AccountID", accountId);
                connection.Open();
                object result = command.ExecuteScalar();
                connection.Close();

                // Kiểm tra xem kết quả có null không và chuyển đổi sang decimal
                if (result != null && result != DBNull.Value)
                {
                    decimal balance = Convert.ToDecimal(result);
                    return balance >= amount; // Trả về true nếu số dư đủ
                }

                return false; // Nếu không tìm thấy tài khoản hoặc không có số dư
            }
        }

        private bool ValidatePin(int accountId, string pin)
        {
            string query = "SELECT COUNT(*) FROM Account WHERE id = @AccountID AND Pin = @Pin"; // Giả sử bạn có cột Pin trong bảng Account
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@AccountID", accountId);
                command.Parameters.AddWithValue("@Pin", pin);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                connection.Close();

                return count > 0; // Trả về true nếu mã PIN đúng
            }
        }

        private void TransferFunds(int fromAccountId, decimal amount)
        {
            int toAccountId = Convert.ToInt32(comboBoxToAccount.SelectedValue);

            // Cập nhật số dư của tài khoản gửi
            string updateFromAccount = "UPDATE Account SET Balance = Balance - @Amount WHERE id = @FromAccountID";
            string updateToAccount = "UPDATE Account SET Balance = Balance + @Amount WHERE id = @ToAccountID";

            using (SqlCommand command = new SqlCommand(updateFromAccount, connection))
            {
                command.Parameters.AddWithValue("@Amount", amount);
                command.Parameters.AddWithValue("@FromAccountID", fromAccountId);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            using (SqlCommand command = new SqlCommand(updateToAccount, connection))
            {
                command.Parameters.AddWithValue("@Amount", amount);
                command.Parameters.AddWithValue("@ToAccountID", toAccountId);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            MessageBox.Show("Transfer successful!");
        }
        private void SaveTransaction(int fromAccountId, int branchId, DateTime transactionDate, decimal amount, int toAccountId, int employeeId)
        {
            using (SqlConnection connection = new SqlConnection("Server=DESKTOP-KQS8PTG;Database=NET;Integrated Security=True;"))
            {
                connection.Open();

                // Lấy Transaction ID lớn nhất hiện có và tăng thêm 1
                string idQuery = "SELECT ISNULL(MAX(id), 0) + 1 FROM [Transaction]";
                int transactionId;

                using (SqlCommand idCommand = new SqlCommand(idQuery, connection))
                {
                    transactionId = (int)idCommand.ExecuteScalar();
                }

                // Thêm dữ liệu vào bảng Transaction
                string query = "INSERT INTO [Transaction] (id, from_account_id, branch_id, date_of_trans, amount, to_account_id, employeeid) " +
                               "VALUES (@transactionId, @fromAccountId, @branchId, @dateOfTrans, @amount, @toAccountId, @employeeId)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@transactionId", transactionId);
                    command.Parameters.AddWithValue("@fromAccountId", fromAccountId);
                    command.Parameters.AddWithValue("@branchId", branchId);
                    command.Parameters.AddWithValue("@dateOfTrans", transactionDate);
                    command.Parameters.AddWithValue("@amount", amount);
                    command.Parameters.AddWithValue("@toAccountId", toAccountId);
                    command.Parameters.AddWithValue("@employeeId", employeeId);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void comboBoxFromAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
           int selectedAccountId = Convert.ToInt32(comboBoxFromAccount.SelectedValue);
           DisplayAccountHolderName(selectedAccountId, txtFromAccountHolderName);
        }


        private void comboBoxToAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedAccountId = Convert.ToInt32(comboBoxToAccount.SelectedValue);
            DisplayAccountHolderName(selectedAccountId, txtToAccountHolderName);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtPin_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTransferAmount_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
