namespace Alpha.Products.MemberInfo.ReviewSetting.ViewModels
{
    using System.Collections.Generic;
    using Base;
    using Requests;
    using static Core.Shared.ProductConstants;

    public class ColossusBetsViewModel : ReviewProductSettingViewModel
    {
        public ColossusBetsViewModel(IReviewSettingRequest request, bool visisible, int displayOrder = 4)
            : base(request, visisible, ColossusBets, displayOrder)
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
                    ["roleid"] = ReviewedCustomer.CusomerLevelValue.ToString(),
                    ["isMultipleEdit"] = "0",
                    ["isedit"] = "false",
                    ["userId"] = Actor.Id.ToString(),
                    ["subAccid"] = Actor.SubAccountId.ToString()
                };

                var searchAccountUplineIdQueryStringName =
                  Request.Actor.IsSuper
                  ? "srecommend"
                  : (Request.Actor.IsMaster ? "mrecommend" : "recommend");

                result[searchAccountUplineIdQueryStringName] = Actor.Id.ToString();

                return result;
            }
        }

        public override bool Visible
            => base.Visible
            && !Actor.ProductStatusOf(ProductId).Hidden
            && Request.ActorIsEdittingDirectDownline;
    }
}
