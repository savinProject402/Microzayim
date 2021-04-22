using Microzaym.Data.Contract;
using Microzaym.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Microzaym.Data.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        public void CreateLoan(Loan model)
        {
            using (var ctx = new MicrozayimContext())
            {
                ctx.Loans.Add(model);
                ctx.SaveChanges();
            }
        }

        public IReadOnlyCollection<Loan> GetAll()
        {
            using (var ctx = new MicrozayimContext())
            {
                return ctx.Loans
                    .AsNoTracking()
                    .ToList();
            }
        }

        public Loan GetById(int id)
        {
            using (var ctx = new MicrozayimContext())
            {
                return ctx.Loans.Include(x => x.LoanTransactions)
                          .FirstOrDefault(x => x.Id == id);
            }
        }

        public void UpdateLoan(Loan model)
        {
            using (var ctx = new MicrozayimContext())
            {
                var upAmount = ctx.Loans.FirstOrDefault(x => x.Id == model.Id);
                upAmount.Amount = model.Amount;
                upAmount.Status = model.Status;
                ctx.SaveChanges();
            }
        }
    }
}
