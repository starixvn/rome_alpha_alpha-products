namespace Alpha.Products.Core.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Alpha.Products.Core.Integration;

    public interface IConfigurationLoader
    {
        IEnumerable<IConfigurationItem> Load();
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

        public IEnumerable<IConfigurationItem> Load()
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

#pragma warning disable S2696 // Instance members should not write to "static" fields
                cachedConfigurationItems = configurationItems;
#pragma warning restore S2696 // Instance members should not write to "static" fields
            }

            return cachedConfigurationItems;
        }

        internal IConfigurationItem BuildConfigurationItem(string productJson)
        {
            if (string.IsNullOrWhiteSpace(siteName))
            {
                throw new InvalidOperationException(nameof(siteName));
            }

            if (string.IsNullOrWhiteSpace(productJson))
            {
                throw new ArgumentNullException(nameof(productJson));
            }

            var productConfig = jsonConverter.ToExtendProductPropertyData(productJson);
            var productId = int.Parse(productConfig["productId"]);
            var endSupportDate = GetEndSupportDate(productConfig);
            var extendedPropertyData = GetExtendedPropertyData(productConfig);

            return new ConfigurationItem(
                productId,
                productConfig["productName"],
                isProductEnabled(productId),
                endSupportDate,
                BuildExtendProductProperty(extendedPropertyData));
        }

        protected virtual IExtendProductProperty BuildExtendProductProperty(IDictionary<string, string> extendedPropertyData)
            => default(IExtendProductProperty);

        internal static DateTime GetEndSupportDate(IDictionary<string, string> productConfig)
            => productConfig.ContainsKey("endSupportDate")
                            ? DateTime.Parse(productConfig["endSupportDate"])
                            : DateTime.MaxValue;

        internal IDictionary<string, string> GetExtendedPropertyData(IDictionary<string, string> productConfig)
        {
            var extendedPropertyName = $"{siteName}Properties";

            return productConfig.ContainsKey(extendedPropertyName)
                            ? jsonConverter.ToExtendProductPropertyData(productConfig[extendedPropertyName])
                            : new Dictionary<string, string>();
        }

        internal protected T BuildProductProperty<T>(IDictionary<string, string> productPropertyData)
            where T : IExtendProductProperty
        {
            var productPropertyType = typeof(T);

            if (productPropertyType.GetConstructors().Length != 1)
            {
                throw new InvalidOperationException($"{productPropertyType.Name} has more than one public constructor.");
            }

            var constructorInfo = productPropertyType.GetConstructors()[0];
            var constructorValueList = new List<object>();

            foreach (var constructorParam in constructorInfo.GetParameters())
            {
                var paramValue = GetProductPropertyValue(constructorParam, productPropertyData);

                constructorValueList.Add(paramValue);
            }

            return (T)Activator.CreateInstance(productPropertyType, constructorValueList.ToArray());
        }

        internal static object GetProductPropertyValue(ParameterInfo paramInfo, IDictionary<string, string> productPropertyData)
        {
            var propertyData = GetProductPropertyValue(paramInfo.Name, productPropertyData);
            var paramType = paramInfo.ParameterType;

            if (string.Compare(paramType.Name, "Int32", StringComparison.OrdinalIgnoreCase) == 0)
            {
                return int.Parse(propertyData);
            }

            if (string.Compare(paramType.Name, "Boolean", StringComparison.OrdinalIgnoreCase) == 0)
            {
                return bool.Parse(propertyData);
            }

            return propertyData;
        }

        internal static string GetProductPropertyValue(string key, IDictionary<string, string> productPropertyData)
        {
            if (productPropertyData.ContainsKey(key))
            {
                return productPropertyData[key];
            }

            throw new KeyNotFoundException($"Cannot find key \"{key}\" in config");
        }
    }
}