namespace Alpha.Products.AccountInfo.Status.ViewModels
{
    using Alpha.Products.AccountInfo.Requests;
    using Base;

    public abstract class ConfirmStatusItemViewModelBase : StatusItemViewModel
    {
        protected ConfirmStatusItemViewModelBase(ISearchAccountInfoRequest request, int displayOrder)
            : base(request, displayOrder)
        {
        }

        public virtual string ConfirmMessage => Request.GetResource($"{GetType().Name}Message");
    }
}