namespace Alpha.Products.Core.Models
{
    using System;
    using Alpha.Products.Core.Configuration;

    public interface IRequest
    {
        ICustomer Actor { get; }

        Func<IConfigurationItem, bool> Predicate { get; }

        bool IsValid { get; }

        Func<int, string> GetProductName { get; }

        Func<string, string> GetResource { get; }
    }
}