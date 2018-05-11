namespace Alpha.Products.Core.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Alpha.Products.Core.Services;

    public interface ConfigurationService
    {
        IEnumerable<int> GetEnabledProductIds();

        IEnumerable<int> GetEnabledProductIds(Func<IConfigurationItem, bool> predicate);

        IEnumerable<IConfigurationItem> GetEnabledProductItems(Func<IConfigurationItem, bool> predicate);
    }

    internal class ConfigurationServiceImpl : ConfigurationService
    {
        private readonly IEnumerable<int> ExcludedProductIds;
        private static IReadOnlyCollection<IConfigurationItem> ConfigurationDataSource;

        internal ConfigurationServiceImpl(
            Func<IEnumerable<IConfigurationItem>> GetApplicationProductConfiguration = null,
            params int[] excludedProductIds)
        {
            var productConfigurationService
                = GetApplicationProductConfiguration
                ?? SimpleServiceLocator.GetService<Func<IEnumerable<IConfigurationItem>>>();

            if (ConfigurationDataSource == null || ConfigurationDataSource.Count == 0)
            {
#pragma warning disable S3010 // Static fields should not be updated in constructors
                ConfigurationDataSource = new ReadOnlyCollection<IConfigurationItem>(productConfigurationService().ToList());
#pragma warning restore S3010 // Static fields should not be updated in constructors
            }

            ExcludedProductIds = excludedProductIds ?? Enumerable.Empty<int>();
        }

        private Func<IConfigurationItem, bool> DefaultPredicate
            => config => config.EndSupportDate >= DateTime.Now
                            && !ExcludedProductIds.Contains(config.ProductId);

        public IEnumerable<IConfigurationItem> GetEnabledProductItems(Func<IConfigurationItem, bool> predicate)
            => ConfigurationDataSource
                .Where(configItem => 
                    configItem.Enabled 
                    && (predicate ?? DefaultPredicate)(configItem));

        public IEnumerable<int> GetEnabledProductIds(Func<IConfigurationItem, bool> predicate)
            => GetEnabledProductItems(predicate)
                .Select(configuration => configuration.ProductId);

        public IEnumerable<int> GetEnabledProductIds()
            => GetEnabledProductIds(null);
    }
}