using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.Products.Core.Models
{
    public interface IRule<T>
    {
        bool IsValid(T t);
    }
}
