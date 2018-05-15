namespace Alpha.Products.Core.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Alpha.Products.Core.Services;

    public interface ConfigurationService
    {
        IEnumerable<int> GetEnabledProductIds(Func<IConfigurationItem, bool> predicate);

        IEnumerable<IConfigurationItem> GetEnabledProductItems(Func<IConfigurationItem, bool> predicate);
    }

    internal class ConfigurationServiceImpl : ConfigurationService
    {
        private readonly IConfigurationLoader configurationLoader;
        private readonly Func<DateTime> dateTimeNow;

        public ConfigurationServiceImpl(
            IConfigurationLoader configurationLoader = null,
            Func<DateTime> dateTimeNow = null)
        {
            this.configurationLoader = configurationLoader ?? SimpleServiceLocator.GetService<IConfigurationLoader>();
            this.dateTimeNow = dateTimeNow ?? (() => DateTime.Now);
        }

        public IEnumerable<IConfigurationItem> GetEnabledProductItems(Func<IConfigurationItem, bool> predicate)
            => configurationLoader
                .LoadConfiguration()
                .Where(configItem =>
                    configItem.Enabled
                    && configItem.EndSupportDate >= dateTimeNow()
                    && (predicate == null || predicate(configItem)));

        public IEnumerable<int> GetEnabledProductIds(Func<IConfigurationItem, bool> predicate)
            => GetEnabledProductItems(predicate)
                .Select(configuration => configuration.ProductId);
    }
}