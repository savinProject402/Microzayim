using Microzayim.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microzayim.Domain.Contracts
{
    public interface ILoanServices
    {
        IReadOnlyCollection<LoanModel> GetAll();         //  Admin Select All Credits
        LoanModel GetById(int id);                       //  Admin Select ById Credits
        void UpdateLoan(LoanModel model);               //  Admin Approve Credits
        void CreateLoan(LoanModel model);                // Client Create Credit 
    }
}
