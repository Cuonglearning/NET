using BankDB.Models;

namespace BankDB.Controllers
{
    public class DepositController
    {
        private readonly BankDBContext _dbContext;

        public DepositController()
        {
            _dbContext = new BankDBContext(new DbContextOptions<BankDBContext>());
        }

        // Phương thức để nạp tiền vào tài khoản
        public bool DepositAmount(string accountId, double amount)
        {
            var account = _dbContext.Accounts.Find(accountId);

            if (account != null && amount > 0)
            {
                account.Balance += amount; // Cộng tiền vào số dư hiện tại
                _dbContext.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                return true;
            }

            return false;
        }
    }
}
