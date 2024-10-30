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
    public partial class Employee : Form
    {
        private string connectionString = "Server=localhost;Database=NET;Integrated Security=True;";
        public Employee()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Employee_Load(object sender, EventArgs e)
        {
            LoadEmployeeData();
        }
        private void LoadEmployeeData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Mở kết nối
                    connection.Open();

                    // Câu lệnh SQL để lấy dữ liệu từ bảng employees
                    string query = "SELECT * FROM Employee";

                    // Tạo SqlDataAdapter để lấy dữ liệu
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    // Tạo DataTable để chứa dữ liệu
                    DataTable dataTable = new DataTable();

                    // Đổ dữ liệu từ dataAdapter vào dataTable
                    dataAdapter.Fill(dataTable);

                    // Gán DataTable cho DataGridView
                    dataGridViewEmployee.DataSource = dataTable;

                    // Đóng kết nối
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow row = dataGridViewEmployee.Rows[e.RowIndex];

                // Hiển thị dữ liệu lên các TextBox tương ứng
                txtEmployeeID.Text = row.Cells["id"].Value.ToString();
                txtEmployeeName.Text = row.Cells["EmployeeName"].Value.ToString();
                txtPassword.Text = row.Cells["PassWord"].Value.ToString();

                // Kiểm tra vai trò (Role) của nhân viên và đánh dấu radio button tương ứng
                string role = row.Cells["Role"].Value.ToString();

                if (role == "Admin")
                {
                    radioAdmin.Checked = true;
                    radioEmployee.Checked = false;
                }
                else if (role == "Employee")
                {
                    radioAdmin.Checked = false;
                    radioEmployee.Checked = true;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmployeeID.Text) ||
                string.IsNullOrWhiteSpace(txtEmployeeName.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill all infomation!", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác định vai trò (Role) của nhân viên, mặc định là Employee nếu không chọn radio button nào
            string role = radioAdmin.Checked ? "Admin" : "Employee";

            try
            {
                using (SqlConnection connection = new SqlConnection("Server=DESKTOP-KQS8PTG;Database=NET;Integrated Security=True;"))
                {
                    connection.Open();

                    // Kiểm tra xem EmployeeID có tồn tại trong cơ sở dữ liệu không
                    string checkQuery = "SELECT COUNT(*) FROM Employee WHERE id = @EmployeeID";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text);

                    int count = (int)checkCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        // Nếu EmployeeID đã tồn tại, thực hiện cập nhật thông tin
                        string updateQuery = "UPDATE Employee SET EmployeeName = @EmployeeName, PassWord = @PassWord, Role = @Role WHERE id = @EmployeeID";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@EmployeeName", txtEmployeeName.Text);
                        updateCommand.Parameters.AddWithValue("@PassWord", txtPassword.Text);
                        updateCommand.Parameters.AddWithValue("@Role", role);
                        updateCommand.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text);

                        updateCommand.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Nếu EmployeeID chưa tồn tại, thực hiện thêm mới nhân viên
                        string insertQuery = "INSERT INTO Employee (id, EmployeeName, PassWord, Role) VALUES (@EmployeeID, @EmployeeName, @PassWord, @Role)";
                        SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                        insertCommand.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text);
                        insertCommand.Parameters.AddWithValue("@EmployeeName", txtEmployeeName.Text);
                        insertCommand.Parameters.AddWithValue("@PassWord", txtPassword.Text);
                        insertCommand.Parameters.AddWithValue("@Role", role);

                        insertCommand.ExecuteNonQuery();
                        MessageBox.Show("Successful add employee!", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    connection.Close();

                    // Tải lại dữ liệu vào DataGridView sau khi lưu
                    LoadEmployeeData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmployeeID.Text))
            {
                MessageBox.Show("Please choose employee to delete!", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận trước khi xóa
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this employee?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection("Server=DESKTOP-KQS8PTG;Database=NET;Integrated Security=True;"))
                    {
                        connection.Open();

                        // Thực hiện câu lệnh xóa nhân viên
                        string deleteQuery = "DELETE FROM Employee WHERE id = @EmployeeID";
                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                        deleteCommand.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text);

                        int rowsAffected = deleteCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Delete employee successful!", "Accouncement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Can't find this employee!", "Accouncement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        connection.Close();

                        // Tải lại dữ liệu vào DataGridView sau khi xóa
                        LoadEmployeeData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Accouncement", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
