using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microzayim.Models
{
    public class LoanViewModel
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int Status { get; set; }
        public int Amount { get; set; }
        public string CustomerId { get; set; }
    }
}