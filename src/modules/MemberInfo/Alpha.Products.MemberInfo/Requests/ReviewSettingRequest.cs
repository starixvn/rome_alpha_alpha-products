namespace Alpha.Products.MemberInfo.Requests
{
    using System;
    using Core.Configuration;
    using Core.Models;
    using Core.Services;

    public class ReviewSettingRequest : ExtendedRequest, IReviewSettingRequest
    {
        public ReviewSettingRequest(
            ICustomer actor,
            ICustomer reviewedCustomer,
            Func<string, string> getResource = null,
            Func<int, string> getProductName = null)
        {
            Actor = actor;
            ReviewedCustomer = reviewedCustomer;
            GetResource = getResource ?? SimpleServiceLocator.GetService<Func<string, string>>();
            GetProductName = getProductName ?? SimpleServiceLocator.GetService<Func<int, string>>();
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

        public Func<IConfigurationItem, bool> Predicate { get; }

        public bool ActorIsEdittingDirectDownline => Actor.IsDirectUplineOf(ReviewedCustomer);
    }
}
