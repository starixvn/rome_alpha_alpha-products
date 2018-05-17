namespace Alpha.Products.MemberInfo.Tests.ReviewSetting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Configuration;
    using Core.Services;
    using MemberInfo.ReviewSetting;
    using MemberInfo.ReviewSetting.Base;
    using MemberInfo.ReviewSetting.ViewModels;
    using NSubstitute;
    using Requests;
    using Xunit;
    using static Core.Shared.ProductConstants;
    using static Utility.AppProductConfigurationHelper;
    using static Utility.CustomerHelper;

    [Trait("ReviewSetting", "ReviewSettingViewModelFactory")]
    public class ReviewSettingViewModelFactoryTests
    {
        private readonly ReviewSettingViewModelFactory factory;
        private readonly IConfigurationLoader configurationLoader;

        public ReviewSettingViewModelFactoryTests()
        {
            configurationLoader = Substitute.For<IConfigurationLoader>();
            configurationLoader.Load().Returns(LoadApplicationProductConfiguration());

            SimpleServiceLocator
               .Instance
               .Register(configurationLoader)
               .Register<Func<int, string>>((productId) => $"Product Name of {productId}")
               .Register<Func<string, string>>(key => $"value of {key}");

            factory = new ReviewSettingViewModelFactory();
        }

        [Theory]
        [InlineData(RNGCasino, typeof(RNGCasinoViewModel))]
        [InlineData(Keno, typeof(KenoViewModel))]
        [InlineData(GoldDeluxe, typeof(GoldDeluxeViewModel))]
        [InlineData(ColossusBets, typeof(ColossusBetsViewModel))]
        [InlineData(Sportsbook2, typeof(DCSProductViewModel))]
        [InlineData(Lottery, typeof(DCSProductViewModel))]
        public void GetViewModels_Always_ReturnRightMappingProductViewModel(int productId, Type viewModelType)
        {
            var request = new ReviewSettingRequest(CreateSuper(), CreateMaster());

            var viewModels = factory.GetViewModels(request);

            var rightModelMapping = viewModels
                 .Any(viewModel => viewModel is ReviewProductSettingViewModel
                 && ((ReviewProductSettingViewModel)viewModel).ProductId == productId
                 && viewModel.GetType() == viewModelType);

            Assert.True(rightModelMapping);
        }

        [Theory]
        [InlineData(typeof(SportsbookMinPTViewModel))]
        public void GetViewModels_Always_ReturnRightMappingNonProductViewModel(Type viewModelType)
        {
            var request = new ReviewSettingRequest(CreateSuper(), CreateMaster());

            var viewModels = factory.GetViewModels(request);

            var rightModelMapping = viewModels
                 .Any(viewModel => viewModel is ReviewSettingViewModel
                 && viewModel.GetType() == viewModelType);

            Assert.True(rightModelMapping);
        }
    }
}
