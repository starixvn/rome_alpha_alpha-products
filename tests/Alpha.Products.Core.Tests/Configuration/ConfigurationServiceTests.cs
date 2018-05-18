namespace Alpha.Products.Core.Tests.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Alpha.Products.Core.Configuration;
    using NSubstitute;
    using Xunit;

    [Trait("Core", "Configuration/ConfigurationService")]
    public class ConfigurationServiceTests
    {
        private readonly IConfigurationLoader configurationLoader;
        private readonly ConfigurationService configurationService;

        public ConfigurationServiceTests()
        {
            configurationLoader = Substitute.For<IConfigurationLoader>();
            configurationService = new ConfigurationServiceImpl(configurationLoader);

            configurationLoader.Load().Returns(new List<IConfigurationItem> {
                new ConfigurationItem(1, "Sportsbook", true, new DateTime(2017, 12, 12)),
                new ConfigurationItem(2, "Racing", false),
                new ConfigurationItem(3, "NumberGame", true, new DateTime(2018, 3, 12))
            });
        }

        [Fact]
        public void GetEnabledProductItems_Always_ReturnWithoutDisabledProduct()
        {
            var enabledProducts = configurationService.GetEnabledProductItems(null, DateTime.MinValue);

            Assert.True(enabledProducts.Count() == 2
                && enabledProducts.ElementAt(0).ProductId == 1
                && enabledProducts.ElementAt(1).ProductId == 3);
        }

        [Fact]
        public void GetEnabledProductItems_WithExpiredProduct_ReturnWithoutExpiredProduct()
        {
            var currentDate = new DateTime(2018, 2, 12);

            var enabledProducts = configurationService.GetEnabledProductItems(null, currentDate);

            Assert.True(enabledProducts.Count() == 1
                && enabledProducts.ElementAt(0).ProductId == 3);
        }

        [Fact]
        public void GetEnabledProductItems_PredicateIsFalse_ReturnNoProduct()
        {
            var currentDate = new DateTime(2018, 2, 12);

            var enabledProducts = configurationService.GetEnabledProductItems((configItem) => false, currentDate);

            Assert.Empty(enabledProducts);
        }

        [Fact]
        public void GetEnabledProductItems_PredicateIsTrue_ReturnEnabledProducts()
        {
            var enabledProducts = configurationService.GetEnabledProductItems((configItem) => true, DateTime.MinValue);

            Assert.True(enabledProducts.Count() == 2
                && enabledProducts.ElementAt(0).ProductId == 1
                && enabledProducts.ElementAt(1).ProductId == 3);
        }
    }
}