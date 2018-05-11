namespace Alpha.Products.AccountInfo
{
    using System.Collections.Generic;
    using Alpha.Products.Core.Configuration;
    using Alpha.Products.Integration.Helpers;

    public class SearchAccountConfigurationLoader : DefaultProductConfigurationLoader
    {
        public SearchAccountConfigurationLoader(IProductJsonConverter jsonConverter)
            : base(jsonConverter)
        {
        }

        protected override IExtendProductProperty BuildExtendProductProperty(IDictionary<string, string> extendedPropertyData)
            => new SearchAccountProperties(
                GetBoolValue(extendedPropertyData, "Setting"),
                GetBoolValue(extendedPropertyData, "Status"));
    }
}