using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankcom.Models
{
    public enum TransactionType
    {
        Deposit,
        Withdrawal,
        Transfer,
        Payment
    }
    internal class Transaction
    {
        public int TransactionNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public string? Note { get; set; }
        public int AccountNumber { get; set; }
        public Account AccountTransaction  { get; set; }=default!;
    }
}
