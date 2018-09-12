namespace Alpha.Products.AccountInfo
{
    using System.Collections.Generic;
    using Alpha.Products.Core.Configuration;
    using Alpha.Products.Core.Integration;

    public class SearchAccountConfigurationLoader : DefaultConfigurationLoader
    {
        public SearchAccountConfigurationLoader(IProductJsonConverter jsonConverter, string jsonConfigFileRelativePath = null)
            : base("accountInfo", jsonConverter, jsonConfigFileRelativePath)
        {
        }

        protected override IExtendProductProperty BuildExtendProductProperty(IDictionary<string, string> extendedPropertyData)
            => BuildProductProperty<SearchAccountProperties>(extendedPropertyData);
    }
}