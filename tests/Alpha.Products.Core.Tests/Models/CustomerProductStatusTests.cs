namespace Alpha.Products.Core.Tests.Models
{
    using Alpha.Products.Core.Models;
    using Xunit;

    [Trait("Core", "Models/ConfigFileReader")]
    public class CustomerProductStatusTests
    {
        [Fact]
        public void CanBeSeen_StatusIsNotSynced_ReturnFalse()
        {
            var customerProductStatus = new CustomerProductStatus(1, false, hidden: true);

            Assert.False(customerProductStatus.CanBeSeen);
        }

        [Fact]
        public void CanBeSeen_StatusIsHidden_ReturnFalse()
        {
            var customerProductStatus = new CustomerProductStatus(1, false, hidden: true);

            Assert.False(customerProductStatus.CanBeSeen);
        }

        [Fact]
        public void Enabled_StatusIsDisabled_ReturnFalse()
        {
            var customerProductStatus = new CustomerProductStatus(1, disabled: true, hidden: false);

            Assert.False(customerProductStatus.Enabled);
        }
    }
}