namespace Alpha.Products.Core.Tests.Integration
{
    using System.IO;
    using Alpha.Products.Core.Integration;
    using Xunit;

    /// <summary>
    /// This class for integration test, not unittest
    /// </summary>
    [Trait("Core", "Integration/ConfigFileReaderTests")]
    public class ConfigFileReaderTests
    {
        [Fact]
        public void ReadProductConfig_FileIsExist_ReturnFileContent()
        {
            var fileContent = new ConfigFileReader().ReadProductConfig("ProductConfiguration.json");

            Assert.Equal("file content 1", fileContent);
        }

        [Fact]
        public void ReadProductConfig_FileIsNotExist_ThrowFileNotFoundException()
        {
            Assert.Throws<FileNotFoundException>(() => new ConfigFileReader().ReadProductConfig("ProductConfiguration1.json"));
        }
    }
}