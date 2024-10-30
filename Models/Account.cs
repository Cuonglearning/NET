using System;
using System.Collections.Generic;

namespace BankDB.Models
{
    public partial class Account : IModel
    {
        public string Id { get; set; } = null!;

        public string? Customerid { get; set; }

        public DateOnly? DateOpened { get; set; }

        public double? Balance { get; set; }

        public virtual Customer? Customer { get; set; }

        public virtual ICollection<Transaction> TransactionFromAccounts { get; set; } = new List<Transaction>();

        public virtual ICollection<Transaction> TransactionToAccounts { get; set; } = new List<Transaction>();

        // Implementation of IsValid method from IModel
        public bool IsValid()
        {
            // Ensure Id is not empty, Balance is non-negative, and DateOpened is earlier than the current date
            bool isValidId = !string.IsNullOrEmpty(Id);
            bool isValidBalance = Balance != null && Balance >= 0;
            bool isValidDateOpened = DateOpened != null && DateOpened <= DateOnly.FromDateTime(DateTime.Now);

            return isValidId && isValidBalance && isValidDateOpened;
        }
    }
}
