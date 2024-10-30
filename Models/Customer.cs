using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankDB.Models
{
    public partial class Customer : IModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = null!;

        public string? Name { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? HouseNo { get; set; }

        public string? City { get; set; }

        public string? Pin { get; set; }

        public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

        // Implementation of IsValid method from IModel
        public bool IsValid()
        {
            // Example validation logic:
         
            bool isValidName = !string.IsNullOrEmpty(Name);
            bool isValidPhone = !string.IsNullOrEmpty(Phone) && Phone.Length == 10; // Assuming 10 digits
            bool isValidEmail = !string.IsNullOrEmpty(Email) && Email.Contains("@"); // Basic email validation
            bool isValidHouseNo = !string.IsNullOrEmpty(HouseNo);
            bool isValidCity = !string.IsNullOrEmpty(City);
            bool isValidPin = !string.IsNullOrEmpty(Pin) && Pin.Length == 6; // Assuming 6 digits for PIN

            return  isValidName && isValidPhone && isValidEmail && isValidHouseNo && isValidCity && isValidPin;
        }
    }
}
