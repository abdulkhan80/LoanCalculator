using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using AbdulKhanLoanCalculator.Business;
using AbdulKhanLoanCalculator.Model;

namespace AbdulKhanLoanCalculator.Test
{
    [TestClass]
    public class LoanOfferTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void If_OfferLoan_Null_Test()
        {
            var quoteloan = new GetQuoteBorrower() as IGetQuoteBorrower;
            var result = quoteloan.GetBestQuoteForBorrower(1, null);
        }

        [TestMethod]
        public void ShouldReturnLoanAmount_Test()
        {
            var quoteloan = new GetQuoteBorrower() as IGetQuoteBorrower;

            var result = quoteloan.GetBestQuoteForBorrower(1000, new List<LenderOffer> { new LenderOffer { AvailableAmount = 1000 } });

            Assert.IsNotNull(result);
            Assert.AreEqual(1000, result.LoanAmount);
        }

        [TestMethod]
        public void CalculateLowestQuoteRateFromOffers_ForLoanRequested_1_Test()
        {
            decimal expResult = 0.10m;
            int loanAmount = 1000;
            var getOffer = OfferTestRepoTest1();

            var quoteloan = new GetQuoteBorrower() as IGetQuoteBorrower;

            var result = quoteloan.GetBestQuoteForBorrower(loanAmount, getOffer);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Quote, expResult);
        }

        [TestMethod]
        public void CalculateLowestQuoteRateFromOffers_ForLoanRequested_2_Test()
        {
            decimal expResult = 0.40m;
            int loanAmount = 1500;
            var getOffer = OfferTestRepoTest2();

            var quoteloan = new GetQuoteBorrower() as IGetQuoteBorrower;

            var result = quoteloan.GetBestQuoteForBorrower(loanAmount, getOffer);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Quote, expResult);
        }

        [TestMethod]
        public void CalculateMonthlyRepayment_ForLoanRequested_Test()
        {
            decimal expResult = 50m;
            int loanAmount = 1000;
            var getOffer = MonthlyRepaymentTestRepo();

            var quoteloan = new GetQuoteBorrower() as IGetQuoteBorrower;

            var result = quoteloan.GetBestQuoteForBorrower(loanAmount, getOffer);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.MonthlyRepayment, expResult);
        }

        [TestMethod]
        public void CalculateTotalRepayment_ForLoanRequested_Test()
        {
            decimal expResult = 1800m;
            int loanAmount = 1000;
            var getOffer = TotalRepaymentTestRepo();

            var quoteloan = new GetQuoteBorrower() as IGetQuoteBorrower;

            var result = quoteloan.GetBestQuoteForBorrower(loanAmount, getOffer);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.TotalRepayment, expResult);
        }

        [TestMethod]
        public void IfLoanNot_Not_Found_Best_Quoate_Test()
        {
            var quoteloan = new GetQuoteBorrower() as IGetQuoteBorrower;

            var result = quoteloan.GetBestQuoteForBorrower(2000, new List<LenderOffer> { new LenderOffer { Rate = 0.5m, AvailableAmount = 1000 } });

            Assert.IsNull(result);
        }

        #region "TestData"
        private IList<LenderOffer> OfferTestRepoTest1()
        {
            var getBestOfferData = new List<LenderOffer>
            {
                new LenderOffer {Rate = 0.10m, AvailableAmount = 1000}
            };

            return getBestOfferData;
        }
        private IList<LenderOffer> OfferTestRepoTest2()
        {
            var getBestOfferData = new List<LenderOffer>
            {
                new LenderOffer {Rate = 0.60m, AvailableAmount = 1500},
                new LenderOffer {Rate = 0.50m, AvailableAmount = 1000},
                new LenderOffer {Rate = 0.20m, AvailableAmount = 500}
            };

            return getBestOfferData;
        }

        private IList<LenderOffer> MonthlyRepaymentTestRepo()
        {
            var monthlyRepaymentTest = new List<LenderOffer>
            {
                new LenderOffer {Rate = 0.80m, AvailableAmount = 1000}
            };

            return monthlyRepaymentTest;
        }

        private IList<LenderOffer> TotalRepaymentTestRepo()
        {
            var totalRepaymentTestData = new List<LenderOffer>
            {
                new LenderOffer {Rate = 0.80m, AvailableAmount = 1000}
            };

            return totalRepaymentTestData;

        }
        #endregion

    }
}
