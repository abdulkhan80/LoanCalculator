using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbdulKhanLoanCalculator.Model;

namespace AbdulKhanLoanCalculator.Business
{
    public interface IGetQuoteBorrower
    {
        BorrowerLoanOffer GetBestQuoteForBorrower(int loanAmount, IList<LenderOffer> offers);
    }
}
