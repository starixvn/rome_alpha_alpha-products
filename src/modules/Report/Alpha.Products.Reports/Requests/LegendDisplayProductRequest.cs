namespace Alpha.Products.Reports.Requests
{
    using Alpha.Products.Core.Models;

    public class LegendDisplayProductRequest : ReportProductRequest
    {
        public LegendDisplayProductRequest(ICustomer actor)
            : base(actor, null)
        {
#pragma warning disable S3215 // "interface" instances should not be cast to concrete types
            Predicate = (config) => ((ReportProperties)config.ExtendProductProperty).ShowInLegend;
#pragma warning restore S3215 // "interface" instances should not be cast to concrete types
        }
    }
}