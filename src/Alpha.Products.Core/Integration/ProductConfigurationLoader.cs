namespace Alpha.Products.Core.Integration
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
        private readonly Func<int, bool> isProductEnabled;
        private readonly IConfigFileReader configFileReader;

        public DefaultProductConfigurationLoader(
            IProductJsonConverter jsonConverter,
            string jsonConfigFileRelativePath = null,
            IConfigFileReader configFileReader = null,
            Func<int, bool> isProductEnabled = null)
        {
            this.productConfigFileRelativePath = jsonConfigFileRelativePath ?? GlobalProductSettings.ProductConfigFileRelativePath;
            this.jsonConverter = jsonConverter;
            this.isProductEnabled = isProductEnabled ?? GlobalProductSettings.IsProductEnabled;
            this.configFileReader = configFileReader ?? new ConfigFileReader();
        }

        public IEnumerable<IConfigurationItem> LoadProductConfiguration(string siteName)
        {
            var productsJsonString = configFileReader.ReadProductConfig(productConfigFileRelativePath);
            var productConfigs = jsonConverter.ToProductConfigs(productsJsonString);
            var configItems = new List<IConfigurationItem>();

            foreach (var productConfig in productConfigs)
            {
                configItems.Add(BuildConfigurationItem(productConfig, siteName));
            }

            return configItems;
        }

        private IConfigurationItem BuildConfigurationItem(string productJson, string siteName)
        {
            var productConfig = jsonConverter.ToDictionary(productJson);
            var productId = int.Parse(productConfig["ProductId"]);
            var productName = productConfig["ProductName"];
            var extendedPropertyName = $"{siteName}Properties";
            var extendedPropertyData = productConfig.ContainsKey(extendedPropertyName)
                ? jsonConverter.ToDictionary(productConfig[extendedPropertyName])
                : new Dictionary<string, string>();

            var configurationItem = new ConfigurationItem(
                productId,
                productName,
                isProductEnabled(productId),
                BuildExtendProductProperty(extendedPropertyData));

            return configurationItem;
        }

        protected virtual IExtendProductProperty BuildExtendProductProperty(IDictionary<string, string> extendedPropertyData)
            => default(IExtendProductProperty);

        protected static bool GetBoolValue(IDictionary<string, string> extendedPropertyData, string key)
            => extendedPropertyData.ContainsKey(key)
                && bool.Parse(extendedPropertyData[key]);
    }
}