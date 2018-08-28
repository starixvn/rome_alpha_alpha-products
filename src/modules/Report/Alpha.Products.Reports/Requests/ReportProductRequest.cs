namespace Alpha.Products.Reports.Requests
{
    using Alpha.Products.Core.Configuration;
    using Alpha.Products.Core.Models;
    using Alpha.Products.Core.Services;
    using System;

    public class ReportProductRequest : IRequest
    {
        public ReportProductRequest(
            ICustomer actor,
            Func<int, string> getProductName = null)
        {
            Actor = actor;
            GetProductName = getProductName ?? SimpleServiceLocator.GetService<Func<int, string>>();
        }

        public ReportProductRequest(
           ICustomer actor,
           Func<int, string> getProductName,
           Func<IConfigurationItem, bool> predicate = null)
            : this(actor, getProductName)
        {
            Predicate = predicate;
        }

        public Func<int, string> GetProductName { get; }

        public Func<IConfigurationItem, bool> Predicate { get; protected set; }

        public ICustomer Actor { get; }

        public bool IsValid => true;

        public Func<string, string> GetResource { get; }

        public Func<string, string, string> GetMicroSiteUrl { get; }
    }
}