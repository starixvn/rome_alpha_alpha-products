namespace Alpha.Products.MemberInfo
{
    using System.Collections.Generic;
    using Core.Configuration;
    using Core.Integration;

    public class ReviewCustomerConfigurationLoader : DefaultConfigurationLoader
    {
        public ReviewCustomerConfigurationLoader(IProductJsonConverter jsonConverter)
              : base("memberInfo", jsonConverter)
        {
        }

        protected override IExtendProductProperty BuildExtendProductProperty(IDictionary<string, string> extendedPropertyData)
            => BuildProductProperty<MemberInfoProperties>(extendedPropertyData);
    }
}
