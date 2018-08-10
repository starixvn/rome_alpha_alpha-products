namespace Alpha.Products.AccountInfo.Status.ViewModels
{
    using Alpha.Products.AccountInfo.Requests;

    public class ConfirmClosedViewModel : ConfirmStatusItemViewModelBase
    {
        public ConfirmClosedViewModel(ISearchAccountInfoRequest request, int displayOrder = 2)
            : base(request, displayOrder)
        {
        }

        public override string ConfirmMessage
        {
            get
            {
                var suffixMessage = Request.SearchAccount.IsMember ? 
                    Checked ? "InCaseClosedMemberMessage" : "InCaseOpenMemberMessage" : 
                    Checked ? "InCaseClosedMasterOrAgentMessage" : "InCaseOpenMasterOrAgentMessage";

                return Request.GetResource($"{GetType().Name}{suffixMessage}");
            }
        }

        public override string Url => "_AccountInfo/Handlers/UpdateClosedStatus.ashx";

        public override bool Disabled => base.Disabled || Request.GetData<bool>(DataKey.SearchAccount.Upline.IsClosed);

        public override bool Checked => Request.GetData<bool>(DataKey.SearchAccount.IsClosed);
    }
}