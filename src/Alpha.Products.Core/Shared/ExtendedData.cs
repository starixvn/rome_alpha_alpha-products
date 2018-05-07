namespace Alpha.Products.Core.Shared
{
    using System.Collections.Generic;

    public interface IExtendedData
    {
        IExtendedData AddData<T>(string key, T value);

        T GetData<T>(string key);

        bool ContainKey(string key);
    }

    public abstract class ExtendedData : IExtendedData
    {
        protected Dictionary<string, object> extendedData = new Dictionary<string, object>();

        public IExtendedData AddData<T>(string key, T value)
        {
            if (!string.IsNullOrEmpty(key))
            {
                extendedData.Add(key, value);
            }

            return this;
        }

        public T GetData<T>(string key) => (T)extendedData[key];

        public bool ContainKey(string key) => extendedData.ContainsKey(key);
    }
}