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
    public partial class CreateAccount : Form
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                int accountId = int.Parse(txtAccountID.Text);
                int customerId = Convert.ToInt32(comboBoxCustomerID.SelectedValue);
                decimal balance = decimal.Parse(txtBalance.Text);
                string pin = txtPin.Text;
                DateTime dateOpened = DateTime.Now;

                // Kiểm tra nếu AccountID đã tồn tại trong cơ sở dữ liệu
                if (AccountExists(accountId))
                {
                    MessageBox.Show("Account ID already exists. Please enter a unique ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = "INSERT INTO Account (id, customerid, balance, pin, date_opened) VALUES (@AccountId, @CustomerId, @Balance, @Pin, @DateOpened)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AccountId", accountId);
                    command.Parameters.AddWithValue("@CustomerId", customerId);
                    command.Parameters.AddWithValue("@Balance", balance);
                    command.Parameters.AddWithValue("@Pin", pin);
                    command.Parameters.AddWithValue("@DateOpened", dateOpened);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                DialogResult result = MessageBox.Show("Account created successfully! Would you like to create another account?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    ClearFields(); // Làm sạch các trường nếu người dùng chọn Yes
                }
                else
                {
                    this.Close(); // Đóng form nếu người dùng chọn No
                }
            }
        }
        private bool AccountExists(int accountId)
        {
            string query = "SELECT COUNT(1) FROM Account WHERE id = @AccountId";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@AccountId", accountId);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                connection.Close();
                return count > 0;
            }
        }

        // Hàm kiểm tra các trường dữ liệu
        private bool ValidateFields()
        {
            if (string.IsNullOrEmpty(txtAccountID.Text) || comboBoxCustomerID.SelectedIndex == -1 || string.IsNullOrEmpty(txtBalance.Text) || string.IsNullOrEmpty(txtPin.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // Hàm để làm sạch các trường
        private void ClearFields()
        {
            txtAccountID.Clear();
            comboBoxCustomerID.SelectedIndex = -1;
            txtCustomerName.Clear();
            txtBalance.Clear();
            txtPin.Clear();
        }

        private void CreateAccount_Load(object sender, EventArgs e)
        {
            LoadCustomerIDs();
            comboBoxCustomerID.SelectedIndexChanged += comboBoxCustomerID_SelectedIndexChanged;
        }
        private void LoadCustomerIDs()
        {
            string query = "SELECT id, name FROM Customer";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable customerTable = new DataTable();
                adapter.Fill(customerTable);

                comboBoxCustomerID.DataSource = customerTable;
                comboBoxCustomerID.DisplayMember = "id";
                comboBoxCustomerID.ValueMember = "id";
                txtCustomerName.Clear();
            }
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {

        }
        private SqlConnection connection = new SqlConnection("Server=DESKTOP-KQS8PTG;Database=NET;Integrated Security=True;");
        private void comboBoxCustomerID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCustomerID.SelectedValue != null && int.TryParse(comboBoxCustomerID.SelectedValue.ToString(), out int customerId))
            {
                string query = "SELECT name FROM Customer WHERE id = @CustomerId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);
                    connection.Open();
                    txtCustomerName.Text = command.ExecuteScalar()?.ToString();
                    connection.Close();
                }
            }
        }

    }
}
