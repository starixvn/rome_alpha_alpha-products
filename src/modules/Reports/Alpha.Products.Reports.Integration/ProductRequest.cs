namespace Alpha.Products.Reports.Integration
{
    using System;
    using Alpha.Products.Core.Models;
    using Alpha.Products.Core.Services;

    public class ProductRequest : IRequest
    {
        public ProductRequest(
            ICustomer actor,
            Func<int, string> getProductName = null)
        {
            Actor = actor;
            GetProductName = getProductName ?? SimpleServiceLocator.Instance.GetService<Func<int, string>>();
        }

        public ProductRequest(
           ICustomer actor,
           Func<int, string> getProductName,
           Func<IProductConfigurationItem, bool> predicate = null)
            : this(actor, getProductName)
        {
            Predicate = predicate ?? (config => true);
        }

        public Func<int, string> GetProductName { get; }

        public Func<IProductConfigurationItem, bool> Predicate { get; }

        public ICustomer Actor { get; }

        public bool IsValid => true;

        public Func<string, string> GetResource { get; }
    }
}