namespace Alpha.Products.AccountInfo.Status
{
    using System.Collections.Generic;
    using Alpha.Products.AccountInfo.Requests;
    using Alpha.Products.AccountInfo.Status.ViewModels;
    using Alpha.Products.AccountInfo.Status.ViewModels.Base;
    using Alpha.Products.Core.Configuration;
    using Alpha.Products.Core.ViewModels;
    using static Alpha.Products.Core.Shared.ProductConstants;

    public sealed class StatusViewModelFactory
        : GenericViewModelFactory<ISearchAccountInfoRequest, IStatusItemViewModel>
    {
        public StatusViewModelFactory(ConfigurationService configurationService = null)
            : base(configurationService)
        {
        }

        protected override IEnumerable<IStatusItemViewModel> GetNonProductViewModels(ISearchAccountInfoRequest request)
        {
            yield return new ConfirmSuspendedViewModel(request);
            yield return new ConfirmClosedViewModel(request);
            yield return new ConfirmAllowOutrightViewModel(request);
            yield return new ConfirmAllowAutoMasterPTViewModel(request);
            yield return new ConfirmDoubleCommViewModel(request);
        }

        protected override IStatusItemViewModel GetProductViewModel(int productId, ISearchAccountInfoRequest request)
            => new ProductStatusItemViewModel(request, productId);

        protected override IEnumerable<int> GetExcludedProductIds()
        {
            yield return Sportsbook;
            yield return NumberGame;
            yield return GoldDeluxe;
            yield return Sportsbook2;
        }
    }
}