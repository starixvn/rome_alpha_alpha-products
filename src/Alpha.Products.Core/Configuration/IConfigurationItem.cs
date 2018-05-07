namespace Alpha.Products.Core.Configuration
{
    using System;

    public interface IExtendProductProperty
    {
    }

    public interface IConfigurationItem
    {
        int ProductId { get; }

        string ProductName { get; }

        bool Enabled { get; }

        DateTime EndSupportDate { get; }

        IExtendProductProperty ExtendProductProperty { get; }
    }
}