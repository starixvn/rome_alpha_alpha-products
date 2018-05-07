namespace Alpha.Products.Reports.Integration
{
    using System;
    using System.Collections.Generic;
    using Alpha.Products.Core.Models;
    using Alpha.Products.Core.Services;
    using Alpha.RemotingRef;

    public static class FunctionRegistry
    {
        public static void Start(Func<IEnumerable<IProductConfigurationItem>> configurationLoader = null)
        {
            SimpleServiceLocator
                 .Instance
                 .Register<Func<IEnumerable<IProductConfigurationItem>>>
                    (configurationLoader ?? AppConfig.LoadApplicationProductConfiguration)
                 .Register<Func<int, string>>(CacheRef.GetProductName);
        }
    }
}