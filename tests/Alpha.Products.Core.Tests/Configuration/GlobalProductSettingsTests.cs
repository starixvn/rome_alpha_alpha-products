namespace Alpha.Products.Core.Tests.Configuration
{
    using System.Collections.Specialized;
    using Alpha.Products.Core.Integration;
    using Xunit;

    [Trait("Core", "Configuration/GlobalProductSettings")]
    public class GlobalProductSettingsTests
    {
        public GlobalProductSettingsTests()
        {
            GlobalProductSettings.Configs = new NameValueCollection
            {
                { "EnableProduct-100", "1" },
                { "EnableProduct-101", "true" },
                { "EnableProduct-102", "false" },
                { "EnableProduct-103", "" },
            };
        }

        [Theory]
        [InlineData(100)]
        [InlineData(101)]
        public void IsProductEnabled_ProductIsEnabled_ReturnTrue(int productId)
        {
            var isEnabled = GlobalProductSettings.IsProductEnabled(productId);

            Assert.True(isEnabled);
        }

        [Theory]
        [InlineData(102)]
        [InlineData(103)]
        public void IsProductEnabled_ProductIsDisabled_ReturnFalse(int productId)
        {
            var isEnabled = GlobalProductSettings.IsProductEnabled(productId);

            Assert.False(isEnabled);
        }
    }
}