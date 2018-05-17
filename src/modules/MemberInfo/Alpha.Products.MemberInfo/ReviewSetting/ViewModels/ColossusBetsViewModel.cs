namespace Alpha.Products.MemberInfo.ReviewSetting.ViewModels
{
    using System.Collections.Generic;
    using Base;
    using Requests;
    using static Core.Shared.ProductConstants;

    public class ColossusBetsViewModel : ReviewProductSettingViewModel
    {
        public ColossusBetsViewModel(IReviewSettingRequest request, int displayOrder = 4)
            : base(request, ColossusBets, displayOrder)
        {
        }

        protected override string BaseAddress
            => "customersetting/ColossusBetSetting/ColossusBetSetting/EditSetting";

        protected override Dictionary<string, string> QueryStringParamaters
        {
            get
            {
                var result = new Dictionary<string, string>
                {
                    ["custid"] = ReviewedCustomer.Id.ToString(),
                    ["username"] = ReviewedCustomer.Username,
                    ["isMultipleEdit"] = "0",
                    ["isedit"] = "false",
                    ["userId"] = Actor.Id.ToString(),
                    ["subAccid"] = Actor.SubAccountId.ToString()
                };

                if (Actor.CustomerLevel.IsSuper())
                {
                    result["srecommend"] = Actor.Id.ToString();
                    result["roleid"] = "3";
                }
                else if (Actor.CustomerLevel.IsMaster())
                {
                    result["mrecommend"] = Actor.Id.ToString();
                    result["roleid"] = "2";
                }
                else
                {
                    result["recommend"] = Actor.Id.ToString();
                    result["roleid"] = "1";
                }

                return result;
            }
        }
    }
}
