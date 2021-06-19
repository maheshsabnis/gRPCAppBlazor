using clientnamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static clientnamespace.ProductsService;

namespace Blzor_Client.Services
{
	public class ProductsOpsService
	{
		private readonly ProductsServiceClient client;
		public ProductsOpsService(ProductsServiceClient client)
		{
			this.client = client;
		}
		public async Task<Products> GetProductsAsync()
		{
			var products = await client.GetAllAsync(new Empty());
			return products;
		}


		public async Task<Product> GetProductByIdAsync(int id)
		{
			var product = await client.GetByIdAsync(new ProductRowIdFilter() { ProductRowId= id});
			return product;
		}

		public async Task<Product> CreateProductAsync(Product product)
		{
			product = await client.PostAsync(product);
			return product;
		}

		public async Task<Product> UpdateProductAsync(Product product)
		{
			product = await client.PutAsync(product);
			return product;
		}

		public async Task<Empty> DeleteProductAsync(int id)
		{
			var result  = await client.DeleteAsync(new ProductRowIdFilter() { ProductRowId= id});
			return result;
		}

	}
}
