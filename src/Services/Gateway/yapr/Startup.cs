using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Yarp.ReverseProxy.Abstractions;
using Yarp.ReverseProxy.Middleware;
using Yarp.ReverseProxy.RuntimeModel;
using Yarp.ReverseProxy.Service.Proxy;

namespace APIGateway
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddHttpProxy();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHttpProxy httpProxy)
		{
			string hostName = Environment.GetEnvironmentVariable("HostName");
			string productApiPort = Environment.GetEnvironmentVariable("ProductApiPort");
			string cartApiPort = Environment.GetEnvironmentVariable("CartApiPort");

			var httpClient = new HttpMessageInvoker(new SocketsHttpHandler()
			{
				UseProxy = false,
				AllowAutoRedirect = false,
				AutomaticDecompression = DecompressionMethods.None,
				UseCookies = false
			});
			var transformer = new CustomTransformer(); // or HttpTransformer.Default;
			var requestOptions = new RequestProxyOptions { Timeout = TimeSpan.FromSeconds(100) };

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.Map("/api/product/{**catch-all}", async httpContext =>
				{
					await httpProxy.ProxyAsync(httpContext, hostName + ":" + productApiPort + "/", httpClient,
						requestOptions, transformer);

					//var errorFeature = httpContext.GetProxyErrorFeature();
					//if (errorFeature != null)
					//{
					//	var error = errorFeature.Error;
					//	var exception = errorFeature.Exception;
					//}
				});
				endpoints.Map("/api/cart/{**catch-all}", async httpContext =>
				{
					await httpProxy.ProxyAsync(httpContext, hostName + ":" + cartApiPort + "/", httpClient,
						requestOptions, transformer);

					//var errorFeature = httpContext.GetProxyErrorFeature();
					//if (errorFeature != null)
					//{
					//	var error = errorFeature.Error;
					//	var exception = errorFeature.Exception;
					//}
				});
			});
		}

		private class CustomTransformer : HttpTransformer
		{
			public override async Task TransformRequestAsync(HttpContext httpContext,
				HttpRequestMessage proxyRequest, string destinationPrefix)
			{
				// Copy headers normally and then remove the original host.
				// Use the destination host from proxyRequest.RequestUri instead.
				await base.TransformRequestAsync(httpContext, proxyRequest, destinationPrefix);
				proxyRequest.Headers.Host = null;
			}
		}
	}
}
