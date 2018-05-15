namespace Alpha.Products.Reports
{
    using Alpha.Products.Core.Configuration;

    public class ReportProperties : IExtendProductProperty
    {
        public ReportProperties(
            bool showInLegend = false,
            bool hasMatchInfo = false,
            bool offerPlayForFun = false)
        {
            ShowInLegend = showInLegend;
            HasMatchInfo = hasMatchInfo;
            OfferPlayForFun = offerPlayForFun;
        }

        public bool ShowInLegend { get; }

        public bool HasMatchInfo { get; }

        public bool OfferPlayForFun { get; }
    }
}