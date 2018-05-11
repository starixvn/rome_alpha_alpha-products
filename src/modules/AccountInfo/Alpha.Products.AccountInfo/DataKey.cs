namespace Alpha.Products.AccountInfo
{
    public static class DataKey
    {
        public static class SearchAccount
        {
            public const string IsSuspended = "SearchAccount.IsSuspended";
            public const string IsAllowedMasterAutoPT = "SearchAccount.IsAllowedMasterAutoPT";

            public static class Upline
            {
                public const string IsSuspended = "SearchAccount.Upline.IsSuspended";
            }
        }

        //public const string SearchAccount_Upline_IsSuspended = "SearchAccount.Upline.IsSuspended";
        //public const string SearchAccount_IsSuspended = "SearchAccount.IsSuspended";
        public const string Actor_HasUpdateAccountPermission = "Actor.HasUpdateAccountPermission";

        public const string Actor_CanEditDailyTransferOption = "Actor.CanEditDailyTransferOption";

        //public const string SearchAccount_IsAllowedMasterAutoPT = "SearchAccount.IsAllowedMasterAutoPT";
        public const string SearchAccount_Upline_IsAllowedOutright = "SearchAccount.Upline.IsAllowedOutright";

        public const string SearchAccount_IsAllowedOutright = "SearchAccount.IsAllowedOutright";
        public const string SearchAccount_Upline_IsClosed = "SearchAccount.Upline.IsClosed";
        public const string SearchAccount_IsClosed = "SearchAccount.IsClosed";
        public const string SearchAccount_Upline_IsAllowedDoubleComm = "SearchAccount.Upline.IsAllowedDoubleComm";
        public const string SearchAccount_IsAllowedDoubleComm = "SearchAccount.IsAllowedDoubleComm";
    }
}