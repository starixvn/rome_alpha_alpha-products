namespace Alpha.Products.AccountInfo
{
    using System.Collections.Generic;
    using Alpha.Products.Core.Configuration;
    using Alpha.Products.Core.Integration;

    public class SearchAccountConfigurationLoader : DefaultConfigurationLoader
    {
        public SearchAccountConfigurationLoader(IProductJsonConverter jsonConverter)
            : base("AccountInfo", jsonConverter)
        {
        }

        protected override IExtendProductProperty BuildExtendProductProperty(IDictionary<string, string> extendedPropertyData)
            => new SearchAccountProperties(
                GetBoolValue(extendedPropertyData, "Setting"),
                GetBoolValue(extendedPropertyData, "Status"));
    }
}