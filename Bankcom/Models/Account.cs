using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankcom.Models
{
    public enum AccountType
    {
        Savings,
        Current,
        Business
    }
    internal class Account
    {
        public int AccountNumber { get; set; }
        public AccountType Type { get; set; }
        public DateTime OpeningDate { get; set; }
        public decimal CurrentBalance { get; set; }
        public int BranchId { get; set; }
        public Branch? Branch { get; set; }

        public ICollection<CustomerAccount> CustomerAccounts { get; set; } = new HashSet<CustomerAccount>();
        public ICollection<Transaction> Transactions { get; set; } = new HashSet<Transaction>();

    }
}
