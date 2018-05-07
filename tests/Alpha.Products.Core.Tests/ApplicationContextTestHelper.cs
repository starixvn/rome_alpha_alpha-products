using System.Collections.Generic;
using System.Collections.ObjectModel;
using Alpha.Products.Core.Configuration;

namespace Alpha.Products.Core.Tests
{
    internal static class StubData
    {
        internal static ReadOnlyCollection<ConfigurationItem> ApplicationProductStatus
            => new ReadOnlyCollection<ConfigurationItem>(
                new List<ConfigurationItem> {
                    new ConfigurationItem(1, "Sportsbook"),
                    new ConfigurationItem(3, "Number Game", false),
                    new ConfigurationItem(5, "Virtual Sports", true),
                    new ConfigurationItem(6, "RNG Casino", true),
                    new ConfigurationItem(8, "Keno", true)});
    }
}