using Product.API.Domain;
using Product.API.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Application
{
	public class ProductApplication : IProductApplication
	{
		private ProductContext context;
		public ProductApplication(ProductContext db)
		{
			context = db;
		}
		public IEnumerable<ProductModel> GetAllProducts()
		{
			var model = context.Products.ToList();

			return ReturnModel(model);
		}

		public IEnumerable<ProductModel> SearchProducts(string query)
		{
			var model = context.Products.Where(p => p.ProductName.Contains(query)).ToList();

			return ReturnModel(model);
		}

		private IEnumerable<ProductModel> ReturnModel(List<Product.API.Models.Product> products)
		{
			List<ProductModel> model = products.Select(c => new ProductModel
			{
				Id = c.Id,
				Description = c.Description,
				ProductName = c.ProductName,
				InStock = c.InStock,
				Price = c.Price
			}).ToList();

			return model;
		}
	}
}
