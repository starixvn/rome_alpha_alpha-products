namespace Alpha.Products.Core.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Alpha.Products.Core.Integration;

    public interface IConfigurationLoader
    {
        IEnumerable<IConfigurationItem> LoadConfiguration();
    }

    /// <summary>
    /// Default we will load data from json file, in the future we can read from db/service
    /// </summary>
    public class DefaultConfigurationLoader : IConfigurationLoader
    {
        private readonly IProductJsonConverter jsonConverter;
        private readonly string productConfigFileRelativePath;
        private readonly Func<int, bool> isProductEnabled;
        private readonly IConfigFileReader configFileReader;
        private static IEnumerable<IConfigurationItem> cachedConfigurationItems;
        private readonly string siteName;

        public DefaultConfigurationLoader(
            string siteName,
            IProductJsonConverter jsonConverter,
            string jsonConfigFileRelativePath = null,
            IConfigFileReader configFileReader = null,
            Func<int, bool> isProductEnabled = null)
        {
            this.siteName = siteName;
            this.productConfigFileRelativePath = jsonConfigFileRelativePath ?? GlobalProductSettings.ProductConfigFileRelativePath;
            this.jsonConverter = jsonConverter;
            this.isProductEnabled = isProductEnabled ?? GlobalProductSettings.IsProductEnabled;
            this.configFileReader = configFileReader ?? new ConfigFileReader();
        }

        public IEnumerable<IConfigurationItem> LoadConfiguration()
        {
            if (cachedConfigurationItems == null || !cachedConfigurationItems.Any())
            {
                var productsJsonString = configFileReader.ReadProductConfig(productConfigFileRelativePath);
                var productConfigs = jsonConverter.ToProductConfigs(productsJsonString);
                var configurationItems = new List<IConfigurationItem>();

                foreach (var productConfig in productConfigs)
                {
                    configurationItems.Add(BuildConfigurationItem(productConfig));
                }

                cachedConfigurationItems = configurationItems;
            }

            return cachedConfigurationItems;
        }

        private IConfigurationItem BuildConfigurationItem(string productJson)
        {
            if (string.IsNullOrWhiteSpace(siteName))
            {
                throw new InvalidOperationException(nameof(siteName));
            }

            if (string.IsNullOrWhiteSpace(productJson))
            {
                throw new ArgumentNullException(nameof(productJson));
            }

            var productConfig = jsonConverter.ToDictionary(productJson);
            var productId = int.Parse(productConfig["ProductId"]);
            var productName = productConfig["ProductName"];
            var endSupportDate = GetEndSupportDate(productConfig);
            var extendedPropertyData = GetExtendedPropertyData(productConfig);

            var configurationItem = new ConfigurationItem(
                productId,
                productName,
                isProductEnabled(productId),
                endSupportDate,
                BuildExtendProductProperty(extendedPropertyData));

            return configurationItem;
        }

        private static DateTime GetEndSupportDate(IDictionary<string, string> productConfig)
            => productConfig.ContainsKey("EndSupportDate")
                            ? DateTime.Parse(productConfig["EndSupportDate"])
                            : DateTime.MaxValue;

        private IDictionary<string, string> GetExtendedPropertyData(IDictionary<string, string> productConfig)
        {
            var extendedPropertyName = $"{siteName}Properties";

            return productConfig.ContainsKey(extendedPropertyName)
                            ? jsonConverter.ToDictionary(productConfig[extendedPropertyName])
                            : new Dictionary<string, string>();
        }

        protected virtual IExtendProductProperty BuildExtendProductProperty(IDictionary<string, string> extendedPropertyData)
            => default(IExtendProductProperty);

        protected static bool GetBoolValue(IDictionary<string, string> extendedPropertyData, string key)
            => extendedPropertyData.ContainsKey(key)
                && bool.Parse(extendedPropertyData[key]);
    }
}