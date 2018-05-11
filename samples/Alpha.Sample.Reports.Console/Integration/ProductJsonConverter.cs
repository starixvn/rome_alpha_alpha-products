namespace Alpha.Sample.Reports.Console.Integration
{
    using System.Collections.Generic;
    using System.Linq;
    using Alpha.Products.Core.Integration;
    using Newtonsoft.Json.Linq;

    public class ProductJsonConverter : IProductJsonConverter
    {
        public IDictionary<string, string> DeserializeToDictionary(string jsonString)
            => JObject.Parse(jsonString)
            .Properties()
            .ToDictionary(jproperty => jproperty.Name, jproperty => jproperty.Value.ToString());

        public IList<string> DeserializeToProductConfigs(string productConfigJson)
            => JObject.Parse(productConfigJson)["Products"]
            .Children()
            .Select(jtoken => jtoken.ToString())
            .ToList();
    }
}