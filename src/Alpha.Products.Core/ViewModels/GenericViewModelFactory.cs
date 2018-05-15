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
            => GetProductIds(request)
            .Select(productId => GetProductViewModel(productId, request));

        protected virtual IEnumerable<TView> GetNonProductViewModels(TRequest request)
            => Enumerable.Empty<TView>();

        protected abstract TView GetProductViewModel(int productId, TRequest request);

        protected IEnumerable<int> GetProductIds(TRequest request)
        {
            var enableProductIds = ConfigurationService
                .GetEnabledProductIds(request.Predicate);

            return request.Actor.GetProductStatus()
              .Where(productStatus
                  => productStatus.CanBeSeen
                  && enableProductIds.Contains(productStatus.ProductId))
              .Select(ps => ps.ProductId);
        }
    }
}