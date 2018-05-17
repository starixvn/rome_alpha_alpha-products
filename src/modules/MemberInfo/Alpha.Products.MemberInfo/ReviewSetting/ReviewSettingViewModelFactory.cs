namespace Alpha.Products.MemberInfo.ReviewSetting
{
    using System.Collections.Generic;
    using Base;
    using Core.Configuration;
    using Core.ViewModels;
    using Requests;
    using ViewModels;
    using static Core.Shared.ProductConstants;

    public class ReviewSettingViewModelFactory : GenericViewModelFactory<IReviewSettingRequest, IReviewSettingViewModel>
    {
        public ReviewSettingViewModelFactory(ConfigurationService configurationService = null)
            : base(configurationService)
        {
        }

        protected override IEnumerable<IReviewSettingViewModel> GetNonProductViewModels(IReviewSettingRequest request)
        {
            yield return new SportsbookMinPTViewModel(request);
        }

        protected override IReviewSettingViewModel GetProductViewModel(int productId, IReviewSettingRequest request)
        {
            switch (productId)
            {
                case RNGCasino:
                    return new RNGCasinoViewModel(request);
                case Keno:
                    return new KenoViewModel(request);
                case GoldDeluxe:
                    return new GoldDeluxeViewModel(request);
                case ColossusBets:
                    return new ColossusBetsViewModel(request);
                default:
                    return new DCSProductViewModel(request, productId);
            }
        }
    }
}
