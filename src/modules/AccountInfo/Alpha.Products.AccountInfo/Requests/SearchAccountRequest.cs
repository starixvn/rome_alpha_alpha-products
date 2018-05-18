namespace Alpha.Products.AccountInfo.Requests
{
    using System;
    using Alpha.Products.Core.Configuration;
    using Alpha.Products.Core.Models;
    using Alpha.Products.Core.Services;

    /// <summary>
    /// should implementation be located in consumer sites.
    /// </summary>
    public abstract class SearchAccountRequest : ExtendedRequest, ISearchAccountInfoRequest
    {
        protected SearchAccountRequest(
            ICustomer actor,
            ICustomer searchAccount,
            Func<string, string> getResource = null,
            Func<int, string> getProductName = null)
        {
            Actor = actor;
            SearchAccount = searchAccount;
            this.GetResource = getResource ?? SimpleServiceLocator.GetService<Func<string, string>>();
            this.GetProductName = getProductName ?? SimpleServiceLocator.GetService<Func<int, string>>();
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

        public abstract Func<IConfigurationItem, bool> Predicate { get; }
    }

    public class SettingSearchAccountRequest : SearchAccountRequest
    {
        public SettingSearchAccountRequest(
            ICustomer actor,
            ICustomer searchAccount,
            Func<string, string> getResource = null,
            Func<int, string> getProductName = null)
            : base(actor, searchAccount, getResource, getProductName)
        {
        }

        public override Func<IConfigurationItem, bool> Predicate
#pragma warning disable S3215 // "interface" instances should not be cast to concrete types
            => config => (config.ExtendProductProperty as SearchAccountProperties).Setting;

#pragma warning restore S3215 // "interface" instances should not be cast to concrete types
    }

    public class StatusSearchAccountRequest : SearchAccountRequest
    {
        public StatusSearchAccountRequest(
            ICustomer actor,
            ICustomer searchAccount,
            Func<string, string> getResource = null,
            Func<int, string> getProductName = null)
            : base(actor, searchAccount, getResource, getProductName)
        {
        }

        public override Func<IConfigurationItem, bool> Predicate
#pragma warning disable S3215 // "interface" instances should not be cast to concrete types
            => config => (config.ExtendProductProperty as SearchAccountProperties).Status;

#pragma warning restore S3215 // "interface" instances should not be cast to concrete types
    }
}