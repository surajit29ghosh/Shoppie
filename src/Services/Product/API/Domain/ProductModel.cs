using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Domain
{
	public class ProductModel
	{
            public int Id { get; set; }
            public string ProductName { get; set; }
            public string Description { get; set; }
            public decimal? Price { get; set; }
            public int InStock { get; set; }
    }
}
