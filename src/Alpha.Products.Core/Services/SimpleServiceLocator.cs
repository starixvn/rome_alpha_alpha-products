namespace Alpha.Products.Core.Services
{
    using System;
    using System.Collections.Generic;

    public sealed class SimpleServiceLocator
    {
        private static readonly Dictionary<string, object> container
            = new Dictionary<string, object>();

        static SimpleServiceLocator()
        {
        }

        private SimpleServiceLocator()
        {
        }

        public static SimpleServiceLocator Instance { get; } = new SimpleServiceLocator();

        public SimpleServiceLocator Register<T>(T service)
        {
            container[typeof(T).ToString()] = service;

            return this;
        }

        public T GetService<T>()
        {
            if (container.ContainsKey(typeof(T).ToString()))
            {
                return (T)container[typeof(T).ToString()];
            }

            throw new ApplicationException($"cannot resolve type {typeof(T).FullName}");
        }
    }
}