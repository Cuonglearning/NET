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
    public partial class AccountBalance : Form
    {
        public AccountBalance()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void accountBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.accountBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.nETDataSet2);

        }

        private void AccountBalance_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nETDataSet2.Account' table. You can move, or remove it, as needed.
            this.accountTableAdapter.Fill(this.nETDataSet2.Account);

        }
       
        SqlConnection connection = new SqlConnection("Server=DESKTOP-KQS8PTG;Database=NET;Integrated Security=True;");
        private void accountDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dòng hiện tại người dùng chọn
                DataGridViewRow row = dataGridViewAccounts.Rows[e.RowIndex];

                // Hiển thị dữ liệu của dòng lên các TextBox tương ứng
                txtAccountID.Text = row.Cells[0].Value?.ToString();
                txtCustomerID.Text = row.Cells[1].Value?.ToString();
                txtDateOpened.Text = row.Cells[2].Value?.ToString();
                txtBalance.Text = row.Cells[3].Value?.ToString();
                txtPin.Text = row.Cells[4].Value?.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAccountID.Text))
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this account?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int accountId = int.Parse(txtAccountID.Text);
                    string query = "DELETE FROM Account WHERE id = @AccountId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AccountId", accountId);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }

                    MessageBox.Show("Account deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAccountData(); // Tải lại dữ liệu lên DataGridView
                    ClearFields(); // Xóa các trường thông tin
                }
            }
            else
            {
                MessageBox.Show("Please select an account to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadAccountData()
        {
            string query = "SELECT id, customerid, date_opened, balance, pin FROM Account";
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
            {
                DataTable accountTable = new DataTable();
                adapter.Fill(accountTable);
                dataGridViewAccounts.DataSource = accountTable;
            }
        }

        private void ClearFields()
        {
            txtAccountID.Clear();
            txtCustomerID.Clear();
            txtDateOpened.Clear();
            txtBalance.Clear();
            txtPin.Clear();
        }

    }
}
