namespace Alpha.Products.Reports
{
    using System.Collections.Generic;
    using Alpha.Products.Core.Configuration;
    using Alpha.Products.Core.Integration;

    public class ReportConfigurationLoader : DefaultConfigurationLoader
    {
        public ReportConfigurationLoader(IProductJsonConverter jsonConverter)
            : base("Report", jsonConverter)
        {
        }

        protected override IExtendProductProperty BuildExtendProductProperty(IDictionary<string, string> extendedPropertyData)
            => new ReportProperties(
                GetBoolValue(extendedPropertyData, "ShowInLegend"),
                GetBoolValue(extendedPropertyData, "HasMatchInfo"),
                GetBoolValue(extendedPropertyData, "OfferPlayForFun"));
    }
}