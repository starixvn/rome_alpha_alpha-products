namespace Alpha.Products.Core.Tests.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Alpha.Products.Core.Models;
    using Xunit;

    [Trait("Core", "Models/ExtendedRequest")]
    public class ExtendedRequestTests
    {
        private readonly ExtendedRequest extendedRequest;

        public ExtendedRequestTests()
        {
            extendedRequest = new ExtendedRequest();
        }

        [Theory]
        [InlineData("key1", 1)]
        [InlineData("key2", "value2")]
        [InlineData("key3", true)]
        [InlineData("key4", 3.6)]
        public void AddData_Always_AddedData(string key, object value)
        {
            extendedRequest.AddData(key, value);

            Assert.Equal(value, extendedRequest.GetData<object>(key));
        }

        [Fact]
        public void GetData_DataIsNotExist_ThrowKeyNotFoundException()
        {
            Assert.Throws<KeyNotFoundException>(() => extendedRequest.GetData<int>("notfoundkey"));
        }
    }
}
