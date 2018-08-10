namespace Alpha.Products.AccountInfo.Status.ViewModels
{
    using Alpha.Products.AccountInfo.Requests;

    public class ConfirmAllowOutrightViewModel : ConfirmStatusItemViewModelBase
    {
        public ConfirmAllowOutrightViewModel(ISearchAccountInfoRequest request, int displayOrder = 3)
        : base(request, displayOrder)
        {
        }

        public override string ConfirmMessage
        {
            get
            {
                var suffixMessage = Checked ? "InCaseEnabledMessage" : "InCaseDisabledMessage";

                return Request.GetResource($"{GetType().Name}{suffixMessage}");
            }
        }

        public override string Url => "_AccountInfo/Handlers/UpdateOutrightStatus.ashx";

        public override bool Disabled
            => base.Disabled || !Request.GetData<bool>(DataKey.SearchAccount.Upline.IsAllowedOutright);

        public override bool Checked => Request.GetData<bool>(DataKey.SearchAccount.IsAllowedOutright);
    }
}