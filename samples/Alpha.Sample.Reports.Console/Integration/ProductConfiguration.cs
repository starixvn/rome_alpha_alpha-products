namespace Alpha.Sample.Reports.Console.Integration
{
    using System;
    using System.Collections.Generic;
    using Alpha.Products.Core.Configuration;
    using Alpha.Products.Reports;

    public static class ProductConfiguration
    {
        internal static IList<IConfigurationItem> LoadApplicationProductConfiguration()
         => new List<IConfigurationItem>
         {
            new ConfigurationItem(
                1, 
                "Sportsbook", 
                true, 
                new ReportProperties()
                .DisplayInLegend(true)
                .DisplayInMatchWinLoss(true)),
            new ConfigurationItem(2, "Racing", true, new DateTime(2018, 11, 11), new ReportProperties()),
            new ConfigurationItem(3, "Number Game", true, new ReportProperties()
                .DisplayInLegend(true)
                .DisplayInMatchWinLoss(true)),
            new ConfigurationItem(4, "Live Casino", true, new DateTime(2018, 11, 11), new ReportProperties()),
            new ConfigurationItem(5, "Virtual Sports", true, new ReportProperties()
                .DisplayInLegend(true)
                .DisplayInMatchWinLoss(true)),
            new ConfigurationItem(6, "RNG Casino", true, new ReportProperties()
                .DisplayInLegend(true)
                .DisplayInMatchWinLoss(true)
                .PlayForFun(true)),
            new ConfigurationItem(8, "Keno", true, new ReportProperties()),
            new ConfigurationItem(12, "Gold Deluxe", true, new ReportProperties()),
            new ConfigurationItem(15, "ColossusBets", false, new ReportProperties()),
            new ConfigurationItem(16, "Sportsbook2", true, new ReportProperties()),
            new ConfigurationItem(21, "AllBet", true, new ReportProperties()),
            new ConfigurationItem(22, "Macau Games", true, new ReportProperties()),
            new ConfigurationItem(23, "NG2", true, new ReportProperties()),
            new ConfigurationItem(24, "Fishing World", true, new ReportProperties()),
            new ConfigurationItem(26, "Lucky3", true, new ReportProperties()),
            new ConfigurationItem(28, "Lottery", true, new ReportProperties()),
            new ConfigurationItem(30, "Bullfighting", true, new ReportProperties())
         };
    }
}