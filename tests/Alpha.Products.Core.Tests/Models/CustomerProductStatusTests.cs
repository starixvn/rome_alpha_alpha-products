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
            var customerProductStatus = new CustomerProductStatus(1, false, hidden: true, synced: false);

            Assert.False(customerProductStatus.CanBeSeen);
        }

        [Fact]
        public void CanBeSeen_StatusIsHidden_ReturnFalse()
        {
            var customerProductStatus = new CustomerProductStatus(1, false, hidden: true, synced: true);

            Assert.False(customerProductStatus.CanBeSeen);
        }

        [Fact]
        public void Enabled_StatusIsDisabled_ReturnFalse()
        {
            var customerProductStatus = new CustomerProductStatus(1, disabled: true, hidden: false, synced: true);

            Assert.False(customerProductStatus.Enabled);
        }
    }
}