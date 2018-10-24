namespace Alpha.Products.Core.Integration
{
    using System.IO;

    public interface IConfigFileReader
    {
        string ReadProductConfig();
    }

    public class ConfigFileReader : IConfigFileReader
    {
        private readonly string filePath;

        public ConfigFileReader(string filePath)
        {
            this.filePath = filePath;
        }

        public string ReadProductConfig()
        {
            if (File.Exists(filePath))
            {
                // Read file without locking file
                using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader streamReader = new StreamReader(fileStream))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }

            throw new FileNotFoundException($"Cannot find json file: {filePath}");
        }
    }
}