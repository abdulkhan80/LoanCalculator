using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbdulKhanLoanCalculator.Model;

namespace AbdulKhanLoanCalculator.Business
{
    public interface ICSVReader
    {
        IList<LenderOffer> ReadCsv(string fileName);
    }
}
