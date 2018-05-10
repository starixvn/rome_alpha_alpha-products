namespace Alpha.Sample.AccountInfo.Console.Integration
{
    using Alpha.Products.Core.Configuration;
    using Alpha.Products.Integration;

    public class AccountInfoConfigurationItem : ConfigurationItem
    {
        public AccountInfoConfigurationItem(int productId, string productName)
            : base(productId, productName, GlobalProductSettings.IsProductEnabled(productId), null)
        {
        }
    }
}