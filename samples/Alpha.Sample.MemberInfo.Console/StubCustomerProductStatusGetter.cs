namespace Alpha.Sample.MemberInfo.Console
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Products.Core.Models;

    public static class StubCustomerProductStatusGetter
    {
        public static IEnumerable<CustomerProductStatus> GetUplineProductStatus()
        {
            return GetCustomerProductStatus();
        }

        public static IEnumerable<CustomerProductStatus> GetActorProductStatus()
        {
            return GetCustomerProductStatus();
        }

        public static IEnumerable<CustomerProductStatus> GetReviewedCustomerProductStatus()
        {
            return GetCustomerProductStatus();
        }

        public static IEnumerable<CustomerProductStatus> GetCustomerProductStatus()
            => new ReadOnlyCollection<CustomerProductStatus>(
                    new List<CustomerProductStatus>
                    {
                        new CustomerProductStatus(6),
                        new CustomerProductStatus(8),
                        new CustomerProductStatus(12),
                        new CustomerProductStatus(15),
                        new CustomerProductStatus(16),
                        new CustomerProductStatus(21),
                        new CustomerProductStatus(22),
                        new CustomerProductStatus(24, true),
                        new CustomerProductStatus(5)
                    });
    }
}
