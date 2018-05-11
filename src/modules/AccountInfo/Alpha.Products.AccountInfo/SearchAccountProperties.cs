namespace Alpha.Products.AccountInfo
{
    using Alpha.Products.Core.Configuration;

    public class SearchAccountProperties : IExtendProductProperty
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