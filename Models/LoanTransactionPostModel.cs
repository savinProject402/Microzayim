using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microzayim.Models
{
    public class LoanTransactionPostModel
    {
        public int Amount { get; set; }

        public int LoansId { get; set; }
    }
}