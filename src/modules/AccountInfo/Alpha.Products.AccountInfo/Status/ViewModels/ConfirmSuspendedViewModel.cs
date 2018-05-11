namespace Alpha.Products.AccountInfo.Status.ViewModels
{
    using Alpha.Products.AccountInfo.Requests;

    public class ConfirmSuspendedViewModel : ConfirmStatusItemViewModelBase
    {
        public ConfirmSuspendedViewModel(ISearchAccountInfoRequest request, int displayOrder = 1)
         : base(request, displayOrder)
        {
        }

        public override string Url => "_AccountInfo/Handlers/UpdateSuspendedStatus.ashx";

        public override bool Disabled => base.Disabled || Request.GetData<bool>(DataKey.SearchAccount.Upline.IsSuspended);

        public override bool Checked => Request.GetData<bool>(DataKey.SearchAccount.IsSuspended);
    }
}