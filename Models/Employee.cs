using System;
using System.Collections.Generic;

namespace BankDB.Models
{
    public partial class Employee : IModel
    {
        public string Id { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Role { get; set; } = null!;

        public string? Email { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

        // Implementation of IsValid method from IModel
        public bool IsValid()
        {
            // Example validation logic:
            bool isValidId = !string.IsNullOrEmpty(Id);
            bool isValidPassword = !string.IsNullOrEmpty(Password) && Password.Length >= 6; // Password must be at least 6 characters
            bool isValidRole = !string.IsNullOrEmpty(Role);
            bool isValidEmail = !string.IsNullOrEmpty(Email) && Email.Contains("@"); // Basic email validation


            return isValidId && isValidPassword && isValidRole && isValidEmail;
        }
    }
}
