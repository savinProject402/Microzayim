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
    public class LoanServices : ILoanServices
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;

        public LoanServices(IMapper mapper, ILoanRepository loanRepository)
        {
            _mapper = mapper;
            _loanRepository = loanRepository;
        }

        public void CreateLoan(LoanModel model)
        {
            var createLoan = _mapper.Map<Loan>(model);
            model.Status = 0;
            model.CreationDate = DateTime.Now;


            var custLoans = _loanRepository.GetAll()
                .Where(x => model.Status == 0 && x.CustomerId == model.CustomerId);

            if (custLoans.Count() > 2)
            {
                throw new Exception("Sorry you have MAX Count Loans");
            }

            _loanRepository.CreateLoan(createLoan);
        }

        public IReadOnlyCollection<LoanModel> GetAll()
        {
            var loan = _loanRepository.GetAll();
            var result = _mapper.Map<IReadOnlyCollection<LoanModel>>(loan);

            return result;
        }

        public LoanModel GetById(int id)
        {
            var loanGetById = _loanRepository.GetById(id);
            var result = _mapper.Map<LoanModel>(loanGetById);

            return result;
        }

        public void UpdateLoan(LoanModel model)
        {
            var updateLoan = _mapper.Map<Loan>(model);
            _loanRepository.UpdateLoan(updateLoan);
        }
    }
}
