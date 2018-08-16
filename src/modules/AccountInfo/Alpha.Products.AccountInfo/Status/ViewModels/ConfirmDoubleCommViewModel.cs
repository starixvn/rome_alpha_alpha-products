namespace Alpha.Products.AccountInfo.Status.ViewModels
{
    using Alpha.Products.AccountInfo.Requests;
    using System;

    public class ConfirmDoubleCommViewModel : ConfirmStatusItemViewModelBase
    {
        public ConfirmDoubleCommViewModel(ISearchAccountInfoRequest request, int displayOrder = 5)
           : base(request, displayOrder)
        {
        }

        public override string ConfirmMessage
        {
            get
            {
                var suffixMessage = Request.SearchAccount.IsMember ?
                    Checked ? "InCaseDisabledMemberMessage" : "InCaseEnabledMemberMessage" :
                    Checked ? "InCaseDisabledMasterOrAgentMessage" : "InCaseEnableMasterOrAgentMessage" ;

                return Request.GetResource($"{GetType().Name}{suffixMessage}");
            }
        }

        public override string Url
            => $"{Request.MicrositePaths["AccountInfoPath"]}AccountInfo/UpdateDoubleComm";

        public string Param => string.Format("{0}{1}{2}",
            "{", $"\"SearchAccountId\":\"{SearchAccount.Id}\",\"DoubleComm\":\"{!Checked}\"", "}");

        public override bool Disabled
            => base.Disabled
                || !Request.GetData<bool>(DataKey.SearchAccount.Upline.IsAllowedDoubleComm)
                || Request.ActorIsNotEdittingDirectDownline;

        public override bool Checked => Request.GetData<bool>(DataKey.SearchAccount.IsAllowedDoubleComm);
    }
}