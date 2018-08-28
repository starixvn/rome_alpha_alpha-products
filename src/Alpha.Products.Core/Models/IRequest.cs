namespace Alpha.Products.Core.Models
{
    using Alpha.Products.Core.Configuration;
    using System;
    using System.Collections.Generic;

    public interface IRequest
    {
        ICustomer Actor { get; }

        Func<IConfigurationItem, bool> Predicate { get; }

        bool IsValid { get; }

        Func<int, string> GetProductName { get; }

        Func<string, string> GetResource { get; }

        Func<string, string, string> GetMicroSiteUrl { get; }
    }
}