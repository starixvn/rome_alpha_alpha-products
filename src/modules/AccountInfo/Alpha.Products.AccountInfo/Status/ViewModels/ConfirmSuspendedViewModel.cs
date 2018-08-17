namespace Alpha.Products.AccountInfo.Status.ViewModels
{
    using Alpha.Products.AccountInfo.Requests;
    using Alpha.Products.Core.Shared;

    public class ConfirmSuspendedViewModel : ConfirmStatusItemViewModelBase
    {
        public ConfirmSuspendedViewModel(ISearchAccountInfoRequest request, int displayOrder = 1)
         : base(request, displayOrder)
        {
        }

        public override string ConfirmMessage
        {
            get
            {
                var suffixMessage = Request.SearchAccount.IsMember ?
                    Checked ? "InCaseUnsuspendedMemberMessage" : "InCaseSuspendedMemberMessage" : 
                    Checked ? "InCaseUnsuspendedMasterOrAgentMessage" : "InCaseSuspendedMasterOrAgentMessage";

                return Request.GetResource($"{GetType().Name}{suffixMessage}");
            }
        }

        //TO DO hard code
        public override string Url
             => $"{Request.MicrositePaths["AccountInfoPath"]}AccountInfo/UpdateSuspended";

        public string Param => string.Format("{0}{1}{2}",
          "{", $"\"SearchAccountId\":\"{SearchAccount.Id}\",\"Suspended\":\"{!Checked}\",\"SyncedCasino\":\"{SyncedCasino}\"", "}");

        public bool SyncedCasino => Request.SearchAccount.ProductStatusOf(ProductConstants.RNGCasino).Synced;

        public override bool Disabled => base.Disabled || Request.GetData<bool>(DataKey.SearchAccount.Upline.IsSuspended);

        public override bool Checked => Request.GetData<bool>(DataKey.SearchAccount.IsSuspended);
    }
}