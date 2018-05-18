namespace Alpha.Products.MemberInfo.Tests.ReviewSetting.ViewModels
{
    using System;
    using MemberInfo.ReviewSetting.ViewModels;
    using Utility;
    using Xunit;

    [Trait("ReviewSetting.ViewModels", "GoldDeluxeViewModel")]
    public class GoldDeluxeViewModelTests
    {
        [Fact]
        public void Url_Always_ContainsCustIdOfReviewedCustomer()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new GoldDeluxeViewModel(request, true);

            Assert.True(viewModel.Url.IndexOf($"&custid={request.ReviewedCustomer.Id}", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        [Fact]
        public void Url_Always_ContainsUplineidIsActorId()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new GoldDeluxeViewModel(request, true);

            Assert.True(viewModel.Url.IndexOf($"?uplineid={request.Actor.Id}", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        [Fact]
        public void Url_Always_ContainsUplineLevelIsActorLevel()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new GoldDeluxeViewModel(request, true);

            Assert.True(viewModel.Url.IndexOf($"&uplinelevel={request.Actor.CustomerLevel.Value}", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        [Fact]
        public void Url_Always_ContainsActorId()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new GoldDeluxeViewModel(request, true);

            Assert.True(viewModel.Url.IndexOf($"&actorid={request.Actor.Id}", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        [Fact]
        public void Url_Always_ContainsSubAccId()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new GoldDeluxeViewModel(request, true);

            Assert.True(viewModel.Url.IndexOf($"&subAccId={request.Actor.SubAccountId}", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        [Fact]
        public void Url_Always_ContainsLevelOfReviewedCustomer()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new GoldDeluxeViewModel(request, true);

            Assert.True(viewModel.Url.IndexOf($"&level={request.ReviewedCustomer.CustomerLevel.Value}", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        [Fact]
        public void Url_Always_ContainsLanguageOfCurrentSession()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new GoldDeluxeViewModel(request, true);

            Assert.True(viewModel.Url.IndexOf($"&language=E", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        [Fact]
        public void Url_Always_IsEditIsFalse()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new GoldDeluxeViewModel(request, true);

            Assert.True(viewModel.Url.IndexOf($"&isedit=false", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        [Fact]
        public void Visible_NotHiddenProduct_ReturnTrue()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new GoldDeluxeViewModel(request, true);

            Assert.True(viewModel.Visible);
        }
    }
}
