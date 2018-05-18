namespace Alpha.Products.MemberInfo.ReviewSetting.ViewModels
{
    using System.Collections.Generic;
    using Base;
    using Requests;
    using static Core.Shared.ProductConstants;

    public class RNGCasinoViewModel : ReviewProductSettingViewModel
    {
        public RNGCasinoViewModel(IReviewSettingRequest request, bool visisible, int displayOrder = 1)
            : base(request, visisible, RNGCasino, displayOrder)
        {
        }

        protected override string BaseAddress
            => $"CustomerSetting/Casino/{ReviewedCustomer.CustomerLevel.DisplayName}/Edit{ReviewedCustomer.CustomerLevel.DisplayName}/{ReviewedCustomer.Id}/{Actor.Id}";

        protected override Dictionary<string, string> QueryStringParamaters
            => new Dictionary<string, string>
            {
                ["username"] = ReviewedCustomer.Username,
                ["isedit"] = "false"
            };

        public override bool Visible
            => base.Visible && Actor.ProductStatusOf(ProductId).Synced;
    }
}
