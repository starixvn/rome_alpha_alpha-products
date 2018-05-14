namespace Alpha.Products.Core.Integration
{
    using System.Collections.Generic;

    public interface IProductJsonConverter
    {
        IDictionary<string, string> ToDictionary(string jsonString);

        IList<string> ToProductConfigs(string productConfigJson);
    }
}