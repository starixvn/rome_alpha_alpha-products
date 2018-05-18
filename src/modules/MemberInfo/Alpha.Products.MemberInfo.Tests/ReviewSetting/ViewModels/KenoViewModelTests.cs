namespace Alpha.Products.MemberInfo.Tests.ReviewSetting.ViewModels
{

    using System;
    using MemberInfo.ReviewSetting.ViewModels;
    using Utility;
    using Xunit;

    [Trait("ReviewSetting.ViewModels", "KenoViewModel")]
    public class KenoViewModelTests
    {
        [Theory]
        [InlineData(4)]
        [InlineData(3)]
        [InlineData(2)]
        public void Url_Always_ContainsCustIdOfReviewedCustomer(byte actorRoleId)
        {
            var request = RequestHelper.CreateRequest(actorRoleId, 3);
            var viewModel = new KenoViewModel(request, true);

            Assert.True(viewModel.Url.IndexOf($"?custid={request.ReviewedCustomer.Id}", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        [Fact]
        public void Url_Always_ContainsUsernameOfReviewedCustomer()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new KenoViewModel(request, true);

            Assert.True(viewModel.Url.IndexOf($"&user={request.ReviewedCustomer.Username}", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        [Fact]
        public void Url_Always_ContainsUserIdIsActorId()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new KenoViewModel(request, true);

            Assert.True(viewModel.Url.IndexOf($"&userId={request.Actor.Id}", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        [Fact]
        public void Url_Always_ContainsSubAccIdOfActor()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new KenoViewModel(request, true);

            Assert.True(viewModel.Url.IndexOf($"&subAccid={request.Actor.SubAccountId}", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        [Theory]
        [InlineData(4, "customersetting/kenosetting/kenosetting/EditMaster")]
        [InlineData(3, "customersetting/kenosetting/kenosetting/EditAgent")]
        [InlineData(2, "customersetting/kenosetting/kenosetting/AgentEditMember")]
        public void Url_Always_ContainsCorrectPath(byte actorRoleId, string expectedPath)
        {
            var request = RequestHelper.CreateRequest(actorRoleId, 3);
            var viewModel = new KenoViewModel(request, true);

            Assert.True(viewModel.Url.IndexOf(expectedPath, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        [Fact]
        public void Visible_NotHiddenProduct_ReturnTrue()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new KenoViewModel(request, true);

            Assert.True(viewModel.Visible);
        }
    }
}
