using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Domain
{
    public sealed record Coffee : ProductItem
    {
        private short _strength;

        public CoffeeType CoffeeType { get; set; }

        public string Origin { get; set; }

        public string Description { get; set; }

        public DateTime ExpirationDate { get; set; }

        public short Strength
        {
            get => _strength;

            set
            {
                if (value <= 0) _strength = 1;
                else if (value > 10) _strength = 10;
                else _strength = value;
            }
        }
    }
}
