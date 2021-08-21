using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AbdulKhanLoanCalculator.Model;

namespace AbdulKhanLoanCalculator.Business
{
    public class GetQuoteBorrower : IGetQuoteBorrower
    {
        #region "Constants"
        public const int LoanLengthInMonths = 36;
        #endregion

        public BorrowerLoanOffer GetBestQuoteForBorrower(int loanAmount, IList<LenderOffer> offers)
        {

            if (offers.Sum(x => x.AvailableAmount) < loanAmount)
            {
                return null;
            }

            var totalRepayment = CalculateTotalToPay(loanAmount, offers);

            var quote = (totalRepayment - loanAmount) / loanAmount;

            var monthlyRepayment = loanAmount * (1 + quote) / LoanLengthInMonths;

            return new BorrowerLoanOffer()
            {
                LoanAmount = loanAmount,
                Quote = quote,
                MonthlyRepayment = monthlyRepayment,
                TotalRepayment = totalRepayment
            };
        }

        private static decimal CalculateTotalToPay(int loanAmount, IEnumerable<LenderOffer> offers)
        {
            var borrowed = 0;
            var totalTopay = 0m;

            foreach (var offer in offers.OrderBy(x => x.Rate))
            {
                var amountToBorrow = loanAmount < borrowed + offer.AvailableAmount ? loanAmount - borrowed : offer.AvailableAmount;

                totalTopay += amountToBorrow + (amountToBorrow * offer.Rate);

                if ((borrowed += amountToBorrow) >= loanAmount)
                {
                    break;
                }
            }

            return totalTopay;
        }

    }
}
