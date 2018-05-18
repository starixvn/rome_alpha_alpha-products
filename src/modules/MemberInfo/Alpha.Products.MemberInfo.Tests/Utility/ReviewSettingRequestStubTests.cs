namespace Alpha.Products.MemberInfo.Tests.Utility
{
    using Xunit;

    [Trait("ReviewSetting.Utility", "ReviewSettingRequestStub")]
    public class ReviewSettingRequestStubTests
    {
        [Fact]
        public void Predicate_Always_ReturnsFunctionAlwaysReturnTrue()
        {
            var request = RequestHelper.CreateRequest(4, 3);

            Assert.True(request.Predicate(null));
        }

        [Fact]
        public void IsValid_ActorIsNull_ReturnFalse()
        {
            var request = new ReviewSettingRequestStub(null, null);

            Assert.False(request.IsValid);
        }

        [Theory]
        [InlineData(2)]
        public void IsValid_ActorIsAgent_ReturnFalse(byte actorLevel)
        {
            var actor = CustomerHelper.CreateCustomer(1, actorLevel);
            var request = new ReviewSettingRequestStub(actor, null);

            Assert.False(request.IsValid);
        }

        [Fact]
        public void IsValid_ReviewedCustomerIsNull_ReturnFalse()
        {
            var actor = CustomerHelper.CreateCustomer(1, 4);
            var request = new ReviewSettingRequestStub(actor, null);

            Assert.False(request.IsValid);
        }

        [Fact]
        public void IsValid_ReviewedCustomerIsNotDirectDownlineOfActor_ReturnFalse()
        {
            var actor = CustomerHelper.CreateCustomer(1, 3);
            var reviewedCustomer = CustomerHelper.CreateCustomer(3, 4);
            var request = new ReviewSettingRequestStub(actor, reviewedCustomer);

            Assert.False(request.IsValid);
        }

        [Fact]
        public void IsValid_ValidRequest_ReturnTrue()
        {
            var actor = CustomerHelper.CreateCustomer(1, 4);
            var reviewedCustomer = CustomerHelper.CreateCustomer(3, 3);
            var request = new ReviewSettingRequestStub(actor, reviewedCustomer);

            Assert.True(request.IsValid);
        }
    }
}
