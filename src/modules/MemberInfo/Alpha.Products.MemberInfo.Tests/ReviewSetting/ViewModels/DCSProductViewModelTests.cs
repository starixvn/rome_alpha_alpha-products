namespace Alpha.Products.MemberInfo.Tests.ReviewSetting.ViewModels
{
    using System;
    using MemberInfo.ReviewSetting.ViewModels;
    using Utility;
    using Xunit;

    [Trait("ReviewSetting.ViewModels", "DCSProductViewModel")]
    public class DCSProductViewModelTests
    {
        [Fact]
        public void Url_Always_ContainsCustomerIdOfReviewedCustomer()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new DCSProductViewModel(request, true, 22);

            Assert.True(viewModel.Url.IndexOf($"?customerId={request.ReviewedCustomer.Id}", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        [Fact]
        public void Url_Always_ContainsCustomerLevelOfReviewedCustomer()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new DCSProductViewModel(request, true, 22);

            Assert.True(viewModel.Url.IndexOf($"&customerLevel={request.ReviewedCustomer.CustomerLevel.Value}", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        [Fact]
        public void Url_Always_ContainsProductId()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new DCSProductViewModel(request, true, 22);

            Assert.True(viewModel.Url.IndexOf("&productId=22", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        [Fact]
        public void Url_Always_ContainsUplineLevelIsActorLevel()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new DCSProductViewModel(request, true, 22);

            Assert.True(viewModel.Url.IndexOf($"&uplineLevel={request.Actor.CustomerLevel.Value}", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        [Fact]
        public void Url_Always_ContainsIsEditIsFalse()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new DCSProductViewModel(request, true, 22);

            Assert.True(viewModel.Url.IndexOf($"&isedit=false", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        [Fact]
        public void Visible_NotHiddenProduct_ReturnTrue()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new DCSProductViewModel(request, true, 22);

            Assert.True(viewModel.Visible);
        }

        [Fact]
        public void Visible_HiddenProduct_ReturnFalse()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new DCSProductViewModel(request, true, 29);

            Assert.False(viewModel.Visible);
        }
    }
}
