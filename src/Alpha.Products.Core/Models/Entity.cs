namespace Alpha.Products.Core.Models
{
    using System;

    public class Entity
    {
        protected Entity(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            Id = id;
        }

        public int Id { get; }
    }
}