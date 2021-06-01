using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.API.Application;
using Product.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private IProductApplication productApp;
		public ProductController(IProductApplication product)
		{
			this.productApp = product;
		}

		[Route("all")]
		[HttpGet]
		public IEnumerable<ProductModel> GetAll()
		{
			return productApp.GetAllProducts();
		}

		[Route("search/{name}")]
		[HttpGet]
		public IEnumerable<ProductModel> Search(string name)
		{
			return productApp.SearchProducts(name);
		}

	}
}
