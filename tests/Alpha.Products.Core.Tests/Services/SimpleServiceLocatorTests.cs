namespace Alpha.Products.Core.Tests.Services
{
    using System;
    using Alpha.Products.Core.Services;
    using Xunit;

    [Trait("Core", "Services/SimpleServiceLocator")]
    public class SimpleServiceLocatorTests
    {
        [Fact]
        public void Register_Always_AddedService()
        {
            Func<int> myService = () => 1;

            SimpleServiceLocator.Instance.Register(myService);

            Assert.Equal(myService, SimpleServiceLocator.GetService<Func<int>>());
        }

        [Fact]
        public void Register_ServiceWasNotRegistered_ThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => SimpleServiceLocator.GetService<Func<int, int>>());
        }
    }
}