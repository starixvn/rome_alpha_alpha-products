namespace Alpha.Products.Reports.Requests
{
    using Alpha.Products.Core.Models;

    public class PlayForFunProductRequest : ReportProductRequest
    {
        public PlayForFunProductRequest(ICustomer actor)
            : base(actor, null)
        {
            Predicate = (config) => ((ReportProperties)config.ExtendProductProperty).OfferPlayForFun;
        }
    }
}