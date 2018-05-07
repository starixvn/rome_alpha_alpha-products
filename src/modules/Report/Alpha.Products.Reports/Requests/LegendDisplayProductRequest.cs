namespace Alpha.Products.Reports.Requests
{
    using Alpha.Products.Core.Models;

    public class LegendDisplayProductRequest : ReportProductRequest
    {
        public LegendDisplayProductRequest(ICustomer actor)
            : base(actor, null)
        {
            Predicate = (config) => ((ReportProperties)config.ExtendProductProperty).ShowInLegend;
        }
    }
}