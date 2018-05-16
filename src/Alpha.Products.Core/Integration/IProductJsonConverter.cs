namespace Alpha.Products.Core.Integration
{
    using System.Collections.Generic;

    public interface IProductJsonConverter
    {
        IDictionary<string, string> ToProductConfig(string productJson);

        IList<string> ToProductConfigs(string productConfigJson);
    }
}