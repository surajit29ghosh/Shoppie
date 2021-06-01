using Dapr.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.API.Repository
{
	public class CartRepository: ICartRepository
	{
		public readonly string storename = "statestore";
		private DaprClient daprClient;

		public CartRepository(DaprClient client)
		{
			daprClient = client;
		}

		public async Task<object> GetCartAsync(string cartId)
		{
			return await daprClient.GetStateAsync<object>(storename, cartId);
		}

		public async Task<string> SaveToCartAsync(string? cartId, object entry)
		{
			string newId = string.Empty;
			object o;

			if (string.IsNullOrWhiteSpace(cartId))
			{
				newId = Guid.NewGuid().ToString();
				o = new object();
			}
			else
			{
				newId = cartId;
				o = this.GetCartAsync(newId);

			}

			await daprClient.TrySaveStateAsync(storename, newId, o, "");

			return newId;
		}
	}
}
