namespace Alpha.Products.MemberInfo.Tests.Requests
{
    using Utility;
    using Xunit;

    [Trait("ReviewSetting.ViewModels", "DCSProductViewModel")]
    public class ReviewSettingRequestTests
    {
        [Fact]
        public void ActorIsEdittingDirectDownline_EditDirectDownline_ReturnsTrue()
        {
            var request = RequestHelper.CreateReviewSettingRequest(4, 3);

            Assert.True(request.ActorIsEdittingDirectDownline);
        }

        [Fact]
        public void ActorIsEdittingDirectDownline_NotEditDirectDownline_ReturnsTrue()
        {
            var request = RequestHelper.CreateReviewSettingRequest(4, 2);

            Assert.False(request.ActorIsEdittingDirectDownline);
        }
    }
}
