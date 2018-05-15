namespace Alpha.Products.Core.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Alpha.Products.Core.Integration;
    using Alpha.Products.Core.Services;

    public interface ConfigurationService
    {
        IEnumerable<int> GetEnabledProductIds(Func<IConfigurationItem, bool> predicate);

        IEnumerable<IConfigurationItem> GetEnabledProductItems(Func<IConfigurationItem, bool> predicate);
    }

    public class ConfigurationServiceImpl : ConfigurationService
    {
        private readonly IConfigurationLoader configurationLoader;
        private readonly IDateTimeWrapper dateTimeWrapper;

        public ConfigurationServiceImpl(
            IConfigurationLoader configurationLoader = null,
            IDateTimeWrapper dateTimeWrapper = null)
        {
            this.configurationLoader = configurationLoader ?? SimpleServiceLocator.GetService<IConfigurationLoader>();
            this.dateTimeWrapper = dateTimeWrapper ?? new DateTimeWrapper();
        }

        public IEnumerable<IConfigurationItem> GetEnabledProductItems(Func<IConfigurationItem, bool> predicate)
            => configurationLoader
                .LoadConfiguration()
                .Where(configItem =>
                    configItem.Enabled
                    && configItem.EndSupportDate >= dateTimeWrapper.Now
                    && (predicate == null || predicate(configItem)));

        public IEnumerable<int> GetEnabledProductIds(Func<IConfigurationItem, bool> predicate)
            => GetEnabledProductItems(predicate)
                .Select(configuration => configuration.ProductId);
    }
}