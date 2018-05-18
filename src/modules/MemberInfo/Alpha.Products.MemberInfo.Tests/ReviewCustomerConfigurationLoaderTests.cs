namespace Alpha.Products.MemberInfo.Tests
{
    using System.Collections.Generic;
    using Core.Integration;
    using NSubstitute;
    using Xunit;

    [Trait("ReviewSetting", "ReviewSettingViewModelFactory")]
    public class ReviewCustomerConfigurationLoaderTests
    {
        private readonly ReviewCustomerConfigurationLoaderForTesting configurationLoader;

        public ReviewCustomerConfigurationLoaderTests()
        {
            var jsonConverter = Substitute.For<IProductJsonConverter>();

            configurationLoader = new ReviewCustomerConfigurationLoaderForTesting(jsonConverter);
        }

        [Fact]
        public void BuildExtendProductProperty_Always_ReturnsCorrectMemberInfoProperties()
        {
            var extendedPropertyData = new Dictionary<string, string>
            {
                ["reviewSetting"] = "true"
            };

            var property = configurationLoader.CallBuildExtendProductProperty(extendedPropertyData);

            Assert.True(
                property is MemberInfoProperties
                && ((MemberInfoProperties)property).ReviewSetting);
        }
    }
}
