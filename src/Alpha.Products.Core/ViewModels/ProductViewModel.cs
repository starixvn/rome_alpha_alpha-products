namespace Alpha.Products.Core.ViewModels
{
    public class ProductViewModel : IViewModel
    {
        public ProductViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        protected int Id { get; }

        public string Name { get; }

        public int DisplayOrder => Id;

        public bool Visible => true;

        public override string ToString()
        {
            return $"{{Id:{Id}, Name:{Name}}}";
        }
    }
}