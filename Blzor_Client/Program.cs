using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static clientnamespace.ProductsService;
using Blzor_Client.Services;
namespace Blzor_Client
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");

			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


			builder.Services.AddSingleton(services =>
			{
				// Create a gRPC-Web channel pointing to the backend server
				var httpClient = new HttpClient(new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler()));
				//var baseUri = services.GetRequiredService<NavigationManager>().BaseUri;
				var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions { HttpClient = httpClient });

				// Now we can instantiate gRPC clients for this channel
				return new ProductsServiceClient(channel);
			});

			builder.Services.AddSingleton<ProductsOpsService>();

			await builder.Build().RunAsync();
		}
	}
}
