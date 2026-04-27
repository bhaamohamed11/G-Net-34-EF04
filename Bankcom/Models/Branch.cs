using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankcom.Models
{
    internal class Branch
    {
        public int BranchId { get; set; }
        public string BranchCode { get; set; }

        public string BranchName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int MangerId { get; set; }
        public Manger Manger { get; set; } = default!;
       
        public ICollection<Account>BranchAccounts { get; set; }=default!;


    }
}
