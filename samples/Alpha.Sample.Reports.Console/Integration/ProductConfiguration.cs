namespace Alpha.Sample.Reports.Console.Integration
{
    using System.Collections.Generic;
    using Alpha.Products.Core.Configuration;
    using Alpha.Products.Reports;

    public static class ProductConfiguration
    {
        internal static IEnumerable<IConfigurationItem> LoadApplicationProductConfiguration()
        {
            // This path will be stored in AppSettings on Global
            var loader = new ReportConfigurationLoader(new ProductJsonConverter());

            return loader.LoadProductConfiguration("Report");
        }
    }
}