namespace Alpha.Products.Reports.Tests.Requests
{
    using System;
    using Alpha.Products.Core.Configuration;
    using Alpha.Products.Core.Models;
    using Alpha.Products.Core.Services;
    using Alpha.Products.Reports.Requests;
    using NSubstitute;
    using Xunit;

    [Trait("Reports", "Requests/PlayForFunProductRequest")]
    public class PlayForFunProductRequestTests
    {
        public PlayForFunProductRequestTests()
        {
            SimpleServiceLocator
                .Instance
                .Register<Func<int, string>>((id) => "name");
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void PlayForFunProductRequest_Always_ReturnHasMatchInfo(bool offerPlayForFun)
        {
            var customer = Substitute.For<ICustomer>();
            var request = new PlayForFunProductRequest(customer);
            var configItem = new ConfigurationItem(
                1,
                "Name",
                true,
                new ReportProperties(true, true, offerPlayForFun));

            var predicateResult = request.Predicate(configItem);

            Assert.Equal(offerPlayForFun, predicateResult);
        }
    }
}