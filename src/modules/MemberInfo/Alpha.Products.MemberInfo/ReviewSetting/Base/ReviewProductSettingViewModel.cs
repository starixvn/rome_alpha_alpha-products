namespace Alpha.Products.MemberInfo.ReviewSetting.Base
{
    using Requests;

    public abstract class ReviewProductSettingViewModel : ReviewSettingViewModel
    {
        protected ReviewProductSettingViewModel(IReviewSettingRequest request, bool visisible, int productId, int displayOrder)
            : base(request, displayOrder)
        {
            ProductId = productId;
            Visible = visisible;
        }

        internal int ProductId { get; }

        public override string Text => Request.GetProductName(ProductId);

        public override bool Visible { get; }
    }
}
