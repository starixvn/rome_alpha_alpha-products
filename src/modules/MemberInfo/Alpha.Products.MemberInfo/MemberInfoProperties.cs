namespace Alpha.Products.MemberInfo
{
    using Core.Configuration;

    public class MemberInfoProperties : IExtendProductProperty
    {
        public MemberInfoProperties(bool reviewSetting)
        {
            ReviewSetting = reviewSetting;
        }

        public bool ReviewSetting { get; }
    }
}
