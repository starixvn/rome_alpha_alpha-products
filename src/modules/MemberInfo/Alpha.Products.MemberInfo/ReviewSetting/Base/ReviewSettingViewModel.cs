namespace Alpha.Products.MemberInfo.ReviewSetting.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Models;
    using Requests;

    public abstract class ReviewSettingViewModel : IReviewSettingViewModel
    {
        protected readonly IReviewSettingRequest Request;

        protected ReviewSettingViewModel(
            IReviewSettingRequest request,
            int displayOrder = 0)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Request = request;
            DisplayOrder = displayOrder;
        }

        protected ICustomer Actor => Request.Actor;

        protected ICustomer ReviewedCustomer => Request.ReviewedCustomer;

        public virtual string Text => Request.GetResource($"{GetType().Name}Text");

        public int DisplayOrder { get; }

        protected abstract string BaseAddress { get; }

        protected abstract Dictionary<string, string> QueryStringParamaters { get; }

        public virtual string Url
        {
            get
            {
                var queryString =
                     string.Join("&", QueryStringParamaters.Select(query => $"{query.Key}={query.Value}"));

                return $"{BaseAddress}?{queryString}";
            }
        }

        public virtual bool Visible => true;
    }
}
