namespace Alpha.Products.Reports.Requests
{
    using Alpha.Products.Core.Models;

    public class MatchWinLossDetailProductRequest : ReportProductRequest
    {
        public MatchWinLossDetailProductRequest(ICustomer actor)
            : base(actor, null)
        {
#pragma warning disable S3215 // "interface" instances should not be cast to concrete types
            Predicate = (config) => ((ReportProperties)config.ExtendProductProperty).HasMatchInfo;
#pragma warning restore S3215 // "interface" instances should not be cast to concrete types
        }
    }
}