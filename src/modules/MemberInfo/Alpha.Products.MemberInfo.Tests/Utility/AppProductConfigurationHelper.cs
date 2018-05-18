namespace Alpha.Products.MemberInfo.Tests.Utility
{
    using System.Collections.Generic;
    using Core.Configuration;

    public static class AppProductConfigurationHelper
    {
        internal static IList<IConfigurationItem> LoadApplicationProductConfiguration()
            => new List<IConfigurationItem> {
                new ConfigurationItem(6, "RNG Casino", extendProductProperty: new MemberInfoProperties(true)),
                new ConfigurationItem(8, "Keno", extendProductProperty: new MemberInfoProperties(true)),
                new ConfigurationItem(12, "Gold Deluxe", extendProductProperty: new MemberInfoProperties(true)),
                new ConfigurationItem(15, "ColossusBets", extendProductProperty: new MemberInfoProperties(true)),
                new ConfigurationItem(16, "Sportsbook2", extendProductProperty: new MemberInfoProperties(true)),
                new ConfigurationItem(21, "AllBet", extendProductProperty: new MemberInfoProperties(true)),
                new ConfigurationItem(22, "Macau Games", extendProductProperty: new MemberInfoProperties(true)),
                new ConfigurationItem(24, "Fishing World", extendProductProperty: new MemberInfoProperties(true)),
                new ConfigurationItem(5, "Virtual Sports", extendProductProperty: new MemberInfoProperties(true)),
                new ConfigurationItem(28, "Lottery", extendProductProperty: new MemberInfoProperties(true))
            };
    }
}
