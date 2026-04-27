using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankcom.Models
{
    public enum OwnershipType
    {
       Primary, CoHolder
    }
    public enum AccountStatus
    {
        Active,Closed
        
    }
    internal class CustomerAccount
    {

        public DateTime  OwnerShipDate { get; set; }
        public OwnershipType OwnershipType { get; set; }
        public AccountStatus AccountStatus { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = default!;
        public int AccountNumber { get; set; }
        public Account Account { get; set; } = default!;
    }
}
