namespace Alpha.Products.AccountInfo.Tests.Utility
{
    using System.Collections.Generic;
    using Alpha.Products.Core.Configuration;

    public static class AppProductConfigurationHelper
    {
        internal static IList<IConfigurationItem> LoadApplicationProductConfiguration()
        => new List<IConfigurationItem>()
        {
                new ConfigurationItem(1, "Sportsbook"),
                new ConfigurationItem(3, "Number Game"),
                new ConfigurationItem(5, "Virtual Sports"),
                new ConfigurationItem(6, "RNG Casino"),
                new ConfigurationItem(8, "Keno"),
                new ConfigurationItem(12, "Gold Deluxe"),
                new ConfigurationItem(15, "ColossusBets"),
                new ConfigurationItem(16, "Sportsbook2"),
                new ConfigurationItem(21, "AllBet"),
                new ConfigurationItem(22, "Macau Games"),
                new ConfigurationItem(23, "NG2"),
                new ConfigurationItem(24, "Fishing World"),
                new ConfigurationItem(26, "Lucky3"),
                new ConfigurationItem(28, "Lottery"),
                new ConfigurationItem(30, "Bullfighting"),
                new ConfigurationItem(31, "Ricky bullshit product"),
                new ConfigurationItem(1000, "James 69 product"),
                new ConfigurationItem(2000, "James 2000 product"),
                new ConfigurationItem(3000, "3000")
        };

        internal static IList<IConfigurationItem> LoadApplicationProductConfiguration(params int[] productIds)
        {
            var configurationItems = new List<IConfigurationItem>();

            foreach (var productId in productIds)
            {
                configurationItems.Add(new ConfigurationItem(productId, $"productName {productId}"));
            }

            return configurationItems;
        }
    }
}