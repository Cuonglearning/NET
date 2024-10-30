using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banking
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.ShowDialog();
            if (loginForm.DialogResult == DialogResult.OK)
            {
                // Hiển thị các mục khác trong MenuStrip
                foreach (ToolStripMenuItem item in menuStrip1.Items)
                {
                    item.Enabled = true; // Hiển thị mục chính

                    // Hiển thị các mục thả xuống bên trong (nếu có)
                    foreach (ToolStripItem dropDownItem in item.DropDownItems)
                    {
                        dropDownItem.Enabled = true;
                    }
                }

                // Ẩn lại nút Login để không cho phép đăng nhập lại
                loginToolStripMenuItem.Enabled = false;
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Confirm log out",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Nếu người dùng chọn Yes, thực hiện đăng xuất
            if (result == DialogResult.Yes)
            {
                // Ẩn các mục thả xuống bên trong (nếu có), giữ lại các mục chính
                foreach (ToolStripMenuItem item in menuStrip1.Items)
                {
                    // Ẩn các mục thả xuống bên trong mục chính
                    foreach (ToolStripItem dropDownItem in item.DropDownItems)
                    {
                        dropDownItem.Enabled = false;
                    }
                }

                // Hiển thị lại nút Login trong mục thả xuống
                loginToolStripMenuItem.Enabled = true;
                exitToolStripMenuItem.Enabled = true;

                // Ẩn nút Logout trong mục thả xuống
                logoutToolStripMenuItem.Enabled = false;

                // Hiển thị thông báo đăng xuất
                MessageBox.Show("Logged out successful.");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to quit?",
                "Confirm close",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
        );

            // Nếu người dùng chọn Yes, thoát chương trình
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.ShowDialog();
        }

        private void createAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer customer =new Customer();
            customer.ShowDialog();
        }

        private void transactionAmountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transaction transaction = new Transaction();
            transaction.ShowDialog();
        }

        private void createAccountToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateAccount createAccount = new CreateAccount();
            createAccount.ShowDialog();
        }

        private void balanceAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountBalance accountBalance = new AccountBalance();
            accountBalance.ShowDialog();
        }

        private void depositAmountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Deposit deposit = new Deposit();
            deposit.ShowDialog();
        }

        private void branchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Branch branch = new Branch();
            branch.ShowDialog();
        }

        private void withdrawalAmountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Withdraw withdrawalAmount = new Withdraw();
            withdrawalAmount.ShowDialog();
        }

        private void transactionLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log log = new Log();
            log.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
