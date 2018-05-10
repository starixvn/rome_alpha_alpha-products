namespace Alpha.Sample.AccountInfo.Console.Integration
{
    using System.Collections.Generic;
    using Alpha.Products.Core.Configuration;
    using Alpha.Products.Integration;

    internal static class ProductConfiguration
    {
        /// <summary>
        /// it will be replaced by code loading setting from shared config
        /// </summary>
        /// <returns></returns>
        internal static IList<IConfigurationItem> LoadApplicationProductConfiguration()
        => new List<IConfigurationItem>
        {
                new AccountInfoConfigurationItem(1, "Sportsbook"),
                new AccountInfoConfigurationItem(2, "Racing"),
                new AccountInfoConfigurationItem(3, "Number Game"),
                new AccountInfoConfigurationItem(4, "Live Casino"),
                new AccountInfoConfigurationItem(5, "Virtual Sports"),
                new AccountInfoConfigurationItem(6, "RNG Casino"),
                new AccountInfoConfigurationItem(8, "Keno"),
                new AccountInfoConfigurationItem(12, "Gold Deluxe"),
                new AccountInfoConfigurationItem(15, "ColossusBets"),
                new AccountInfoConfigurationItem(16, "Sportsbook2"),
                new AccountInfoConfigurationItem(21, "AllBet"),
                new AccountInfoConfigurationItem(22, "Macau Games"),
                new AccountInfoConfigurationItem(23, "NG2"),
                new AccountInfoConfigurationItem(24, "Fishing World"),
                new AccountInfoConfigurationItem(26, "Lucky3"),
                new AccountInfoConfigurationItem(28, "Lottery"),
                new AccountInfoConfigurationItem(30, "Bullfighting"),
                new AccountInfoConfigurationItem(31, "Ricky bullshit product"),
                new AccountInfoConfigurationItem(32, "James 69 product")
        };
    }
}