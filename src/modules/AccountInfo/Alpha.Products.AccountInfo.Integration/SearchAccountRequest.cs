namespace Alpha.Products.AccountInfo.Integration
{
    using System;
    using Alpha.Products.AccountInfo.Contracts;
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
            this.GetResource = GetResource ?? SimpleServiceLocator.Instance.GetService<Func<string, string>>();
            this.GetProductName = GetProductName ?? SimpleServiceLocator.Instance.GetService<Func<int, string>>();
        }

        public SearchAccountRequest(ICustomer actor, ICustomer searchAccount)
            : this(actor, searchAccount, null, null)
        {
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

        public Func<IProductConfigurationItem, bool> Predicate => (config) => true;
    }
}