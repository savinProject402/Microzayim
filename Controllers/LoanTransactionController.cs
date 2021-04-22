using AutoMapper;
using Microzayim.Domain.Contracts;
using Microzayim.Domain.Models;
using Microzayim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Microzayim.Controllers
{
    [RoutePrefix("LoanTransaction")]
    public class LoanTransactionController : Controller
    {

        private readonly ILoanTransactionServices _loanTransactionServices;
        private readonly IMapper _mapper;

        public LoanTransactionController(IMapper mapper, ILoanTransactionServices loanTransactionServices)
        {
            _mapper = mapper;
            _loanTransactionServices = loanTransactionServices;
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(LoanTransactionPostModel model)
        {

            var createtransactionModel = _mapper.Map<LoanTransactionModel>(model);
            _loanTransactionServices.CreateTransaction(createtransactionModel);

            return View();
        }





        public ActionResult Create()
        {
            return View();
        }


        // GET: LoanTransaction
        public ActionResult Index()
        {
            return View();
        }
    }
}