using Product.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Application
{
	public interface IProductApplication
	{
		IEnumerable<ProductModel> GetAllProducts();
		IEnumerable<ProductModel> SearchProducts(string query);
	}
}
