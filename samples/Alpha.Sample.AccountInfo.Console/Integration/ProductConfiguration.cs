namespace Alpha.Sample.AccountInfo.Console.Integration
{
    using System.Collections.Generic;
    using Alpha.Products.AccountInfo;
    using Alpha.Products.Core.Configuration;

    internal static class ProductConfiguration
    {
        /// <summary>
        /// it will be replaced by code loading setting from shared config
        /// </summary>
        /// <returns></returns>
        internal static IEnumerable<IConfigurationItem> LoadApplicationProductConfiguration()
        {
            // This path will be stored in AppSettings on Global
            var loader = new SearchAccountConfigurationLoader(new ProductJsonConverter());

            return loader.LoadProductConfiguration("AccountInfo");
        }
    }
}