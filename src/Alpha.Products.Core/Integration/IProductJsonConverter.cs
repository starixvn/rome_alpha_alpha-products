namespace Alpha.Products.Core.Integration
{
    using System.Collections.Generic;

    public interface IProductJsonConverter
    {
        IDictionary<string, string> ToExtendProductPropertyData(string productJson);

        IList<string> ToProductConfigs(string productConfigJson);
    }
}