namespace Alpha.Products.MemberInfo.Tests.Utility
{
    using System;
    using Requests;

    public static class RequestHelper
    {
        private static readonly Func<string, string> GetString = (key) => key;
        private static readonly Func<int, string> GetProductName = (productId) => $"ProductName-{productId}";

        public static IReviewSettingRequest CreateRequest(
            byte actorLevel,
            byte reviewedCustomerLevel,
            Func<string, string> getString,
            Func<int, string> getProductName,
            bool uplineLevel = false)
        {
            var actor = CustomerHelper.CreateCustomer(1, actorLevel);
            var searchAccount = CustomerHelper.CreateCustomer(2, reviewedCustomerLevel);

            return new ReviewSettingRequestStub(actor, searchAccount, getString ?? GetString, getProductName ?? GetProductName);
        }

        public static IReviewSettingRequest CreateRequest(byte actorLevel, byte reviewedCustomerLevel)
            => CreateRequest(actorLevel, reviewedCustomerLevel, null, null);
    }
}
