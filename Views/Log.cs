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
    public partial class Log : Form
    {
        public Log()
        {
            InitializeComponent();
        }

        private void transactionBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.transactionBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.nETDataSet2);

        }

        private void Log_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nETDataSet2.Transaction' table. You can move, or remove it, as needed.
            this.transactionTableAdapter.Fill(this.nETDataSet2.Transaction);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void transactionDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dòng hiện tại người dùng chọn
                DataGridViewRow row = transactionDataGridView.Rows[e.RowIndex];

                // Hiển thị dữ liệu của dòng lên các TextBox tương ứng
                txtID.Text = row.Cells[0].Value?.ToString();
            }
        }
        SqlConnection connection = new SqlConnection("Server=DESKTOP-KQS8PTG;Database=NET;Integrated Security=True;");
        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text))
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this log?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int accountId = int.Parse(txtID.Text);
                    string query = "DELETE FROM [Transaction] WHERE id = @AccountId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AccountId", accountId);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }

                    MessageBox.Show("Log deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAccountData();
                }
            }
            else
            {
                MessageBox.Show("Please select a log to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadAccountData()
        {
            string query = "SELECT id, from_account_id, branch_id, date_of_trans, amount, pin, to_account_id, employeeid FROM [Transaction]";
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
            {
                DataTable accountTable = new DataTable();
                adapter.Fill(accountTable);
                transactionDataGridView.DataSource = accountTable;
            }
        }
    }
}
