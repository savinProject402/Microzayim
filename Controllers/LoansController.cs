﻿using AutoMapper;
using Microzayim.Domain.Contracts;
using Microzayim.Domain.Models;
using Microzayim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Microzayim.Controllers
{
    [RoutePrefix("Loans")]
    public class LoansController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILoanServices _loanServices;
        private readonly ILoanTransactionServices _loanTransactionServices;

        public LoansController(ILoanServices loanServices, IMapper mapper, ILoanTransactionServices loanTransactionServices)
        {
            _loanServices = loanServices;
            _mapper = mapper;
            _loanTransactionServices = loanTransactionServices;
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(LoanPostModel model)
        {
            var identuty = User.Identity as ClaimsIdentity;
            var userId = identuty.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var createModel = _mapper.Map<LoanModel>(model);
            createModel.CustomerId = userId;
            createModel.Status = 0;
            createModel.CreationDate = DateTime.Now;
            _loanServices.CreateLoan(createModel);

            return new EmptyResult();
        }


        public ActionResult Create()
        {
            return View();
        }

        // GET: Loans
        public ActionResult Index()
        {
            return View();
        }
    }
}