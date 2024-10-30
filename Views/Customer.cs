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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nETDataSet2.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter2.Fill(this.nETDataSet2.Customer);
            // TODO: This line of code loads data into the 'nETDataSet2.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.nETDataSet2.Employee);
            // TODO: This line of code loads data into the 'nETDataSet1.Customer' table. You can move, or remove it, as needed.
            
        }
     

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private SqlConnection connection = new SqlConnection("Server=DESKTOP-KQS8PTG;Database=NET;Integrated Security=True;");

        private void LoadCustomerData()
        {
            string query = "SELECT * FROM Customer";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridViewCustomer.DataSource = dataTable;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPhone.Text) ||
        string.IsNullOrEmpty(txtAdress.Text) || string.IsNullOrEmpty(txtCity.Text) ||
        string.IsNullOrEmpty(txtEmail.Text) )
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            string query;

            // Kiểm tra nếu ID đã được nhập
            if (!string.IsNullOrEmpty(txtID.Text))
            {
                // Kiểm tra xem ID có tồn tại trong cơ sở dữ liệu không
                if (IsCustomerExists(Convert.ToInt32(txtID.Text)))
                {
                    // ID tồn tại, cập nhật bản ghi
                    query = "UPDATE Customer SET name = @Name, house_no = @Address, phone = @Phone, city = @City, email = @Email WHERE id = @ID";
                }
                else
                {
                    // ID không tồn tại, thêm mới bản ghi
                    query = "INSERT INTO Customer (name, house_no, phone, city, email) VALUES (@Name, @Address, @Phone, @City, @Email)";
                }
            }
            else
            {
                // ID để trống, thêm mới bản ghi
                query = "INSERT INTO Customer (name, house_no, phone, city, email) VALUES (@Name, @Address, @Phone, @City, @Email)";
            }

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", txtName.Text);
                command.Parameters.AddWithValue("@Address", txtAdress.Text);
                command.Parameters.AddWithValue("@Phone", txtPhone.Text);
                command.Parameters.AddWithValue("@City", txtCity.Text);
                command.Parameters.AddWithValue("@Email", txtEmail.Text);

                if (!string.IsNullOrEmpty(txtID.Text) && query.Contains("UPDATE"))
                {
                    command.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID.Text));
                }

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            LoadCustomerData();
        }

        // Phương thức kiểm tra ID đã tồn tại chưa
        private bool IsCustomerExists(int id)
        {
            string query = "SELECT COUNT(1) FROM Customer WHERE id = @ID";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", id);
                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
                return count > 0;
            }
        }

        private void dataGridViewCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewCustomer.Rows[e.RowIndex];
                txtID.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtPhone.Text = row.Cells[2].Value.ToString();
                txtAdress.Text = row.Cells[4].Value.ToString();
                txtCity.Text = row.Cells[5].Value.ToString();
                txtEmail.Text = row.Cells[3].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Please choose a customer to delete!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận trước khi xóa
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this customer?", "Delete confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection("Server=DESKTOP-KQS8PTG;Database=NET;Integrated Security=True;"))
                    {
                        connection.Open();

                        // Thực hiện câu lệnh xóa nhân viên
                        string deleteQuery = "DELETE FROM Customer WHERE id = @EmployeeID";
                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                        deleteCommand.Parameters.AddWithValue("@EmployeeID", txtID.Text);

                        int rowsAffected = deleteCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Delete customer successful!", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Can't find customer to delete!", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        connection.Close();

                        // Tải lại dữ liệu vào DataGridView sau khi xóa
                        LoadCustomerData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
