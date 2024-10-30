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
    public partial class Deposit : Form
    {
        public Deposit()
        {
            InitializeComponent();
        }

        private void Deposit_Load(object sender, EventArgs e)
        {
            LoadAccounts();
            LoadBranches();
        }
        private void LoadAccounts()
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
        private void LoadBranches()
        {
            using (SqlConnection connection = new SqlConnection("Server=DESKTOP-KQS8PTG;Database=NET;Integrated Security=True;"))
            {
                connection.Open();

                // Lấy danh sách chi nhánh
                SqlCommand command = new SqlCommand("SELECT id FROM branch", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                comboBoxBranchID.DataSource = dataTable;
                comboBoxBranchID.DisplayMember = "id"; // Tên hiển thị
                comboBoxBranchID.ValueMember = "id"; // Giá trị của ComboBox

                // Đăng ký sự kiện SelectedIndexChanged
                comboBoxBranchID.SelectedIndexChanged += comboBoxBranchID_SelectedIndexChanged;
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
                        textBoxCustomerName.Text = result != null ? result.ToString() : "N/A"; // Hiển thị tên khách hàng
                    }
                }
            }
            else
            {
                textBoxCustomerName.Text = string.Empty; // Xóa tên khách hàng nếu không có giá trị
            }
        }

        private void comboBoxBranchID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBranchID.SelectedValue != null)
            {
                // Sử dụng nullable int
                int? selectedBranchId = comboBoxBranchID.SelectedValue as int?;

                if (selectedBranchId.HasValue)
                {
                    using (SqlConnection connection = new SqlConnection("Server=DESKTOP-KQS8PTG;Database=NET;Integrated Security=True;"))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("SELECT name FROM branch WHERE id = @BranchId", connection);
                        command.Parameters.AddWithValue("@BranchId", selectedBranchId.Value);

                        object result = command.ExecuteScalar();
                        textBoxBranchName.Text = result != null ? result.ToString() : "N/A"; // Hiển thị tên chi nhánh
                    }
                }
            }
            else
            {
                textBoxBranchName.Text = string.Empty; // Xóa tên chi nhánh nếu không có giá trị
            }
        }

        private void buttonDeposit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxAmount.Text))
            {
                MessageBox.Show("Please enter the amount to deposit.");
                return;
            }

            decimal amountToDeposit;
            if (!decimal.TryParse(textBoxAmount.Text, out amountToDeposit) || amountToDeposit <= 0)
            {
                MessageBox.Show("Please enter a valid amount.");
                return;
            }

            int selectedAccountId = (int)comboBoxAccountID.SelectedValue;

            if (MessageBox.Show("Are you sure you want to deposit this amount?", "Confirm Deposit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection("Server=DESKTOP-KQS8PTG;Database=NET;Integrated Security=True;"))
                {
                    connection.Open();

                    // Cập nhật số dư tài khoản
                    SqlCommand command = new SqlCommand("UPDATE account SET balance = balance + @Amount WHERE id = @AccountId", connection);
                    command.Parameters.AddWithValue("@Amount", amountToDeposit);
                    command.Parameters.AddWithValue("@AccountId", selectedAccountId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Deposit successful!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to deposit. Account ID may not exist.");
                    }
                }
            }
        }

    }
}
