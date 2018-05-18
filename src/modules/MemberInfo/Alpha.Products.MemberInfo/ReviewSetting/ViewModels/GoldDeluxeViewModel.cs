namespace Alpha.Products.MemberInfo.ReviewSetting.ViewModels
{
    using System.Collections.Generic;
    using Base;
    using Requests;
    using static Core.Shared.ProductConstants;

    public class GoldDeluxeViewModel : ReviewProductSettingViewModel
    {
        public GoldDeluxeViewModel(IReviewSettingRequest request, bool visisible, int displayOrder = 3)
            : base(request, visisible, GoldDeluxe, displayOrder)
        {
        }

        protected override string BaseAddress
            => "GoldDeluxeSetting/GoldDeluxe/EditSetting";

        protected override Dictionary<string, string> QueryStringParamaters
            => new Dictionary<string, string>
            {
                ["uplineid"] = Actor.Id.ToString(),
                ["uplinelevel"] = Actor.CustomerLevel.Value.ToString(),
                ["actorid"] = Actor.Id.ToString(),
                ["subAccId"] = Actor.SubAccountId.ToString(),
                ["custid"] = ReviewedCustomer.Id.ToString(),
                ["level"] = ReviewedCustomer.CustomerLevel.Value.ToString(),
                ["formtype"] = "1",
                ["language"] = "E",
                ["isedit"] = "false"
            };

        public override bool Visible => base.Visible && Actor.CanSeeProduct(ProductId);
    }
}
