using Autofac;
using Autofac.Integration.Mvc;
using Microzayim.Domain.Contracts;
using Microzayim.Domain.Services;
using Microzaym.Data.Contract;
using Microzaym.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Microzayim.App_Start
{
    public class AutofacConfig
    {
		public static void ConfigureConteiner()
		{
			var builder = new ContainerBuilder();

			builder.RegisterControllers(typeof(MvcApplication).Assembly);
			builder.RegisterType<LoanServices>().As<ILoanServices>();
			builder.RegisterType<LoanTransactionServices>().As<ILoanTransactionServices>();
			builder.RegisterType<LoanRepository>().As<ILoanRepository>();
			builder.RegisterType<LoanTransactionRepository>().As<ILoanTransactionRepository>();
			builder.RegisterModule<AutoMapperModule>();
			var conteiner = builder.Build();

			DependencyResolver.SetResolver(new AutofacDependencyResolver(conteiner));
		}
	}
}