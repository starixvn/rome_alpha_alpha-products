namespace Alpha.Products.Core.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using Alpha.Products.Core.Configuration;
    using Models;

    public abstract class GenericViewModelFactory<TRequest, TView>
        where TRequest : IRequest
        where TView : IViewModel
    {
        protected readonly ConfigurationService ConfigurationService;

        protected GenericViewModelFactory(ConfigurationService configurationService = null)
        {
            ConfigurationService = configurationService ?? new ConfigurationServiceImpl();
        }

        public IEnumerable<TView> GetViewModels(TRequest request)
            => request?.IsValid == true
            ? GetNonProductViewModels(request)
                .Concat(GetProductGroupViewModels(request))
                .Concat(GetProductViewModels(request))
                .OrderBy(viewModel => viewModel.DisplayOrder)
            : Enumerable.Empty<TView>();

        internal IEnumerable<TView> GetProductViewModels(TRequest request)
            => GetEnabledProductItems(request)
            .Select(productItem => GetProductViewModel(productItem, request));

        protected virtual IEnumerable<TView> GetNonProductViewModels(TRequest request)
            => Enumerable.Empty<TView>();

        protected abstract TView GetProductViewModel(IConfigurationItem productItem, TRequest request);

        protected IEnumerable<IConfigurationItem> GetEnabledProductItems(TRequest request)
        {
            var enabledProductItems = ConfigurationService
                .GetEnabledProductItems(request.Predicate);

            return request
                .Actor
                .GetProductStatus()
                .Where(productStatus
                      => productStatus.CanBeSeen
                      && productStatus.ProductGroupId == null
                      && enabledProductItems.Any(productItem => productItem.ProductId == productStatus.ProductId))
                .Select(ps
                        => enabledProductItems.First(
                        productItem => productItem.ProductId == ps.ProductId));
        }

        protected IEnumerable<TView> GetProductGroupViewModels(TRequest request)
            => GetEnabledProductGroupIds(request)
            .Select(productGroupId => GetProductGroupViewModel(productGroupId, request));

        protected abstract TView GetProductGroupViewModel(int productGroupId, TRequest request);

        protected virtual IEnumerable<int> GetEnabledProductGroupIds(TRequest request)
        {
            var groupIds = request
                .Actor
                .GetProductStatus()
                .Where(productStatus => productStatus.CanBeSeen && productStatus.ProductGroupId != null)
                .Select(p => p.ProductGroupId.Value);

            return groupIds
                .Distinct();
        }
    }
}