namespace Alpha.Products.Integration.Helpers
{
    using System.Collections.Generic;

    public interface IProductJsonConverter
    {
        IDictionary<string, string> DeserializeToDictionary(string jsonString);

        IList<string> DeserializeToProductConfigs(string productConfigJson);
    }
}