namespace Alpha.Products.AccountInfo
{
    public class SearchAccountProperties
    {
        public SearchAccountProperties(bool setting, bool status)
        {
            Setting = setting;
            Status = status;
        }

        public bool Setting { get; }

        public bool Status { get; }
    }
}