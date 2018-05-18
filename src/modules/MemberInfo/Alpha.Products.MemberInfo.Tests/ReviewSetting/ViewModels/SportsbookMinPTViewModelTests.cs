namespace Alpha.Products.MemberInfo.Tests.ReviewSetting.ViewModels
{
    using System;
    using MemberInfo.ReviewSetting.ViewModels;
    using Utility;
    using Xunit;

    [Trait("ReviewSetting.ViewModels", "SportsbookMinPTViewModel")]
    public class SportsbookMinPTViewModelTests
    {
        [Fact]
        public void Url_Always_ContainsCustIdOfReviewedCustomer()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new SportsbookMinPTViewModel(request);

            Assert.True(viewModel.Url.IndexOf($"?custid={request.ReviewedCustomer.Id}", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        [Fact]
        public void Url_Always_ContainsUsernameOfReviewedCustomer()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new SportsbookMinPTViewModel(request);

            Assert.True(viewModel.Url.IndexOf($"&user={request.ReviewedCustomer.Username}", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        [Fact]
        public void Url_Always_ContainsIsEditIsFalse()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new SportsbookMinPTViewModel(request);

            Assert.True(viewModel.Url.IndexOf($"&isedit=false", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        [Fact]
        public void Visible_Always_IsTrue()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new SportsbookMinPTViewModel(request);

            Assert.True(viewModel.Visible);
        }

        [Fact]
        public void Text_Always_ReturnsCorrectText()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new SportsbookMinPTViewModel(request);

            Assert.Equal("SportsbookMinPTViewModelText", viewModel.Text);
        }

        [Fact]
        public void Constructor_NullRequest_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new SportsbookMinPTViewModel(null));
        }
    }
}
