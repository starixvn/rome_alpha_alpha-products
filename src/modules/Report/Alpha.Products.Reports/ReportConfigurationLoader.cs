namespace Alpha.Products.Reports
{
    using System.Collections.Generic;
    using Alpha.Products.Core.Configuration;
    using Alpha.Products.Integration.Helpers;

    public class ReportConfigurationLoader : DefaultProductConfigurationLoader
    {
        public ReportConfigurationLoader(string jsonConfigFileRelativePath, IProductJsonConverter jsonConverter)
            : base(jsonConfigFileRelativePath, jsonConverter)
        {
        }

        protected override IExtendProductProperty GetExtendProductProperty(IDictionary<string, string> extendedPropertyData)
            => new ReportProperties(
                GetBoolValue(extendedPropertyData, "ShowInLegend"),
                GetBoolValue(extendedPropertyData, "HasMatchInfo"),
                GetBoolValue(extendedPropertyData, "OfferPlayForFun"));
    }
}