using System;
using System.Collections.Generic;
using Alpha.Products.Core.Models;
using Alpha.Products.Reports.Models;

namespace Alpha.Products.Reports.Integration
{
    public static class AppConfig
    {
        internal static IList<IProductConfigurationItem> LoadApplicationProductConfiguration()
         => new List<IProductConfigurationItem>()
         {
            new ProductConfigurationItem(1, "Sportsbook", true, new ReportProperties()
                .DisplayInLegend(true)
                .DisplayInMatchWinLoss(true)),
            new ProductConfigurationItem(2, "Racing", true, new DateTime(2018, 11, 11), new ReportProperties()),
            new ProductConfigurationItem(3, "Number Game", true, new ReportProperties()
                .DisplayInLegend(true)
                .DisplayInMatchWinLoss(true)),
            new ProductConfigurationItem(4, "Live Casino", true, new DateTime(2018, 11, 11), new ReportProperties()),
            new ProductConfigurationItem(5, "Virtual Sports", true, new ReportProperties()
                .DisplayInLegend(true)
                .DisplayInMatchWinLoss(true)),
            new ProductConfigurationItem(6, "RNG Casino", true, new ReportProperties()
                .DisplayInLegend(true)
                .DisplayInMatchWinLoss(true)
                .PlayForFun(true)),
            new ProductConfigurationItem(8, "Keno", true, new ReportProperties()),
            new ProductConfigurationItem(12, "Gold Deluxe", true, new ReportProperties()),
            new ProductConfigurationItem(15, "ColossusBets", false, new ReportProperties()),
            new ProductConfigurationItem(16, "Sportsbook2", true, new ReportProperties()),
            new ProductConfigurationItem(21, "AllBet", true, new ReportProperties()),
            new ProductConfigurationItem(22, "Macau Games", true, new ReportProperties()),
            new ProductConfigurationItem(23, "NG2", true, new ReportProperties()),
            new ProductConfigurationItem(24, "Fishing World", true, new ReportProperties()),
            new ProductConfigurationItem(26, "Lucky3", true, new ReportProperties()),
            new ProductConfigurationItem(28, "Lottery", true, new ReportProperties()),
            new ProductConfigurationItem(30, "Bullfighting", true, new ReportProperties())
         };
    }
}