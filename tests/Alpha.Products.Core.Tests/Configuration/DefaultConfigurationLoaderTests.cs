namespace Alpha.Products.Core.Tests.Configuration
{
    using System;
    using System.Collections.Generic;
    using Alpha.Products.Core.Configuration;
    using Alpha.Products.Core.Integration;
    using NSubstitute;
    using Xunit;

    [Trait("Core", "Configuration/DefaultConfigurationLoader")]
    public class DefaultConfigurationLoaderTests
    {
        private readonly DefaultConfigurationLoader defaultConfigurationLoader;
        private readonly IProductJsonConverter jsonConverter;
        private readonly string productConfigFileRelativePath;
        private readonly Func<int, bool> isProductEnabled;
        private readonly IConfigFileReader configFileReader;
        private readonly string siteName;

        public DefaultConfigurationLoaderTests()
        {
            jsonConverter = Substitute.For<IProductJsonConverter>();
            configFileReader = Substitute.For<IConfigFileReader>();
            siteName = "accountInfo";
            productConfigFileRelativePath = "../config-file";
            isProductEnabled = Substitute.For<Func<int, bool>>();

            defaultConfigurationLoader = new DefaultConfigurationLoader(
                siteName,
                jsonConverter,
                productConfigFileRelativePath,
                configFileReader,
                isProductEnabled);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void BuildConfigurationItem_SiteNameIsNullOrWhiteSpace_ThrowInvalidOperationException(string siteName)
        {
            var loader = new DefaultConfigurationLoader(
                siteName,
                jsonConverter,
                productConfigFileRelativePath,
                configFileReader,
                isProductEnabled);

            Assert.Throws<InvalidOperationException>(() => loader.BuildConfigurationItem("json"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void BuildConfigurationItem_ProductJsonIsNullOrWhiteSpace_ThrowInvalidOperationException(string productJson)
        {
            var loader = new DefaultConfigurationLoader(
                "sitename",
                jsonConverter,
                productConfigFileRelativePath,
                configFileReader,
                isProductEnabled);

            Assert.Throws<ArgumentNullException>(() => loader.BuildConfigurationItem(productJson));
        }

        [Fact]
        public void BuildConfigurationItem_Always_ReturnConfigurationItem()
        {
            var productJson = "BuildConfigurationItem_Always_ReturnConfigurationItem";
            jsonConverter
                .ToProductConfig(productJson)
                .Returns(new Dictionary<string, string>
                {
                    { "productId", "1" },
                    { "productName", "Sportsbook" },
                    { "endSupportDate", "2018/03/04" }
                });
            isProductEnabled.Invoke(1).Returns(true);

            var configurationItem = defaultConfigurationLoader.BuildConfigurationItem(productJson);

            Assert.True(configurationItem.ProductId == 1
                && configurationItem.ProductName == "Sportsbook"
                && configurationItem.EndSupportDate == new DateTime(2018, 3, 4)
                && configurationItem.ExtendProductProperty == null
                && configurationItem.Enabled);
        }

        [Fact]
        public void BuildConfigurationItem_EndSupportDateIsNotProvided_ReturnEndSupportedDateIsMaxDate()
        {
            var productJson = "BuildConfigurationItem_EndSupportDateIsNotProvided_ReturnEndSupportedDateIsMaxDate";
            jsonConverter
                .ToProductConfig(productJson)
                .Returns(new Dictionary<string, string>
                {
                    { "productId", "1" },
                    { "productName", "Sportsbook" },
                });

            var configurationItem = defaultConfigurationLoader.BuildConfigurationItem(productJson);

            Assert.Equal(DateTime.MaxValue, configurationItem.EndSupportDate);
        }

        [Fact]
        public void BuildConfigurationItem_ProductIsDisabled_ReturnConfigItemDisabled()
        {
            var productJson = "BuildConfigurationItem_ProductIsDisabled_ReturnConfigItemDisabled";
            jsonConverter
                .ToProductConfig(productJson)
                .Returns(new Dictionary<string, string>
                {
                    { "productId", "100" },
                    { "productName", "Product100" },
                });
            isProductEnabled.Invoke(100).Returns(false);

            var configurationItem = defaultConfigurationLoader.BuildConfigurationItem(productJson);

            Assert.False(configurationItem.Enabled);
        }

        [Fact]
        public void GetExtendedPropertyData_ProductConfigJsonHasExtendedData_ReturnExtendedData()
        {
            var extendedRawData = "{"
                            + "\"setting\": true,"
                            + "\"status\": false"
                        + "}";
            var productConfig = new Dictionary<string, string>
                {
                    { "productId", "1" },
                    { "accountInfoProperties", extendedRawData }
                };
            jsonConverter
                .ToProductConfig(extendedRawData)
                .Returns(new Dictionary<string, string>
                {
                    { "setting", "true" },
                    { "status", "false" }
                });

            var extendedData = defaultConfigurationLoader.GetExtendedPropertyData(productConfig);

            Assert.True(extendedData.Keys.Count == 2
                && extendedData["setting"] == "true"
                && extendedData["status"] == "false");
        }

        [Fact]
        public void BuildProductProperty_Always_ReturnExtendedPropertyInstance()
        {
            var extendedProperties = new Dictionary<string, string>
                {
                    { "property1", "true" },
                    { "property2", "false" },
                    { "property3", "1" },
                    { "property4", "3.5" }
                };

            var extendedInstance = defaultConfigurationLoader.BuildProductProperty<DummyExtendedProductProperty>(extendedProperties);

            Assert.True(extendedInstance.Property1
                && extendedInstance.Property2 == "false"
                && extendedInstance.Property3 == 1
                && extendedInstance.Property4 == "3.5");
        }

        [Fact]
        public void BuildProductProperty_ExtendedClassHas2Constructor_ThrowInvalidOperationException()
        {
            var extendedProperties = new Dictionary<string, string>
                {
                    { "setting", "true" },
                    { "status", "false" }
                };

            Assert.Throws<InvalidOperationException>(() => defaultConfigurationLoader.BuildProductProperty<TwoParameterizedExtendedProductProperty>(extendedProperties));
        }

        [Fact]
        public void GetProductPropertyValue_ContainsKey_ReturnValueByKey()
        {
            var key = "key";
            var extendedProperties = new Dictionary<string, string>
                {
                    { "key", "1" },
                    { "status", "false" }
                };

            var keyValue = DefaultConfigurationLoader.GetProductPropertyValue(key, extendedProperties);

            Assert.Equal("1", keyValue);
        }

        [Fact]
        public void GetProductPropertyValue_NotContainKey_ThrowKeyNotFoundException()
        {
            var key = "key1";
            var extendedProperties = new Dictionary<string, string>
                {
                    { "key", "1" },
                    { "status", "false" }
                };

            Assert.Throws<KeyNotFoundException>(() => DefaultConfigurationLoader.GetProductPropertyValue(key, extendedProperties));
        }
    }

    internal class DummyExtendedProductProperty : IExtendProductProperty
    {
        public DummyExtendedProductProperty(bool property1, string property2, int property3, string property4)
        {
            Property1 = property1;
            Property2 = property2;
            Property3 = property3;
            Property4 = property4;
        }

        public bool Property1 { get; }

        public string Property2 { get; }

        public int Property3 { get; }

        public string Property4 { get; }
    }

    internal class TwoParameterizedExtendedProductProperty : IExtendProductProperty
    {
        public TwoParameterizedExtendedProductProperty(bool setting, bool status)
        {
            Setting = setting;
            Status = status;
        }

        public TwoParameterizedExtendedProductProperty(bool status)
        {
            Status = status;
        }

        public bool Setting { get; }

        public bool Status { get; }
    }
}