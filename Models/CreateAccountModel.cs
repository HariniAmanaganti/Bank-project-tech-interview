using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace UserTests.Models
{
    public class CreateAccountModel
    {
        public string AccountNumber { set; get; }
        public string AccountName { set; get; }
        public string AccountType { set; get; }
        public int InitialDeposit { set; get; }
        public int SSN { set; get; }
        public string createddate { set; get; }
        public string IsAccountCreated { set; get; }
    
        public int Amount { set; get; }
        public int CurrentBalance { set; get; }
        public int TransactionId { set; get; }
    }
}
