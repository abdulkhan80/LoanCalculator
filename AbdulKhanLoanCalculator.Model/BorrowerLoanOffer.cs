using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbdulKhanLoanCalculator.Model
{
    public class BorrowerLoanOffer
    {
        public int LoanAmount { get; set; }

        public decimal Quote { get; set; }

        public decimal MonthlyRepayment { get; set; }

        public decimal TotalRepayment { get; set; }
    }
}
