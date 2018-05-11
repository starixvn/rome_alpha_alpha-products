namespace Alpha.Products.AccountInfo
{
    using System.Collections.Generic;
    using Alpha.Products.Core.Configuration;
    using Alpha.Products.Integration.Helpers;

    public class SearchAccountConfigurationLoader : DefaultProductConfigurationLoader
    {
        public SearchAccountConfigurationLoader(string jsonConfigFileRelativePath, IProductJsonConverter jsonConverter)
            : base(jsonConfigFileRelativePath, jsonConverter)
        {
        }

        protected override IExtendProductProperty GetExtendProductProperty(IDictionary<string, string> extendedPropertyData)
            => new SearchAccountProperties(
                GetBoolValue(extendedPropertyData, "Setting"),
                GetBoolValue(extendedPropertyData, "Status"));
    }
}