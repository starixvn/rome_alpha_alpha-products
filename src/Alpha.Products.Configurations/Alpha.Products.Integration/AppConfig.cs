namespace Alpha.Products.Integration
{
    using System.Collections.Generic;
    using Alpha.Products.Core.Models;

    internal static class AppConfig
    {
        /// <summary>
        /// it will be replaced by code loading setting from shared config
        /// </summary>
        /// <returns></returns>
        internal static IList<IProductConfigurationItem> LoadApplicationProductConfiguration()
        => new List<IProductConfigurationItem>()
        {
                new ProductConfigurationItem(1, "Sportsbook", true),
                new ProductConfigurationItem(2, "Racing", false),
                new ProductConfigurationItem(3, "Number Game"),
                new ProductConfigurationItem(4, "Live Casino", false),
                new ProductConfigurationItem(5, "Virtual Sports"),
                new ProductConfigurationItem(6, "RNG Casino"),
                new ProductConfigurationItem(8, "Keno"),
                new ProductConfigurationItem(12, "Gold Deluxe", true),
                new ProductConfigurationItem(15, "ColossusBets", false),
                new ProductConfigurationItem(16, "Sportsbook2"),
                new ProductConfigurationItem(21, "AllBet"),
                new ProductConfigurationItem(22, "Macau Games"),
                new ProductConfigurationItem(23, "NG2"),
                new ProductConfigurationItem(24, "Fishing World"),
                new ProductConfigurationItem(26, "Lucky3"),
                new ProductConfigurationItem(28, "Lottery"),
                new ProductConfigurationItem(30, "Bullfighting"),
                new ProductConfigurationItem(31, "Ricky bullshit product"),
                new ProductConfigurationItem(32, "James 69 product")
        };
    }
}