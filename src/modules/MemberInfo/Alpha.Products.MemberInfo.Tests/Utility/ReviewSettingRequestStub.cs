namespace Alpha.Products.MemberInfo.Tests.Utility
{
    using System;
    using Core.Configuration;
    using Core.Models;
    using Requests;

    public class ReviewSettingRequestStub : ExtendedRequest, IReviewSettingRequest
    {
        public ReviewSettingRequestStub(
              ICustomer actor,
              ICustomer reviewedCustomer,
              Func<string, string> getResource = null,
              Func<int, string> getProductName = null)
        {
            Actor = actor;
            ReviewedCustomer = reviewedCustomer;
            GetResource = getResource ?? ((key) => key);
            GetProductName = getProductName ?? ((productId) => $"Product Name of {productId}");
        }

        public ICustomer Actor { get; }

        public ICustomer ReviewedCustomer { get; }

        public virtual bool IsValid =>
            Actor != null
            && Actor.IsMasterOrSuper
            && ReviewedCustomer != null
            && Actor.IsUplineOf(ReviewedCustomer);

        public Func<string, string> GetResource { get; }

        public Func<int, string> GetProductName { get; }

        public Func<IConfigurationItem, bool> Predicate => _ => true;
    }
}
