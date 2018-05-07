namespace Alpha.Sample.Reports.Console
{
    using System;
    using System.Collections.Generic;
    using Alpha.Products.Core.Configuration;
    using Alpha.Products.Core.Models;
    using Alpha.Products.Core.Services;
    using Alpha.Products.Reports;
    using Alpha.Products.Reports.Requests;
    using Alpha.RemotingRef;
    using Alpha.Sample.Reports.Console.Integration;

    internal static class Program
    {
        private static void Main()
        {
            try
            {
                StartConfiguration();

                ClearScreen();

                var actor
                    = new Customer(1, 0, "Customer 1", 4, StubCustomerProductStatusGetter.GetActorProductStatus());

                PrintReport(new ReportProductRequest(actor));

                PrintReport(new MatchWinLossDetailProductRequest(actor), "Match Win Loss Detail");

                PrintReport(new PlayForFunProductRequest(actor), "Play For Fun");

                PrintReport(new LegendDisplayProductRequest(actor), "Legend Products");

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        private static void StartConfiguration()
        {
            SimpleServiceLocator
              .Instance
              .Register<Func<IEnumerable<IConfigurationItem>>>(ProductConfiguration.LoadApplicationProductConfiguration)
              .Register<Func<int, string>>(CacheRef.GetProductName);
        }

        private static void ClearScreen()
        {
            CacheRef.GetProductName(1);
            Console.Clear();
        }

        private static void PrintReport(IRequest productRequest, string reportName = "")
        {
            var reportProductFactory = new ReportProductViewModelFactory();
            Console.WriteLine((string.IsNullOrWhiteSpace(reportName) ? "Outstanding Report" : reportName).ToUpperInvariant());
            Console.WriteLine();
            foreach (var product in reportProductFactory.GetViewModels(productRequest))
            {
                Console.WriteLine(product);
            }
            Console.WriteLine("\n\n");
        }
    }
}