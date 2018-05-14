namespace Alpha.Products.Core.Integration
{
    using System.IO;

    public interface IConfigFileReader
    {
        string ReadProductConfig(string relativePath);
    }

    public class ConfigFileReader : IConfigFileReader
    {
        public string ReadProductConfig(string relativePath)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var absoluteConfigFilePath = Path.Combine(currentDirectory, relativePath);
            if (File.Exists(absoluteConfigFilePath))
            {
                // Read file without locking file
                using (FileStream fileStream = new FileStream(relativePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader streamReader = new StreamReader(fileStream))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }
            else
            {
                throw new FileNotFoundException($"Cannot find json file: {relativePath}");
            }
        }
    }
}