namespace Alpha.Products.Reports.Requests
{
    using Alpha.Products.Core.Models;

    public class PlayForFunProductRequest : ReportProductRequest
    {
        public PlayForFunProductRequest(ICustomer actor)
            : base(actor, null)
        {
#pragma warning disable S3215 // "interface" instances should not be cast to concrete types
            Predicate = (config) => ((ReportProperties)config.ExtendProductProperty).OfferPlayForFun;
#pragma warning restore S3215 // "interface" instances should not be cast to concrete types
        }
    }
}