using System;
using System.Collections.Generic;

namespace BankDB.Models
{
    public partial class Transaction : IModel
    {
        public int Id { get; set; }

        public string FromAccountId { get; set; } = null!;

        public string BranchId { get; set; } = null!;

        public DateOnly DateOfTrans { get; set; }

        public double Amount { get; set; }

        public string Pin { get; set; } = null!;

        public string ToAccountId { get; set; } = null!;

        public string EmployeeId { get; set; } = null!;

        public virtual Branch Branch { get; set; } = null!;

        public virtual Employee Employee { get; set; } = null!;

        public virtual Account FromAccount { get; set; } = null!;

        public virtual Account ToAccount { get; set; } = null!;

        // Implementation of IsValid method from IModel
        public bool IsValid()
        {
            // Example validation logic:
            bool isValidFromAccountId = !string.IsNullOrEmpty(FromAccountId);
            bool isValidBranchId = !string.IsNullOrEmpty(BranchId);
            bool isValidDateOfTrans = DateOfTrans <= DateOnly.FromDateTime(DateTime.Now); // Date should not be in the future
            bool isValidAmount = Amount > 0; // Amount should be positive
            bool isValidPin = !string.IsNullOrEmpty(Pin) && Pin.Length == 6; // Assuming PIN is 6 digits
            bool isValidToAccountId = !string.IsNullOrEmpty(ToAccountId);
            bool isValidEmployeeId = !string.IsNullOrEmpty(EmployeeId);

            return isValidFromAccountId && isValidBranchId && isValidDateOfTrans && isValidAmount &&
                   isValidPin && isValidToAccountId && isValidEmployeeId;
        }
    }
}
