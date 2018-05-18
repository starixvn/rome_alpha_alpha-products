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

        protected override IReviewSettingViewModel GetProductViewModel(IConfigurationItem productItem, IReviewSettingRequest request)
        {
            var visible = (productItem.ExtendProductProperty as MemberInfoProperties).ReviewSetting;

            switch (productItem.ProductId)
            {
                case RNGCasino:
                    return new RNGCasinoViewModel(request, visible);
                case Keno:
                    return new KenoViewModel(request, visible);
                case GoldDeluxe:
                    return new GoldDeluxeViewModel(request, visible);
                case ColossusBets:
                    return new ColossusBetsViewModel(request, visible);
                default:
                    return new DCSProductViewModel(request, visible, productItem.ProductId);
            }
        }
    }
}
