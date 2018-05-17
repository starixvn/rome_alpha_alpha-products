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
        public void Url_QueryString_CustId_Returns_CustId_Of_SearchAccount()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new SportsbookMinPTViewModel(request);

            Assert.True(viewModel.Url.IndexOf($"?custid={request.ReviewedCustomer.Id}", StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}
