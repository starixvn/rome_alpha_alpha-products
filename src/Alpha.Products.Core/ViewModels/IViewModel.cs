namespace Alpha.Products.Core.ViewModels
{
    public interface IViewModel
    {
        int DisplayOrder { get; }

        bool Visible { get; }
    }
}