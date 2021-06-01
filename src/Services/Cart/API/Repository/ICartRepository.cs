using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.API.Repository
{
	public interface ICartRepository
	{
		Task<object> GetCartAsync(string cartId);
		Task<string> SaveToCartAsync(string? cartId, object entry);
	}
}
