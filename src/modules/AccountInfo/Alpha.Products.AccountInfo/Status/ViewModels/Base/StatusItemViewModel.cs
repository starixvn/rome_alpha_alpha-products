namespace Alpha.Products.AccountInfo.Status.ViewModels.Base
{
    using System;
    using System.Linq;
    using System.Text;
    using Alpha.Products.AccountInfo.Requests;
    using Alpha.Products.Core.Models;

    public abstract class StatusItemViewModel : IStatusItemViewModel
    {
        protected readonly ISearchAccountInfoRequest Request;

        protected StatusItemViewModel(ISearchAccountInfoRequest request, int displayOrder = 0)
        {
            Request = request ?? throw new ArgumentNullException(nameof(request));
#pragma warning disable RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            DisplayOrder = displayOrder;
#pragma warning restore RECS0021 // Warns about calls to virtual member functions occuring in the constructor
        }

        protected ICustomer Actor => Request.Actor;

        protected ICustomer SearchAccount => Request.SearchAccount;

        public virtual string Text => Request.GetResource($"{GetType().Name}.Text");

        public abstract string Url { get; }

        public virtual int DisplayOrder { get; }

        public virtual bool Visible => true;

        public virtual bool Disabled => !Request.GetData<bool>("Actor.HasUpdateAccountPermission");

        public abstract bool Checked { get; }

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