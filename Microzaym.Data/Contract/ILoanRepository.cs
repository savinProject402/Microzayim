using Microzaym.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microzaym.Data.Contract
{
    public interface ILoanRepository
    {
        IReadOnlyCollection<Loan> GetAll();         //  Admin Select All Credits
        Loan GetById(int id);                       //  Admin Select ById Credits
        void UpdateLoan(Loan model);               //  Admin Approve Credits
        void CreateLoan(Loan model);                // Client Create Credit 
    }
}
