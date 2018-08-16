namespace Alpha.Products.AccountInfo.Status.ViewModels
{
    using Alpha.Products.AccountInfo.Requests;
    using Alpha.Products.Core.Shared;

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
                var suffixMessage = !Request.SearchAccount.IsMember && Checked ?
                    "InCaseClosedDownlinesMessage" : "InCaseChangeClosedStatusMessage";

                return Request.GetResource($"{GetType().Name}{suffixMessage}");
            }
        }

        //TO DO hard code
        public override string Url
             => $"{Request.MicrositePaths["AccountInfoPath"]}AccountInfo/UpdateClosed";

        public string Param => string.Format("{0}{1}{2}",
          "{", $"\"SearchAccountId\":\"{SearchAccount.Id}\",\"Closed\":\"{!Checked}\",\"SyncedCasino\":\"{SyncedCasino}\"", "}");

        public bool SyncedCasino => Request.SearchAccount.ProductStatusOf(ProductConstants.RNGCasino).Synced;

        public override bool Disabled => base.Disabled || Request.GetData<bool>(DataKey.SearchAccount.Upline.IsClosed);

        public override bool Checked => Request.GetData<bool>(DataKey.SearchAccount.IsClosed);
    }
}