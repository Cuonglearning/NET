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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            CheckLoginButtonEnabled();
        }
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            CheckLoginButtonEnabled();
        }

        private void CheckLoginButtonEnabled()
        {
            // Kiểm tra nếu cả hai trường đều không rỗng thì hiển thị nút Login
            btnLogin.Enabled = !string.IsNullOrWhiteSpace(txtUserName.Text) && !string.IsNullOrWhiteSpace(txtPassword.Text);
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        public static int LoggedInEmployeeId;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Chuỗi kết nối đến SQL Server với Windows Authentication
            string connectionString = "Server=DESKTOP-KQS8PTG;Database=NET;Integrated Security=True;";

            // Tạo câu lệnh SQL để kiểm tra thông tin đăng nhập
            string query = "SELECT id FROM Employee WHERE EmployeeName = @UserName AND PassWord = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm các tham số vào câu truy vấn
                        command.Parameters.AddWithValue("@UserName", userName);
                        command.Parameters.AddWithValue("@Password", password);

                        // Thực hiện truy vấn và lấy kết quả
                        //int count = Convert.ToInt32(command.ExecuteScalar());
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            LoggedInEmployeeId = Convert.ToInt32(result);
                            // Đăng nhập thành công
                            MessageBox.Show("Logged in successful!");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            // Đăng nhập thất bại
                            MessageBox.Show("Incorrect name or password.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
