using AutoMapper;
using Microzayim.Domain.Contracts;
using Microzayim.Domain.Models;
using Microzaym.Data.Contract;
using Microzaym.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microzayim.Domain.Services
{
    public class LoanTransactionServices : ILoanTransactionServices
    {
        private readonly IMapper _mapper;
        private readonly ILoanTransactionRepository _loanTransactionRepository;
        private readonly ILoanRepository _loanRepository;
        public LoanTransactionServices(ILoanTransactionRepository loanTransactionRepository, IMapper mapper, ILoanRepository loanRepository)
        {
            _loanTransactionRepository = loanTransactionRepository;
            _mapper = mapper;
            _loanRepository = loanRepository;
        }

        public void CreateTransaction(LoanTransactionModel model)
        {
            model.CreationDate = DateTime.Now;
            model.Status = 0;

            var createTransaction = _mapper.Map<LoanTransaction>(model);
            _loanTransactionRepository.CreateTransaction(createTransaction);


            var loan = _loanRepository.GetById(createTransaction.LoansId);


            if (loan.LoanTransactions.Sum(x => x.Amount) >= loan.Amount)
            {
                loan.Status = 1;
                _loanRepository.UpdateLoan(loan);
            }
        }
    }
}
