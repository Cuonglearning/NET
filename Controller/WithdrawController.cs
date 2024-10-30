using BankDB.Models;

namespace BankDB.Controllers
{
    public class WithdrawController
    {
        private BankDBContext _context;

        public WithdrawController()
        {
            _context = new BankDBContext(new DbContextOptions<BankDBContext>());
        }

        // Phương thức thực hiện rút tiền từ tài khoản
        public bool WithdrawAmount(string accountId, double amount)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.Id == accountId);

            if (account != null && account.Balance >= amount) // Kiểm tra số dư tài khoản
            {
                account.Balance -= amount; // Trừ tiền từ tài khoản
                _context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                return true;
            }
            else
            {
                return false; // Rút tiền thất bại do không đủ số dư
            }
        }
    }
}
