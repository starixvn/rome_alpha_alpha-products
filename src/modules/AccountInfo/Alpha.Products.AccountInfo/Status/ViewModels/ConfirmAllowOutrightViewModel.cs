namespace Alpha.Products.AccountInfo.Status.ViewModels
{
    using Alpha.Products.AccountInfo.Requests;

    public class ConfirmAllowOutrightViewModel : ConfirmStatusItemViewModelBase
    {
        public ConfirmAllowOutrightViewModel(ISearchAccountInfoRequest request, int displayOrder = 3)
        : base(request, displayOrder)
        {
        }

        public override string Url => "_AccountInfo/Handlers/UpdateOutrightStatus.ashx";

        public override bool Disabled
            => base.Disabled || !Request.GetData<bool>(DataKey.SearchAccount_Upline_IsAllowedOutright);

        public override bool Checked => Request.GetData<bool>(DataKey.SearchAccount_IsAllowedOutright);
    }
}