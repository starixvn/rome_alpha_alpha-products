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
                .OrderBy(viewModel => viewModel.DisplayOrder)
            : Enumerable.Empty<TView>();

        protected virtual IEnumerable<TView> GetNonProductViewModels(TRequest request)
            => Enumerable.Empty<TView>();

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