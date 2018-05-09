namespace Alpha.Products.AccountInfo.Status.ViewModels
{
    using Alpha.Products.AccountInfo.Requests;

    public class ConfirmAllowAutoMasterPTViewModel : ConfirmStatusItemViewModelBase
    {
        public ConfirmAllowAutoMasterPTViewModel(ISearchAccountInfoRequest request, int displayOrder = 4)
          : base(request, displayOrder)
        {
        }

        public override string Url => "_AccountInfo/Handlers/UpdateAutoMasterPTStatus.ashx";

        public override bool Visible
            => base.Visible
            && Actor.IsSuper
            && SearchAccount.IsMaster;

        public override bool Checked => Request.GetData<bool>(Constants.SearchAccount_IsAllowedMasterAutoPT);
    }
}