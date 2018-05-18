namespace Alpha.Products.Reports.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Alpha.Products.Core.Configuration;
    using Alpha.Products.Core.Models;
    using Alpha.Products.Core.ViewModels;
    using Alpha.Products.Reports.Requests;
    using NSubstitute;
    using Xunit;

    [Trait("Reports", "ReportProductViewModelFactory")]
    public class ReportProductViewModelFactoryTests
    {
        [Fact]
        public void GetViewModels_Always_ReturnProductViewModels()
        {
            var configurationService = Substitute.For<ConfigurationService>();
            var stubConfigItems = new List<IConfigurationItem>
            {
                new ConfigurationItem(1, "Name", true)
            };
            configurationService
                .GetEnabledProductItems(Arg.Any<Func<IConfigurationItem, bool>>(), null)
                .Returns(stubConfigItems);
            var factory = new ReportProductViewModelFactory(configurationService);
            var customer = Substitute.For<ICustomer>();
            customer.GetProductStatus().Returns(new List<CustomerProductStatus> { new CustomerProductStatus(1, false, false, true) });
            var request = new ReportProductRequest(customer, (id) => "Product Name");

            var viewModels = factory.GetViewModels(request);

            Assert.True(viewModels.Count() == 1
                && viewModels.ElementAt(0).Name == "Product Name"
                && viewModels.ElementAt(0) is ProductViewModel);
        }
    }
}