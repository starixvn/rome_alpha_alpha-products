namespace Alpha.Products.MemberInfo.ReviewSetting.ViewModels
{
    using System.Collections.Generic;
    using Base;
    using Requests;

    public class DCSProductViewModel : ReviewProductSettingViewModel
    {
        public DCSProductViewModel(IReviewSettingRequest request, int productId, int displayOrder = 5)
            : base(request, productId, displayOrder)
        {
        }

        protected override string BaseAddress
            => "dcs/viewcustomersetting";

        protected override Dictionary<string, string> QueryStringParamaters
            => new Dictionary<string, string>
            {
                ["customerId"] = ReviewedCustomer.Id.ToString(),
                ["customerLevel"] = ReviewedCustomer.CustomerLevel.Value.ToString(),
                ["productId"] = ProductId.ToString(),
                ["isedit"] = "false",
                ["uplineLevel"] = Actor.CustomerLevel.Value.ToString(),
            };
    }
}
