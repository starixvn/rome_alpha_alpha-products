namespace Alpha.Products.MemberInfo.ReviewSetting.ViewModels
{
    using System.Collections.Generic;
    using Base;
    using Requests;
    using static Core.Shared.ProductConstants;

    public class KenoViewModel : ReviewProductSettingViewModel
    {
        public KenoViewModel(IReviewSettingRequest request, bool visisible, int displayOrder = 2)
            : base(request, visisible, Keno, displayOrder)
        {
        }

        protected override string BaseAddress
        {
            get
            {
                if (Actor.CustomerLevel.IsSuper())
                {
                    return "customersetting/kenosetting/kenosetting/EditMaster";
                }

                if (Actor.CustomerLevel.IsMaster())
                {
                    return "customersetting/kenosetting/kenosetting/EditAgent";
                }

                return "customersetting/kenosetting/kenosetting/AgentEditMember";
            }
        }
        protected override Dictionary<string, string> QueryStringParamaters
            => new Dictionary<string, string>
            {
                ["custId"] = ReviewedCustomer.Id.ToString(),
                ["user"] = ReviewedCustomer.Username,
                ["isMultipleEdit"] = "0",
                ["userId"] = Actor.Id.ToString(),
                ["subAccid"] = Actor.SubAccountId.ToString(),
                ["isedit"] = "0"
            };

        public override bool Visible => base.Visible && Actor.CanSeeProduct(ProductId);
    }
}
