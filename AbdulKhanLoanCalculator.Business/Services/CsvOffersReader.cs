using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using AbdulKhanLoanCalculator.Model;

namespace AbdulKhanLoanCalculator.Business
{
    public class CsvOffersReader : ICSVReader
    {
        public IList<LenderOffer> ReadCsv(string fileName)
        {
            using (var reader = new CsvReader(File.OpenText(fileName)))
            {
                return reader.GetRecords<CsvData>().Select(x => new LenderOffer { Rate = x.Rate, AvailableAmount = x.Available }).ToList();
            }
        }
    }
}
