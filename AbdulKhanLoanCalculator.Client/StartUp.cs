using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbdulKhanLoanCalculator.Business;
using AbdulKhanLoanCalculator.Model;

namespace AbdulKhanLoanCalculator.Client
{

    public class StartUp
    {

        #region "Constants"
        public const int borrowerminloanRequest = 1000;
        public const int borrowermaxloanRequest = 15000;
        public const int borrowerloanStep = 100;
        #endregion

        #region "Initilization"
        private readonly ICSVReader _csvreaderService;
        private readonly IGetQuoteBorrower _getquoteborrowerService;
        #endregion

        #region "Program Startup and Initial Configuration"


        public StartUp(ICSVReader csvreaderService, 
            IGetQuoteBorrower getquoteborrowerService)
        {
            // Unity has created this instance and resolved all dependencies.
            _csvreaderService = csvreaderService;
            _getquoteborrowerService = getquoteborrowerService;
        }

        public void Run(IList<string> userinput)
        {

            if (userinput == null || userinput.Count < 2)
            {
                throw new ArgumentNullException(nameof(userinput));
            }

            var loanAmount = Validation(userinput[1]);

            var offersFileName = userinput[0];
            var offers = this._csvreaderService.ReadCsv(offersFileName);

            if (offers != null)
            {
                var result = this._getquoteborrowerService.GetBestQuoteForBorrower(loanAmount, offers);

                if (null == result)
                {
                    Console.WriteLine("It is not possible to provide a quote now. Please try it later.");
                }
                else
                {

                    Console.WriteLine($"Requested amount: {result.LoanAmount:c0}");
                    Console.WriteLine($"Rate: {result.Quote:P1}");
                    Console.WriteLine($"Monthly repayment: {result.MonthlyRepayment:c2}");
                    Console.WriteLine($"Total repayment: {result.TotalRepayment:c2}");
                }
            }
            else
            {
             Console.WriteLine("No Offer Found this time.");   
            }


        }
        #endregion


        #region "Client-side validation"
        private static int Validation(string loanrequest)
        {
            int loanamountRequest;

            if (!int.TryParse(loanrequest, out loanamountRequest))
            {
                throw new ArgumentException("Invalid value for loan amount parameter.", nameof(loanamountRequest));
            }

            if (loanamountRequest < borrowerminloanRequest || loanamountRequest > borrowermaxloanRequest)
            {
                throw new ArgumentOutOfRangeException(nameof(loanamountRequest), loanamountRequest, $"Loan amount must be inside the interval of {borrowerminloanRequest} to {borrowermaxloanRequest}.");
            }

            if (loanamountRequest % borrowerloanStep != 0)
            {
                throw new ArgumentException($"Loan amount must be dividable by {borrowerloanStep}.", nameof(loanamountRequest));
            }

            return loanamountRequest;
        }


        #endregion
    }
}
