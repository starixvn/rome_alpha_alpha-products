namespace Alpha.Products.Core.Integration
{
    using System;

    public interface IDateTimeWrapper
    {
        DateTime Now { get; }
    }

    public class DateTimeWrapper : IDateTimeWrapper
    {
        public DateTime Now => DateTime.Now;
    }
}