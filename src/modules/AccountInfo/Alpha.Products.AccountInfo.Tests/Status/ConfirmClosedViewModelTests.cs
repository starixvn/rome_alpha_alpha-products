namespace Alpha.Products.AccountInfo.Tests.ViewModels
{
    using System;
    using Status.ViewModels;
    using Utility;
    using Xunit;

    [Trait("Status.ViewModels", "ConfirmClosedViewModel")]
    public class ConfirmClosedViewModelTests
    {
        private const string BaseAddress = "_AccountInfo/Handlers/UpdateClosedStatus.ashx";

        [Fact]
        public void Url_Start_With_BaseAddress()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            var viewModel = new ConfirmClosedViewModel(request);

            Assert.True(viewModel.Url.StartsWith(BaseAddress, StringComparison.OrdinalIgnoreCase) == true);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(false, false)]
        public void Return_Checked_By_SearchAccount_IsClosed(bool isClosed, bool expectedValue)
        {
            var request = RequestHelper.CreateRequest(4, 3);
            request.AddData("SearchAccount.IsClosed", isClosed);

            var viewModel = new ConfirmClosedViewModel(request);

            Assert.Equal(expectedValue, viewModel.Checked);
        }

        [Fact]
        public void Disabled_Is_True_When_Actor_Does_Not_HasUpdateAccountPermission()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            request.AddData("Actor.HasUpdateAccountPermission", false);

            var viewModel = new ConfirmClosedViewModel(request);

            Assert.True(viewModel.Disabled);
        }

        [Fact]
        public void Disabled_Is_True_When_Upline_Is_Closed()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            request.AddData("Actor.HasUpdateAccountPermission", true);
            request.AddData("SearchAccount.Upline.IsClosed", true);

            var viewModel = new ConfirmClosedViewModel(request);

            Assert.True(viewModel.Disabled);
        }

        [Fact]
        public void Disabled_Is_False_When_Actor_HasUpdateAccountPermission_And_Upline_Doesnt_Close()
        {
            var request = RequestHelper.CreateRequest(4, 3);
            request.AddData("Actor.HasUpdateAccountPermission", true);
            request.AddData("SearchAccount.Upline.IsClosed", false);

            var viewModel = new ConfirmClosedViewModel(request);

            Assert.False(viewModel.Disabled);
        }
    }
}