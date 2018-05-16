namespace Alpha.Products.Core.Tests.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
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
                new ConfigurationItem(1, "Sportsbook", true),
                new ConfigurationItem(2, "Racing", false),
                new ConfigurationItem(3, "NumberGame", true)
            });
        }

        [Fact]
        public void GetEnabledProductItems_Always_ReturnWithoutDisabledProduct()
        {
            var enabledProducts = configurationService.GetEnabledProductItems(null);

            Assert.True(enabledProducts.Count() == 2
                && enabledProducts.ElementAt(0).ProductId == 1
                && enabledProducts.ElementAt(1).ProductId == 3);
        }

    }
}
