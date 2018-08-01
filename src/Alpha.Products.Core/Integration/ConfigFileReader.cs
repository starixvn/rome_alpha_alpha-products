namespace Alpha.Products.Core.Integration
{
    using System.IO;
    using System.Web;

    public interface IConfigFileReader
    {
        string ReadProductConfig(string relativePath);
    }

    public class ConfigFileReader : IConfigFileReader
    {
        public string ReadProductConfig(string relativePath)
        {
            var configFilePath = HttpRuntime.AppDomainAppPath + relativePath;
            if (File.Exists(configFilePath))
            {
                // Read file without locking file
                using (FileStream fileStream = new FileStream(configFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
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