namespace Alpha.Products.Integration
{
    using System;
    using System.Collections.Specialized;
    using System.Configuration;

    public static class GlobalProductSettings
    {
        internal static NameValueCollection Configs { get; set; } = ConfigurationManager.AppSettings;

        public static bool IsProductEnabled(int productId) => ToBoolean(Configs[$"EnableProduct-{productId}"]);

        private static bool ToBoolean(string value, bool defaultValue = false)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return defaultValue;
            }

            return value == "1" || value.Equals("true", StringComparison.CurrentCultureIgnoreCase);
        }
    }
}