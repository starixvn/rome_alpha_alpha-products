namespace Alpha.Products.Integration.Helpers
{
    using System;
    using System.Collections.Generic;
    using Alpha.Products.Core.Configuration;

    public interface IProductConfigurationLoader
    {
        IList<IConfigurationItem> LoadApplicationProductConfiguration(string siteName);
    }

    /// <summary>
    /// Default we will load data from json file, in the future we can read from db/service
    /// </summary>
    public class DefaultProductConfigurationLoader : IProductConfigurationLoader
    {
        private readonly IProductJsonConverter jsonConverter;
        private readonly string jsonConfigFileRelativePath;
        private readonly Func<int, bool> isProductEnableFunc;
        private readonly IJsonFileReader jsonFileReader;

        public DefaultProductConfigurationLoader(
            string jsonConfigFileRelativePath,
            IProductJsonConverter jsonConverter, 
            IJsonFileReader jsonFileReader = null,
            Func<int, bool> isProductEnableFunc = null)
        {
            this.jsonConfigFileRelativePath = jsonConfigFileRelativePath;
            this.jsonConverter = jsonConverter;
            this.isProductEnableFunc = isProductEnableFunc ?? GlobalProductSettings.IsProductEnabled;
            this.jsonFileReader = jsonFileReader ?? new JsonFileReader();
        }

        public IList<IConfigurationItem> LoadApplicationProductConfiguration(string siteName)
        {
            var productsJsonString = jsonFileReader.ReadProductJsonConfig(jsonConfigFileRelativePath);
            var productConfigs = jsonConverter.DeserializeToProductConfigs(productsJsonString);
            var configItems = new List<IConfigurationItem>();

            foreach (var productConfig in productConfigs)
            {
                configItems.Add(GetConfigurationItem(productConfig, siteName));
            }

            return configItems;
        }

        private IConfigurationItem GetConfigurationItem(string productJson, string siteName)
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
                GetExtendProductProperty(extendedPropertyData));

            return configurationItem;
        }

        protected virtual IExtendProductProperty GetExtendProductProperty(IDictionary<string, string> extendedPropertyData)
            => null;

        protected static bool GetBoolValue(IDictionary<string, string> extendedPropertyData, string key)
            => extendedPropertyData.ContainsKey(key)
                && bool.Parse(extendedPropertyData[key]);
    }
}