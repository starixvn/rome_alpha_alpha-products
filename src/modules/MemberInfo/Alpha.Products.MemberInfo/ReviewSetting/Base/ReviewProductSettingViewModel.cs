namespace Alpha.Products.MemberInfo.ReviewSetting.Base
{
    using Requests;

    public abstract class ReviewProductSettingViewModel : ReviewSettingViewModel
    {
        protected ReviewProductSettingViewModel(IReviewSettingRequest request, int productId, int displayOrder)
            : base(request, displayOrder)
        {
            ProductId = productId;
        }

        internal int ProductId { get; }

        public override string Text => Request.GetProductName(ProductId);

        public override bool Visible => true;
    }
}
