using Cart.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CartController : ControllerBase
	{
		private ICartRepository cartRepository;
		public CartController(ICartRepository repository)
		{
			cartRepository = repository;
		}
		[HttpGet("{id}")]
		public IActionResult Get(string id)
		{
			var p = cartRepository.GetCartAsync(id);
			return Ok();
		}

		[HttpPut]
		[HttpPut("{data}")]
		public async Task<IActionResult> Put(object? data)
		{
			string cartId = await cartRepository.SaveToCartAsync(null, data);

			return Ok();
		}
	}
}
