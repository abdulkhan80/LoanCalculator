using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AbdulKhanLoanCalculator.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var container = new UnityContainer();
                container.RegisterType<StartUp, StartUp>();

                // Registering my all dependencies..
                UnityConfig.RegisterTypes(container);
                // Let Unity resolve StartUp and create a build plan.
                var program = container.Resolve<StartUp>();

                program.Run(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }

            Console.ReadKey();
        }

    }//end class...   
}//end ns...

