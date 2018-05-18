namespace Alpha.Products.MemberInfo.ReviewSetting.ViewModels
{
    using System.Collections.Generic;
    using Base;
    using Requests;

    public class SportsbookMinPTViewModel : ReviewSettingViewModel
    {
        public SportsbookMinPTViewModel(IReviewSettingRequest request, int displayOrder = 0)
            : base(request, displayOrder)
        {
        }

        protected override string BaseAddress
            => $"_MemberInfo/PositionTaking/{Actor.CustomerLevel.DisplayName}/EditMinPT{ReviewedCustomer.CustomerLevel.DisplayName}.aspx";

        protected override Dictionary<string, string> QueryStringParamaters
            => new Dictionary<string, string>
            {
                ["custId"] = ReviewedCustomer.Id.ToString(),
                ["user"] = ReviewedCustomer.Username,
                ["isedit"] = "false"
            };

        public override bool Visible => base.Visible && ReviewedCustomer.IsNotMember;
    }
}
