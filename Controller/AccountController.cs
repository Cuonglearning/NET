
using BankDB.Models;
using System.Collections.Generic;
using System.Linq;
namespace BankDB.Controllers
{
    public class AccountController : IController1
    {
        private BankDBContext _dbContext;

        public AccountController()
        {
            //_dbContext = new BankDBContext(new DbContextOptions<BankDBContext>());
        }

        // List of items for IController1
        public List<IModel> Items => _dbContext.Accounts.Cast<IModel>().ToList();

        // Create method (add new account)
        public bool Create(IModel model)
        {
            var account = model as Account;

            if (account != null)
            {
                // Kiểm tra tính hợp lệ của đối tượng Account trước khi lưu
                if (account.IsValid())
                {
                    _dbContext.Accounts.Add(account);
                   // _dbContext.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                    return true;
                }
                else
                {
                    // Nếu không hợp lệ, trả về false hoặc thông báo lỗi
                   // Console.WriteLine("Thông tin tài khoản không hợp lệ.");
                    return false;
                }
            }

            return false;
        }

        // Read account by ID
        public IModel Read(object id)
        {
            var accountId = id as string;
            return _dbContext.Accounts.Include(a => a.Customer)
                .FirstOrDefault(a => a.Id == accountId); // Includes customer information
        }

        // Update existing account
        public bool Update(IModel model)
        {
            var updatedAccount = model as Account;
            if (updatedAccount != null)
            {
                var existingAccount = _dbContext.Accounts.FirstOrDefault(a => a.Id == updatedAccount.Id);
                if (existingAccount != null)
                {
                    if (existingAccount.IsValid())
                    {
                        existingAccount.Customerid = updatedAccount.Customerid;
                        existingAccount.DateOpened = updatedAccount.DateOpened;
                        existingAccount.Balance = updatedAccount.Balance;

                        _dbContext.Accounts.Update(existingAccount);
                        //_dbContext.SaveChanges(); // Save changes to the database
                        return true;
                    }
                   
                }
            }
            return false;
        }

        // Delete account by ID
        public bool Delete(object id)
        {
            var accountId = id as string;
            var account = _dbContext.Accounts.FirstOrDefault(a => a.Id == accountId);
            if (account != null)
            {
                _dbContext.Accounts.Remove(account); // Save changes to the database
                return true;
            }
            return false;
        }

        // Load all accounts
        public bool Load()
        {
            // Loading all accounts from the database
            var accounts = _dbContext.Accounts.ToList();
            //return accounts.Count > 0;
            return accounts;
        }

        // Load account by ID
        public bool Load(object id)
        {
            var customerId = id as string;

            // Kiểm tra nếu khách hàng có tồn tại
            var customer = _dbContext.Accounts.FirstOrDefault(c => c.Id == customerId);
            if (customer != null)
            {
                // Xóa danh sách hiện tại và thêm khách hàng đã tìm thấy vào Items
                Items.Clear();
                Items.Add(customer);
                return true; // Trả về true nếu tìm thấy khách hàng
            }

            return false; // Trả về false nếu không tìm thấy
        }

        // Check if account exists by ID
        public bool IsExist(object id)
        {
            var accountId = id as string;
            return _dbContext.Accounts.Any(a => a.Id == accountId);
        }

        // Check if the account exists using IModel
        public bool IsExist(IModel model)
        {
            var account = model as Account;
            if (account != null)
            {
                return _dbContext.Accounts.Any(a => a.Id == account.Id);
            }
            return false;
        }

        // Get account balance by ID
        public double? GetAccountBalance(string accountId)
        {
            var account = _dbContext.Accounts.FirstOrDefault(a => a.Id == accountId);
            return account?.Balance; // Returns balance or null if account not found
        }
    }
}
