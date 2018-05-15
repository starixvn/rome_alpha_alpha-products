namespace Alpha.Products.Reports
{
    using System.Collections.Generic;
    using Alpha.Products.Core.Configuration;
    using Alpha.Products.Core.Integration;

    public class ReportConfigurationLoader : DefaultConfigurationLoader
    {
        public ReportConfigurationLoader(IProductJsonConverter jsonConverter)
            : base("report", jsonConverter)
        {
        }

        protected override IExtendProductProperty BuildExtendProductProperty(IDictionary<string, string> extendedPropertyData)
            => BuildProductProperty<ReportProperties>(extendedPropertyData);
    }
}