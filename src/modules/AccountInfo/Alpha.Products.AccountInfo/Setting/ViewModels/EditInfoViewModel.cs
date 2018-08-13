namespace Alpha.Products.AccountInfo.Setting.ViewModels
{
    using System.Collections.Generic;
    using Alpha.Products.AccountInfo.Requests;
    using Base;

    public class EditInfoViewModel : SettingItemViewModel
    {
        public EditInfoViewModel(ISearchAccountInfoRequest request, int displayOrder = 1)
            : base(request, displayOrder)

        {
        }

        protected override string BaseAddress 
            => $"{Request.MicrositePaths["OldMainPath"]}_AccountInfo/EditCustomerInfo.aspx";

        protected override Dictionary<string, string> QueryStringParamaters
            => new Dictionary<string, string>
            {
                ["custId"] = SearchAccount.Id.ToString(),
                ["username"] = SearchAccount.Username
            };
    }
}