using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbdulKhanLoanCalculator.Business
{
    public class Calculator : ICalculator
    {
        public int add(int a, int b)
        {
            return a + b;
        }
    }
}
