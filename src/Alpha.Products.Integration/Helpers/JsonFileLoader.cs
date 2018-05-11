namespace Alpha.Products.Integration.Helpers
{
    using System.IO;

    public interface IJsonFileReader
    {
        string ReadProductJsonConfig(string relativePath);
    }

    public class JsonFileReader : IJsonFileReader
    {
        public string ReadProductJsonConfig(string relativePath)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var absoluteConfigFilePath = Path.Combine(currentDirectory, relativePath);
            if (File.Exists(absoluteConfigFilePath))
            {
                using (StreamReader sr = new StreamReader(relativePath))
                {
                    return sr.ReadToEnd();
                }
            }
            else
            {
                throw new FileNotFoundException($"Cannot find json file: {relativePath}");
            }
        }
    }
}