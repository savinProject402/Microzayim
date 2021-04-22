﻿using Autofac;
using AutoMapper;
using Microzayim.Domain.Models;
using Microzayim.Models;
using Microzaym.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microzayim.App_Start
{
    public class AutoMapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => new MapperConfiguration(cfg => {

                cfg.CreateMap<LoanPostModel, LoanModel>(MemberList.Destination);
                cfg.CreateMap<LoanModel, LoanPostModel>(MemberList.Destination);
                cfg.CreateMap<Loan, LoanPostModel>(MemberList.Destination);
                cfg.CreateMap<LoanModel, Loan>(MemberList.Destination);
                cfg.CreateMap<Loan, LoanModel>(MemberList.Destination);
                cfg.CreateMap<Loan, LoanPostModel>(MemberList.Destination);
                cfg.CreateMap<LoanPostModel, Loan>(MemberList.Destination);

                cfg.CreateMap<LoanTransaction, LoanModel>(MemberList.Destination);
                cfg.CreateMap<LoanTransactionModel, LoanModel>(MemberList.Destination);
                cfg.CreateMap<LoanModel, LoanTransactionModel>(MemberList.Destination);
                cfg.CreateMap<LoanTransactionModel, Loan>(MemberList.Destination);

                cfg.CreateMap<LoanTransactionPostModel, LoanTransactionModel>(MemberList.Destination);
                cfg.CreateMap<LoanTransactionModel, LoanTransactionPostModel>(MemberList.Destination);
                cfg.CreateMap<LoanTransaction, LoanTransactionPostModel>(MemberList.Destination);
                cfg.CreateMap<LoanTransactionModel, LoanTransaction>(MemberList.Destination);
                cfg.CreateMap<LoanTransaction, LoanTransactionModel>(MemberList.Destination);
                cfg.CreateMap<LoanTransaction, LoanTransactionPostModel>(MemberList.Destination);
                cfg.CreateMap<LoanTransactionPostModel, LoanTransaction>(MemberList.Destination);


            }));
            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}