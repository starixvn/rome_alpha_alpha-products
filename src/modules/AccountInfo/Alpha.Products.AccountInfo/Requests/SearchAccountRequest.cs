namespace Alpha.Products.AccountInfo.Requests
{
    using System;
    using Alpha.Products.Core.Configuration;
    using Alpha.Products.Core.Models;
    using Alpha.Products.Core.Services;

    /// <summary>
    /// should implementation be located in consumer sites.
    /// </summary>
    public class SearchAccountRequest : ExtendedRequest, ISearchAccountInfoRequest
    {
        public SearchAccountRequest(
            ICustomer actor,
            ICustomer searchAccount,
            Func<string, string> GetResource = null,
            Func<int, string> GetProductName = null)
        {
            Actor = actor;
            SearchAccount = searchAccount;
            this.GetResource = GetResource ?? SimpleServiceLocator.GetService<Func<string, string>>();
            this.GetProductName = GetProductName ?? SimpleServiceLocator.GetService<Func<int, string>>();
        }

        public ICustomer Actor { get; }

        public ICustomer SearchAccount { get; }

        public virtual bool IsValid =>
            Actor != null
            && SearchAccount != null
            && Actor.IsUplineOf(SearchAccount);

        public bool ActorIsEdittingDirectDownline => Actor.IsDirectUplineOf(SearchAccount);

        public bool ActorIsNotEdittingDirectDownline => !ActorIsEdittingDirectDownline;

        public Func<string, string> GetResource { get; }

        public Func<int, string> GetProductName { get; }

        public Func<IConfigurationItem, bool> Predicate { get; }
    }
}