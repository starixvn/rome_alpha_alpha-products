namespace Alpha.Products.Reports
{
    using Alpha.Products.Core.Configuration;
    using Alpha.Products.Core.ViewModels;
    using Core.Models;

    public class ReportProductViewModelFactory : GenericViewModelFactory<IRequest, ProductViewModel>
    {
        public ReportProductViewModelFactory(ConfigurationService configurationService = null)
            : base(configurationService)
        {
        }

        protected override ProductViewModel GetProductViewModel(IConfigurationItem productItem, IRequest request)
            => new ProductViewModel(productItem.ProductId, request.GetProductName(productItem.ProductId));
    }
}