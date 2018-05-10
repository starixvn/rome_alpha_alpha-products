namespace Alpha.Sample.Reports.Console.Integration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Alpha.Products.Core.Configuration;
    using Alpha.Products.Integration;

    public class ReportsConfigurationItem : ConfigurationItem
    {
        public ReportsConfigurationItem(int productId, string productName)
            : base(productId, productName, GlobalProductSettings.IsProductEnabled(productId), null)
        {
        }


    }
}
