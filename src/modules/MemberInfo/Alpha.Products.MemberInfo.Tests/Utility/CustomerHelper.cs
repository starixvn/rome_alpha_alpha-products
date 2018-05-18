namespace Alpha.Products.MemberInfo.Tests.Utility
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Core.Models;

    public static class CustomerHelper
    {
        public static IEnumerable<CustomerProductStatus> CreateCustomerProductStatus()
            => new ReadOnlyCollection<CustomerProductStatus>(
                    new List<CustomerProductStatus>()
                    {
                        new CustomerProductStatus(6),
                        new CustomerProductStatus(8),
                        new CustomerProductStatus(12),
                        new CustomerProductStatus(15),
                        new CustomerProductStatus(16),
                        new CustomerProductStatus(21),
                        new CustomerProductStatus(22),
                        new CustomerProductStatus(24),
                        new CustomerProductStatus(5),
                        new CustomerProductStatus(28),
                        new CustomerProductStatus(29, false, true)
                    });

        public static ICustomer CreateSuper(int custId = 1)
        {
            return CreateCustomer(custId, 4);
        }

        public static ICustomer CreateMaster(int custId = 2)
        {
            return CreateCustomer(custId, 3);
        }

        public static ICustomer CreateCustomer(
            int custId = 1,
            byte customerLevelValue = 4,
            int subAccountId = 0,
            IEnumerable<CustomerProductStatus> customerProductStatus = null)
        {
            customerProductStatus = customerProductStatus ?? CreateCustomerProductStatus();
            var upline = new Customer(custId, subAccountId, $"username{1}", (byte)(customerLevelValue + 1), customerProductStatus);
            var customer = new Customer(custId, subAccountId, $"username{1}", customerLevelValue, customerProductStatus, customerLevelValue.Equals(4) ? null : upline);

            return customer;
        }
    }
}
