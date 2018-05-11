namespace Alpha.Products.Integration.Helpers
{
    using System;
    using System.Collections.Generic;
    using Alpha.Products.Core.Configuration;

    public interface IProductConfigurationLoader
    {
        IEnumerable<IConfigurationItem> LoadProductConfiguration(string siteName);
    }

    /// <summary>
    /// Default we will load data from json file, in the future we can read from db/service
    /// </summary>
    public class DefaultProductConfigurationLoader : IProductConfigurationLoader
    {
        private readonly IProductJsonConverter jsonConverter;
        private readonly string productConfigFileRelativePath;
        private readonly Func<int, bool> isProductEnableFunc;
        private readonly IJsonFileReader jsonFileReader;

        public DefaultProductConfigurationLoader(
            IProductJsonConverter jsonConverter,
            string jsonConfigFileRelativePath = null,
            IJsonFileReader jsonFileReader = null,
            Func<int, bool> isProductEnableFunc = null)
        {
            this.productConfigFileRelativePath = jsonConfigFileRelativePath ?? GlobalProductSettings.ProductConfigFileRelativePath;
            this.jsonConverter = jsonConverter;
            this.isProductEnableFunc = isProductEnableFunc ?? GlobalProductSettings.IsProductEnabled;
            this.jsonFileReader = jsonFileReader ?? new JsonFileReader();
        }

        public IEnumerable<IConfigurationItem> LoadProductConfiguration(string siteName)
        {
            var productsJsonString = jsonFileReader.ReadProductJsonConfig(productConfigFileRelativePath);
            var productConfigs = jsonConverter.DeserializeToProductConfigs(productsJsonString);
            var configItems = new List<IConfigurationItem>();

            foreach (var productConfig in productConfigs)
            {
                configItems.Add(BuildConfigurationItem(productConfig, siteName));
            }

            return configItems;
        }

        private IConfigurationItem BuildConfigurationItem(string productJson, string siteName)
        {
            var productConfig = jsonConverter.DeserializeToDictionary(productJson);
            var productId = int.Parse(productConfig["ProductId"]);
            var productName = productConfig["ProductName"];
            var extendedPropertyName = $"{siteName}Properties";
            var extendedPropertyData = productConfig.ContainsKey(extendedPropertyName)
                ? jsonConverter.DeserializeToDictionary(productConfig[extendedPropertyName])
                : new Dictionary<string, string>();

            var configurationItem = new ConfigurationItem(
                productId,
                productName,
                isProductEnableFunc(productId),
                BuildExtendProductProperty(extendedPropertyData));

            return configurationItem;
        }

        protected virtual IExtendProductProperty BuildExtendProductProperty(IDictionary<string, string> extendedPropertyData)
            => null;

        protected static bool GetBoolValue(IDictionary<string, string> extendedPropertyData, string key)
            => extendedPropertyData.ContainsKey(key)
                && bool.Parse(extendedPropertyData[key]);
    }
}