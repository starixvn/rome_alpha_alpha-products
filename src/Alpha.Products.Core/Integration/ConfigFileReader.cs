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
        private readonly string appDomainAppPath;

        public ConfigFileReader(string appDomainAppPath = null)
        {
            this.appDomainAppPath = appDomainAppPath ?? HttpRuntime.AppDomainAppPath;
        }

        public string ReadProductConfig(string relativePath)
        {
            var configFilePath = appDomainAppPath + relativePath;
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