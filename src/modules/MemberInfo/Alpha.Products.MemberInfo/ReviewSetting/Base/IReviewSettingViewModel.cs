namespace Alpha.Products.MemberInfo.ReviewSetting.Base
{
    using Core.ViewModels;

    public interface IReviewSettingViewModel : IViewModel
    {
        string Text { get; }

        string Url { get; }
    }
}
