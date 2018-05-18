namespace Alpha.Products.Reports.Tests.Requests
{
    using System;
    using Alpha.Products.Core.Configuration;
    using Alpha.Products.Core.Models;
    using Alpha.Products.Core.Services;
    using Alpha.Products.Reports.Requests;
    using NSubstitute;
    using Xunit;

    [Trait("Reports", "Requests/LegendDisplayProductRequest")]
    public class LegendDisplayProductRequestTests
    {

        public LegendDisplayProductRequestTests()
        {
            SimpleServiceLocator
                .Instance
                .Register<Func<int, string>>((id) => "name");
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void LegendDisplayProductRequest_Always_ReturnShowInLegend(bool showInLegend)
        {
            var customer = Substitute.For<ICustomer>();
            var request = new LegendDisplayProductRequest(customer);
            var configItem = new ConfigurationItem(
                1,
                "Name",
                true,
                new ReportProperties(showInLegend, true, true));

            var predicateResult = request.Predicate(configItem);

            Assert.Equal(showInLegend, predicateResult);
        }
    }
}