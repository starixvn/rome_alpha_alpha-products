namespace Alpha.Products.AccountInfo.Setting.ViewModels.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Alpha.Products.AccountInfo.Requests;
    using Alpha.Products.Core.Models;

    public abstract class SettingItemViewModel : ISettingItemViewModel
    {
        protected readonly ISearchAccountInfoRequest Request;

        protected SettingItemViewModel(
            ISearchAccountInfoRequest request,
            int displayOrder = 0)
        {
            Request = request ?? throw new ArgumentNullException(nameof(request));
            DisplayOrder = displayOrder;
        }

        protected ICustomer Actor => Request.Actor;

        protected ICustomer SearchAccount => Request.SearchAccount;

        public virtual string Text => Request.GetResource($"{GetType().Name}Text");

        public int DisplayOrder { get; }

        public virtual string Url
        {
            get
            {
                var queryString =
                     string.Join("&", QueryStringParamaters.Select(query => $"{query.Key}={query.Value}"));

                return $"{BaseAddress}?{queryString}";
            }
        }

        protected abstract string BaseAddress { get; }

        protected abstract Dictionary<string, string> QueryStringParamaters { get; }

        public virtual bool Visible => Request.ActorIsEdittingDirectDownline;

        public override string ToString()
        {
            var properties = GetType().GetProperties().ToList();
            var lastPropertyInfo = properties.Last();

            var builder = new StringBuilder();

            builder.AppendLine("{");
            foreach (var propertyInfo in properties)
            {
                builder
                    .Append(" \"")
                    .Append(propertyInfo.Name)
                    .Append("\": \"")
                    .Append(propertyInfo.GetValue(this))
                    .Append("\"")
                    .AppendLine((propertyInfo != lastPropertyInfo) ? "," : string.Empty);
            }

            builder.AppendLine("}");

            return builder.ToString();
        }
    }
}