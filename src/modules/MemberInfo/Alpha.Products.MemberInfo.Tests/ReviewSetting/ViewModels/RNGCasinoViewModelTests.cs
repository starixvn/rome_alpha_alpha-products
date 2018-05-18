namespace Alpha.Products.MemberInfo.Tests.ReviewSetting.ViewModels
{
    using System;
    using MemberInfo.ReviewSetting.ViewModels;
    using Utility;
    using Xunit;

    [Trait("ReviewSetting.ViewModels", "RNGCasinoViewModel")]
    public class RNGCasinoViewModelTests
    {
        [Fact]
        public void Url_Always_ContainsUsernameOfReviewedCustomer()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new RNGCasinoViewModel(request, true);

            Assert.True(viewModel.Url.IndexOf($"?username={request.ReviewedCustomer.Username}", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        [Fact]
        public void Url_Always_IsEditIsFalse()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new RNGCasinoViewModel(request, true);

            Assert.True(viewModel.Url.IndexOf("&isedit=false", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        [Fact]
        public void Visible_Always_IsTrue()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new RNGCasinoViewModel(request, true);

            Assert.True(viewModel.Visible);
        }

        [Fact]
        public void Text_Always_ReturnsCorrectText()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new RNGCasinoViewModel(request, true);

            Assert.Equal(viewModel.Text, "ProductName-6");
        }

        [Fact]
        public void Visible_SyncedProduct_ReturnTrue()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new RNGCasinoViewModel(request, true);

            Assert.True(viewModel.Visible);
        }
    }
}
