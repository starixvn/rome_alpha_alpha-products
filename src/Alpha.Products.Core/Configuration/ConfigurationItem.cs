namespace Alpha.Products.Core.Configuration
{
    using System;

    public class ConfigurationItem : IConfigurationItem
    {
        public ConfigurationItem(
            int productId,
            string productName,
            bool enabled,
            DateTime endSupportDate,
            IExtendProductProperty extendProductProperty = null)
        {
            ProductId = productId;
            ProductName = productName;
            Enabled = enabled;
            EndSupportDate = endSupportDate;
            ExtendProductProperty = extendProductProperty;
        }

        public ConfigurationItem(int productId, string productName, bool enabled = true, IExtendProductProperty extendProductProperty = null)
            : this(productId, productName, enabled, DateTime.MaxValue, extendProductProperty)
        {
        }

        public int ProductId { get; private set; }

        public string ProductName { get; private set; }

        public bool Enabled { get; private set; }

        public DateTime EndSupportDate { get; private set; }

        public IExtendProductProperty ExtendProductProperty { get; private set; }
    }
}