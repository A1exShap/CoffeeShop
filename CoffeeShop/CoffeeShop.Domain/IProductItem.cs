using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Domain
{
    public interface IProductItem
    {
        Guid Id { get; }

        ProductType ProductType { get; }

        string Name { get; }

        decimal VendorPrice { get; }

        decimal SellingPrice { get; }

    }
}
