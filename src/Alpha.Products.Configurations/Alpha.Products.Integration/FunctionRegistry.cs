namespace Alpha.Products.Integration
{
    using System;
    using System.Collections.Generic;
    using Alpha.Products.Core.Models;
    using Alpha.RemotingRef;

    public static class FunctionRegistry
    {
        public static Func<IEnumerable<IProductConfigurationItem>> GetProductConfiguration
            => AppConfig.LoadApplicationProductConfiguration;

        public static Func<int, string> GetProductName
            => CacheRef.GetProductName;
    }
}