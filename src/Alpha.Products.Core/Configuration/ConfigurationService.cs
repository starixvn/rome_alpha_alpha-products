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

    public class ConfigurationServiceImpl : ConfigurationService
    {
        private readonly IConfigurationLoader configurationLoader;

        public ConfigurationServiceImpl(IConfigurationLoader configurationLoader = null)
        {
            this.configurationLoader = configurationLoader ?? SimpleServiceLocator.GetService<IConfigurationLoader>();
        }

        public IEnumerable<IConfigurationItem> GetEnabledProductItems(Func<IConfigurationItem, bool> predicate)
            => configurationLoader
                .LoadConfiguration()
                .Where(configItem =>
                    configItem.Enabled
                    && configItem.EndSupportDate >= DateTime.Now
                    && (predicate == null || predicate(configItem)));

        public IEnumerable<int> GetEnabledProductIds(Func<IConfigurationItem, bool> predicate)
            => GetEnabledProductItems(predicate)
                .Select(configuration => configuration.ProductId);
    }
}