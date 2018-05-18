namespace Alpha.Products.MemberInfo.Requests
{
    using Core.Models;

    public interface IReviewSettingRequest : IRequest, IExtendedRequest
    {
        ICustomer ReviewedCustomer { get; }

        bool ActorIsEdittingDirectDownline { get; }
    }
}
