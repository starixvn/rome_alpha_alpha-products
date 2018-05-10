namespace Alpha.Products.Core.Configuration
{
    using System;

    public interface IExtendProductProperty
    {
    }

    public interface IConfigurationItem<out T> 
        where T : IExtendProductProperty
    {
        int ProductId { get; }

        string ProductName { get; }

        bool Enabled { get; }

        DateTime EndSupportDate { get; }

        T ExtendProductProperty { get; }
    }
}