using System;
using System.Collections.Generic;

namespace BankDB.Models
{
    public partial class Branch : IModel
    {
        public string Id { get; set; } = null!;

        public string? Name { get; set; }

        public string? HouseNo { get; set; }

        public string? City { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

        // Implementation of IsValid method from IModel
        public bool IsValid()
        {
            // Example validation logic:
            bool isValidId = !string.IsNullOrEmpty(Id);
            bool isValidName = !string.IsNullOrEmpty(Name);
            bool isValidHouseNo = !string.IsNullOrEmpty(HouseNo);
            bool isValidCity = !string.IsNullOrEmpty(City);

            return isValidId && isValidName && isValidHouseNo && isValidCity;
        }
    }
}

