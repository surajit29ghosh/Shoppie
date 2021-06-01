using System;
using System.Collections.Generic;

#nullable disable

namespace Product.API.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int InStock { get; set; }
    }
}
