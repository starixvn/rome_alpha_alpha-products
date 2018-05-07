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
                ConfigurationDataSource = new ReadOnlyCollection<IConfigurationItem>(productConfigurationService().ToList());
            }

            ExcludedProductIds = excludedProductIds ?? Enumerable.Empty<int>();
        }

        private Func<IConfigurationItem, bool> DefaultPredicate
            => config => config.Enabled
                            && config.EndSupportDate >= DateTime.Now
                            && !ExcludedProductIds.Contains(config.ProductId);

        public IEnumerable<IConfigurationItem> GetEnabledProductItems(Func<IConfigurationItem, bool> predicate)
            => ConfigurationDataSource
                .Where(predicate ?? DefaultPredicate);

        public IEnumerable<int> GetEnabledProductIds(Func<IConfigurationItem, bool> predicate)
            => GetEnabledProductItems(predicate)
                .Select(configuration => configuration.ProductId);

        public IEnumerable<int> GetEnabledProductIds()
            => GetEnabledProductIds(null);
    }
}