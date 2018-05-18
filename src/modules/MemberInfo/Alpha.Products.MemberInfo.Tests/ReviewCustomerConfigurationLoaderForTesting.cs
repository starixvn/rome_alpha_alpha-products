namespace Alpha.Products.MemberInfo.Tests
{
    using System.Collections.Generic;
    using Core.Configuration;
    using Core.Integration;

    public class ReviewCustomerConfigurationLoaderForTesting : ReviewCustomerConfigurationLoader
    {
        public ReviewCustomerConfigurationLoaderForTesting(IProductJsonConverter jsonConverter)
              : base(jsonConverter)
        {
        }

        public IExtendProductProperty CallBuildExtendProductProperty(IDictionary<string, string> extendedPropertyData)
            => BuildExtendProductProperty(extendedPropertyData);
    }
}
