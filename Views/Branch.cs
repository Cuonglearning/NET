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
    public partial class Branch : Form
    {
        public Branch()
        {
            InitializeComponent();
        }

        private void branchBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.branchBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.nETDataSet2);

        }

        private void Branch_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nETDataSet2.Branch' table. You can move, or remove it, as needed.
            this.branchTableAdapter.Fill(this.nETDataSet2.Branch);
            LoadBranchData();
        }

        private void LoadBranchData()
        {
            using (SqlConnection connection = new SqlConnection("Server=DESKTOP-KQS8PTG;Database=NET;Integrated Security=True;"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Branch", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable branchesTable = new DataTable();
                adapter.Fill(branchesTable);

                dataGridViewBranches.DataSource = branchesTable;
            }
        }

        private void dataGridViewBranches_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dòng hiện tại người dùng chọn
                DataGridViewRow row = dataGridViewBranches.Rows[e.RowIndex];

                // Hiển thị dữ liệu của dòng lên các TextBox tương ứng
                txtID.Text = row.Cells[0].Value?.ToString();
                txtName.Text = row.Cells[1].Value?.ToString();
                txtHouseNo.Text = row.Cells[2].Value?.ToString();
                txtCity.Text = row.Cells[3].Value?.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) || string.IsNullOrWhiteSpace(txtName.Text) ||
        string.IsNullOrWhiteSpace(txtHouseNo.Text) || string.IsNullOrWhiteSpace(txtCity.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            using (SqlConnection connection = new SqlConnection("Server=DESKTOP-KQS8PTG;Database=NET;Integrated Security=True;"))
            {
                connection.Open();
                SqlCommand command;

                // Kiểm tra xem ID đã tồn tại chưa
                command = new SqlCommand("SELECT COUNT(*) FROM Branch WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", txtID.Text);
                int count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    // Nếu đã tồn tại, cập nhật thông tin
                    command = new SqlCommand("UPDATE Branch SET name = @name, house_no = @house_no, city = @city WHERE id = @id", connection);
                    command.Parameters.AddWithValue("@name", txtName.Text);
                    command.Parameters.AddWithValue("@house_no", txtHouseNo.Text);
                    command.Parameters.AddWithValue("@city", txtCity.Text);
                    command.Parameters.AddWithValue("@id", txtID.Text);
                }
                else
                {
                    // Nếu không tồn tại, thêm mới
                    command = new SqlCommand("INSERT INTO Branch (id, name, house_no, city) VALUES (@id, @name, @house_no, @city)", connection);
                    command.Parameters.AddWithValue("@id", txtID.Text);
                    command.Parameters.AddWithValue("@name", txtName.Text);
                    command.Parameters.AddWithValue("@house_no", txtHouseNo.Text);
                    command.Parameters.AddWithValue("@city", txtCity.Text);
                }

                command.ExecuteNonQuery();
                MessageBox.Show("Branch saved successfully.");
                LoadBranchData(); // Tải lại dữ liệu
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Please select a branch to delete.");
                return;
            }

            // Xác nhận trước khi xóa
            var confirmResult = MessageBox.Show("Are you sure to delete this branch?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection("Server=DESKTOP-KQS8PTG;Database=NET;Integrated Security=True;"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("DELETE FROM Branch WHERE id = @id", connection);
                    command.Parameters.AddWithValue("@id", txtID.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Branch deleted successfully.");
                    LoadBranchData(); // Tải lại dữ liệu
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
