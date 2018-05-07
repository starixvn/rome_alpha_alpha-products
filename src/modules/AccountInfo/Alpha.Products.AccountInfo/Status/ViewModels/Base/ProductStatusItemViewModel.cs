namespace Alpha.Products.AccountInfo.Status.ViewModels.Base
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Alpha.Products.AccountInfo.Requests;
    using static Alpha.Products.Core.Shared.ProductConstants;

    public class ProductStatusItemViewModel : StatusItemViewModel
    {
        private readonly IReadOnlyCollection<int> ProductsHaveStatusOnSportOrBetTypeLevel
            = new ReadOnlyCollection<int>(new List<int> { Keno, AllBet });

        private readonly int ProductId;

        public ProductStatusItemViewModel(ISearchAccountInfoRequest request, int productId)
            : base(request)
        {
            ProductId = productId;
        }

        public override string Text => Request.GetProductName(ProductId);

        public override int DisplayOrder => ProductId * 10;

        public override string Url
            => "productstatus3rd/index?" + string.Join("&",
                                          $"productid={ProductId}",
                                          $"custId={SearchAccount.Id}",
                                          $"custName={SearchAccount.Username}",
                                          $"custRoleId={SearchAccount.CusomerLevelValue}",
                                          $"uid={Guid.NewGuid()}");

        public override bool Disabled
            => base.Disabled
            || Actor.IsNotDirectUplineOf(SearchAccount)
            || SearchAccount.Upline.ProductStatusOf(ProductId).Disabled;

        public override bool Visible
            => Actor.IsDirectUplineOf(SearchAccount)
            && SearchAccount.CanSeeProduct(ProductId);

        public bool IsEditOnProductLevel
            => ProductsHaveStatusOnSportOrBetTypeLevel.Contains(ProductId);

        public override bool Checked => SearchAccount.ProductStatusOf(ProductId).Enabled;
    }
}