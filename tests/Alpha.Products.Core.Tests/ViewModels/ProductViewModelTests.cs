namespace Alpha.Products.Core.Tests.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Alpha.Products.Core.ViewModels;
    using Xunit;

    [Trait("Core", "ViewModels/ProductViewModel")]
    public class ProductViewModelTests
    {
        [Fact]
        public void Ctor_Always_ReturnNewProductViewModel()
        {
            var viewModel = new ProductViewModel(1, "Name 1");

            Assert.True(viewModel.Name == "Name 1"
                && viewModel.DisplayOrder == 1
                && viewModel.Visible
                && viewModel.ToString() == "{Id:1, Name:Name 1}");
        }
    }
}
