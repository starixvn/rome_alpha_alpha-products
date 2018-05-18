namespace Alpha.Products.Reports.Tests.Requests
{
    using System;
    using Alpha.Products.Core.Configuration;
    using Alpha.Products.Core.Models;
    using Alpha.Products.Core.Services;
    using Alpha.Products.Reports.Requests;
    using NSubstitute;
    using Xunit;

    [Trait("Reports", "Requests/MatchWinLossDetailProductRequest")]
    public class MatchWinLossDetailProductRequestTests
    {
        public MatchWinLossDetailProductRequestTests()
        {
            SimpleServiceLocator
                .Instance
                .Register<Func<int, string>>((id) => "name");
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void MatchWinLossDetailProductRequest_Always_ReturnHasMatchInfo(bool hasMatchInfo)
        {
            var customer = Substitute.For<ICustomer>();
            var request = new MatchWinLossDetailProductRequest(customer);
            var configItem = new ConfigurationItem(
                1,
                "Name",
                true,
                new ReportProperties(true, hasMatchInfo, true));

            var predicateResult = request.Predicate(configItem);

            Assert.Equal(hasMatchInfo, predicateResult);
        }
    }
}