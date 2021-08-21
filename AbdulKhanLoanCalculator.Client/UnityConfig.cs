using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using AbdulKhanLoanCalculator.Business;

namespace AbdulKhanLoanCalculator.Client
{
    internal static class UnityConfig
    {
        internal static void RegisterTypes(UnityContainer container)
        {
            container.RegisterType<ICSVReader, CsvOffersReader>();
            container.RegisterType<IGetQuoteBorrower, GetQuoteBorrower>();
        }
    }
}
