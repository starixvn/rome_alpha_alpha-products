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
                      && enabledProductItems.Any(productItem => productItem.ProductId == productStatus.ProductId))
                .Select(ps
                        => enabledProductItems.First(
                        productItem => productItem.ProductId == ps.ProductId));
        }
    }
}