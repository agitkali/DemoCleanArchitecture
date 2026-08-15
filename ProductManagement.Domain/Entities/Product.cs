using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Domain.Entities
{
    public class Product
    {

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public void ValidateBusinessRules()
        {
            if (Price <= 0)
                throw new InvalidOperationException(
                    "Product price must be greater than zero.");

            if (Stock < 0)
                throw new InvalidOperationException(
                    "Stock cannot be negative.");
        }
    }
}
