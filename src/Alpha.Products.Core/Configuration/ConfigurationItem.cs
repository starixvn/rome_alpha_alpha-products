namespace Alpha.Products.Core.Configuration
{
    using System;

    public class ConfigurationItem<T> : IConfigurationItem<T> 
        where T : IExtendProductProperty
    {
        public ConfigurationItem(
            int productId,
            string productName,
            bool enabled,
            DateTime endSupportDate,
            T extendProductProperty = default(T))
        {
            ProductId = productId;
            ProductName = productName;
            Enabled = enabled;
            EndSupportDate = endSupportDate;
            ExtendProductProperty = extendProductProperty;
        }

        public ConfigurationItem(int productId, string productName, bool enabled = true, T extendProductProperty = default(T))
            : this(productId, productName, enabled, DateTime.MaxValue, extendProductProperty)
        {
        }

        public int ProductId { get; }

        public string ProductName { get; }

        public bool Enabled { get; }

        public DateTime EndSupportDate { get; }

        public T ExtendProductProperty { get; }
    }
}