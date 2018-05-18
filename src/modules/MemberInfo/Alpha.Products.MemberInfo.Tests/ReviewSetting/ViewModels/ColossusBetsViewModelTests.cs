namespace Alpha.Products.MemberInfo.Tests.ReviewSetting.ViewModels
{
    using System;
    using MemberInfo.ReviewSetting.ViewModels;
    using Utility;
    using Xunit;

    [Trait("ReviewSetting.ViewModels", "ColossusBetsViewModel")]
    public class ColossusBetsViewModelTests
    {
        [Fact]
        public void Url_Always_ContainsCustIdOfReviewedCustomer()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new ColossusBetsViewModel(request, true);

            Assert.True(viewModel.Url.IndexOf($"?custid={request.ReviewedCustomer.Id}", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        [Fact]
        public void Url_Always_ContainsUsernameOfReviewedCustomer()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new ColossusBetsViewModel(request, true);

            Assert.True(viewModel.Url.IndexOf($"&username={request.ReviewedCustomer.Username}", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        [Fact]
        public void Url_Always_ContainsUserIdOfActor()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new ColossusBetsViewModel(request, true);

            Assert.True(viewModel.Url.IndexOf($"&userId={request.Actor.Id}", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        [Fact]
        public void Url_Always_ContainsSubAccIdOfActor()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new ColossusBetsViewModel(request, true);

            Assert.True(viewModel.Url.IndexOf($"&subAccid={request.Actor.SubAccountId}", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        [Fact]
        public void Url_ActorIsSuper_SRecommendIsActorId()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new ColossusBetsViewModel(request, true);

            Assert.True(viewModel.Url.IndexOf($"&srecommend={request.Actor.Id}", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        [Fact]
        public void Url_ActorIsMaster_MRecommendIsActorId()
        {
            var request = RequestHelper.CreateRequest(3, 3);
            var viewModel = new ColossusBetsViewModel(request, true);

            Assert.True(viewModel.Url.IndexOf($"&mrecommend={request.Actor.Id}", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        [Fact]
        public void Url_ActorIsAgent_MRecommendIsActorId()
        {
            var request = RequestHelper.CreateRequest(2, 3);
            var viewModel = new ColossusBetsViewModel(request, true);

            Assert.True(viewModel.Url.IndexOf($"&recommend={request.Actor.Id}", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        [Fact]
        public void Visible_NotHiddenProductAndEditDirect_ReturnTrue()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new ColossusBetsViewModel(request, true);

            Assert.True(viewModel.Visible);
        }

        [Fact]
        public void Visible_NotHiddenProductAndNotEditDirect_ReturnFalse()
        {
            var request = RequestHelper.CreateRequest(4, 2);
            var viewModel = new ColossusBetsViewModel(request, true);

            Assert.False(viewModel.Visible);
        }
    }
}
