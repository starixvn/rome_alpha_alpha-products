namespace Alpha.Products.MemberInfo.Tests.Utility
{
    using System.Collections.Generic;
    using Core.Configuration;

    public static class AppProductConfigurationHelper
    {
        internal static IList<IConfigurationItem> LoadApplicationProductConfiguration()
            => new List<IConfigurationItem> {
                new ConfigurationItem(6, "RNG Casino"),
                new ConfigurationItem(8, "Keno"),
                new ConfigurationItem(12, "Gold Deluxe"),
                new ConfigurationItem(15, "ColossusBets"),
                new ConfigurationItem(16, "Sportsbook2"),
                new ConfigurationItem(21, "AllBet"),
                new ConfigurationItem(22, "Macau Games"),
                new ConfigurationItem(24, "Fishing World"),
                new ConfigurationItem(5, "Virtual Sports"),
                new ConfigurationItem(28, "Lottery")
            };
    }
}
