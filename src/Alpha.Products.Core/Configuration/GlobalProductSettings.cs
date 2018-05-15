namespace Alpha.Products.Core.Integration
{
    using System;
    using System.Collections.Specialized;
    using System.Configuration;

    public static class GlobalProductSettings
    {
        internal static NameValueCollection Configs { get; set; } = ConfigurationManager.AppSettings;

        public static bool IsProductEnabled(int productId) => ToBoolean(Configs[$"EnableProduct-{productId}"]);

        public static string ProductConfigFileRelativePath => Configs[$"ProductConfigsFileRelativePath"];

        private static bool ToBoolean(string value, bool defaultValue = false)
            => (string.IsNullOrWhiteSpace(value))
            ? defaultValue
            : value == "1" || value.Equals("true", StringComparison.CurrentCultureIgnoreCase);
    }
}