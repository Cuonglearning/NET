using BankDB.Models;
using System;
using System.Linq;

namespace BankDB.Controllers
{
    public class TransactionController
    {
        private BankDBContext _context;

        public TransactionController()
        {
            _context = new BankDBContext(new DbContextOptions<BankDBContext>());
        }

        // Chuyển tiền từ một tài khoản sang tài khoản khác
        public bool Transfer(string fromAccountId, string toAccountId, double amount, string pin, string branchId, string employeeId)
        {
            // Kiểm tra xem số tiền có hợp lệ không
            if (amount <= 0) return false;

            // Tìm tài khoản người gửi
            var fromAccount = _context.Accounts.Find(fromAccountId);
            if (fromAccount == null || fromAccount.Balance < amount) return false;

            // Tìm tài khoản người nhận
            var toAccount = _context.Accounts.Find(toAccountId);
            if (toAccount == null) return false;

            // Kiểm tra mã PIN của tài khoản người gửi (giả sử có sẵn logic kiểm tra mã PIN)
            // if (!ValidatePin(fromAccount, pin)) return false;

            // Trừ số tiền từ tài khoản người gửi
            fromAccount.Balance -= amount;

            // Cộng số tiền vào tài khoản người nhận
            toAccount.Balance += amount;

            // Tạo một bản ghi giao dịch
            var transaction = new Transaction
            {
                FromAccountId = fromAccountId,
                ToAccountId = toAccountId,
                Amount = amount,
                DateOfTrans = DateOnly.FromDateTime(DateTime.Now),
                Pin = pin,
                BranchId = branchId,
                EmployeeId = employeeId,
            };

            // Thêm giao dịch vào bảng Transaction
            _context.Transactions.Add(transaction);

            // Lưu thay đổi
            _context.SaveChanges();
            return true;
        }

        // Lấy danh sách tất cả các giao dịch
        public List<Transaction> GetAllTransactions()
        {
            return _context.Transactions.Include(t => t.FromAccount).Include(t => t.ToAccount).ToList();
        }

        // Lấy thông tin giao dịch theo ID
        public Transaction GetTransactionById(int id)
        {
            return _context.Transactions.Find(id);
        }
        public List<Transaction> GetTransactionsById(string id)
        {
            return _context.Transactions
                .Include(t => t.FromAccount)
                .Include(t => t.ToAccount)
                .Where(t => t.FromAccountId == id)
                .ToList();
        }
        public bool Transfer(Transaction transaction)
        {
            // Kiểm tra tài khoản gửi và tài khoản nhận có tồn tại không
            var fromAccount = _context.Accounts.FirstOrDefault(a => a.Id == transaction.FromAccountId);
            var toAccount = _context.Accounts.FirstOrDefault(a => a.Id == transaction.ToAccountId);

            if (fromAccount != null && toAccount != null && fromAccount.Balance >= transaction.Amount)
            {
                // Trừ tiền từ tài khoản gửi và cộng tiền vào tài khoản nhận
                fromAccount.Balance -= transaction.Amount;
                toAccount.Balance += transaction.Amount;

                // Thêm giao dịch vào database
                _context.Transactions.Add(transaction);

                // Lưu thay đổi vào database
                _context.SaveChanges();
                return true;
            }

            // Giao dịch không thành công
            return false;
        }

    }
}
