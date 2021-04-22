﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microzayim.Domain.Models
{
    public class LoanModel
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int Status { get; set; }
        public int Amount { get; set; }
        public string CustomerId { get; set; }
        public ICollection<LoanTransactionModel> LoanTransactions { get; set; }
    }
}
