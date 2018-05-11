namespace Alpha.Sample.Reports.Console.Integration
{
    using System.Collections.Generic;
    using System.Linq;
    using Alpha.Products.Integration.Helpers;
    using Newtonsoft.Json.Linq;

    public class ProductJsonConverter : IProductJsonConverter
    {
        public IDictionary<string, string> DeserializeToDictionary(string jsonString)
            => JObject.Parse(jsonString)
            .Properties()
            .ToDictionary(jproperty => jproperty.Name, jproperty => jproperty.Value.ToString());

        public IList<string> DeserializeToProductConfigs(string jsonString)
            => JObject.Parse(jsonString)["Products"]
            .Children()
            .Select(jtoken => jtoken.ToString())
            .ToList();
    }
}