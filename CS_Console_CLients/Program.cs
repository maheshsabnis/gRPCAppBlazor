using Grpc.Net.Client;
using System;
using clientnamespace;
using static clientnamespace.ProductsService;
using System.Text.Json;
namespace CS_Console_CLients
{
	class Program
	{

		static void Main(string[] args)
		{
			Console.WriteLine("Press any key ");
			Console.ReadLine();

			var channel = GrpcChannel.ForAddress("https://localhost:5001");

			var client = new ProductsServiceClient(channel);

			GetAll(client);
			Insert(client);
			Console.WriteLine();
			GetAll(client);
			Console.ReadLine();

		}

		static void GetAll(ProductsServiceClient client)
		{
			var products = client.GetAll(new Empty());

			foreach (var item in products.Items)
			{
				Console.WriteLine($"{item.ProductRowId} {item.ProductId} {item.ProductName} {item.CategoryName} {item.Manufacturer} {item.Price}");
			}
		}

		static void Insert(ProductsServiceClient client)
		{
			var product = client.Post(new Product() { ProductId="Prd-004",ProductName="Iron",CategoryName="Electrical", Manufacturer="MS-ECT", Price=3400 });

			Console.WriteLine($"Record Added {JsonSerializer.Serialize(product)}");
		}
	}
}
