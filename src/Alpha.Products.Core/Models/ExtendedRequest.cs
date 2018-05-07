namespace Alpha.Products.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public interface IExtendedRequest
    {
        IExtendedRequest AddData<T>(string key, T value);

        T GetData<T>(string key);

        bool ContainKey(string key);
    }

    public class ExtendedRequest : IExtendedRequest
    {
        protected Dictionary<string, object> dataBag = new Dictionary<string, object>();

        protected ExtendedRequest()
        { }

        public IExtendedRequest AddData<T>(string key, T value)
        {
            if (!string.IsNullOrWhiteSpace(key))
            {
                dataBag.Add(key, value);
            }

            return this;
        }

        public T GetData<T>(string key)
        {
            if (!dataBag.ContainsKey(key))
            {
                ThrowException(key);
            }

            return (T)dataBag[key];
        }

        public bool ContainKey(string key) => dataBag.ContainsKey(key);

        private static void ThrowException(string key)
        {
            var stackFrame = Array.Find(new StackTrace(true)
                                .GetFrames(), frame => frame.GetFileName().Contains("ViewModel"));

            throw new KeyNotFoundException($"Key {key} not found. Please review class file {stackFrame.GetFileName()} at line number {stackFrame.GetFileLineNumber()}");
        }
    }
}