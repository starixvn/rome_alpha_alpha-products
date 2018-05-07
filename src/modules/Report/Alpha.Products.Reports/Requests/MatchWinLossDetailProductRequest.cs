namespace Alpha.Products.Reports.Requests
{
    using Alpha.Products.Core.Models;

    public class MatchWinLossDetailProductRequest : ReportProductRequest
    {
        public MatchWinLossDetailProductRequest(ICustomer actor)
            : base(actor, null)
        {
            Predicate = (config) => ((ReportProperties)config.ExtendProductProperty).HasMatchInfo;
        }
    }
}