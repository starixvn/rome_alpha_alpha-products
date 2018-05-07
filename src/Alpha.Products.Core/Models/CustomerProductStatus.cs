namespace Alpha.Products.Core.Models
{
    public interface ICustomerProductStatus
    {
        int ProductId { get; }
        bool Disabled { get; }
        bool Enabled { get; }
        bool Hidden { get; }
        bool Synced { get; }
        bool CanBeSeen { get; }
    }

    public class CustomerProductStatus : ICustomerProductStatus
    {
        public CustomerProductStatus(
            int productId,
            bool disabled = false,
            bool hidden = false,
            bool synced = true)
        {
            ProductId = productId;
            Disabled = disabled;
            Hidden = hidden;
            Synced = synced;
        }

        public int ProductId { get; }
        public bool Disabled { get; }
        public bool Enabled => !Disabled;
        public bool Hidden { get; }
        public bool Synced { get; }
        public bool CanBeSeen => Synced && !Hidden;
    }
}