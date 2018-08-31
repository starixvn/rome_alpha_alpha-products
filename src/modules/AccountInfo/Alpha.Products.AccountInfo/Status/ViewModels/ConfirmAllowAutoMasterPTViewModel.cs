namespace Alpha.Products.AccountInfo.Status.ViewModels
{
    using Alpha.Products.AccountInfo.Requests;

    public class ConfirmAllowAutoMasterPTViewModel : ConfirmStatusItemViewModelBase
    {
        public ConfirmAllowAutoMasterPTViewModel(ISearchAccountInfoRequest request, int displayOrder = 4)
          : base(request, displayOrder)
        {
        }

        public override string ConfirmMessage
        {
            get
            {
                var suffixMessage = Checked ? "InCaseDisabledMessage" :"InCaseEnabledMessage";

                return Request.GetResource($"{GetType().Name}{suffixMessage}");
            }
        }

        public override string Url
            => $"{AccountInfoUrl}AccountInfo/UpdateCustomerStatus";

        public string Param => string.Format("{0}{1}{2}",
           "{", 
            $"\"SearchAccountId\":\"{SearchAccount.Id}\"," +
            $"\"StatusName\":\"{DataKey.StatusMapping.DisableAutoMasterPT}\"," +
            $"\"StatusValue\":\"{Checked}\"," +
            $"\"SyncedCasino3rd\":\"False\"",
            "}");

        public override bool Visible
            => base.Visible
            && Actor.IsSuper
            && SearchAccount.IsMaster;

        public override bool Checked => Request.GetData<bool>(DataKey.SearchAccount.IsAllowedMasterAutoPT);
    }
}