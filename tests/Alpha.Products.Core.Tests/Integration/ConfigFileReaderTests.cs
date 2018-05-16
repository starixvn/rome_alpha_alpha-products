namespace Alpha.Products.Core.Tests.Integration
{
    using Alpha.Products.Core.Integration;
    using Xunit;

    /// <summary>
    /// This class for integration test, not unittest
    /// </summary>
    [Trait("Core", "Integration/ConfigFileReaderTests")]
    public class ConfigFileReaderTests
    {
        [Fact]
        public void ReadProductConfig_ExistFile_ReturnFileContent()
        {
            var fileContent = new ConfigFileReader().ReadProductConfig("ProductConfiguration.json");

            Assert.Equal("file content 1", fileContent);
        }
    }
}