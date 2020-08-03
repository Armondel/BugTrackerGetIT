namespace BugTracker.API
{
	using BugTracker.API.Configuration;
	using HybridModelBinding;
	using Lamar.Microsoft.DependencyInjection;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Hosting;

	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args)
		{
			var registry = IoCContainerConfiguration.CreateServiceRegistry();

			return Host.CreateDefaultBuilder(args)
						.ConfigureWebHostDefaults(webBuilder =>
						{
							webBuilder.UseLamar(registry);
							webBuilder.UseKestrel();
							webBuilder.UseStartup<Startup>();
							webBuilder.ConfigureServices(services =>
							{
								// This is important, the call to AddControllers()
								// cannot be made before the usage of ConfigureWebHostDefaults
								services.AddControllers().AddHybridModelBinder(options =>
								{
									options.FallbackBindingOrder = new[] { Source.Body, Source.QueryString, Source.Route };
								});
							});
							webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
							{
								var env = hostingContext.HostingEnvironment;
								config
									.AddJsonFile(
										$"appsettings.{env.EnvironmentName}.json", false,
										true);
								config.AddEnvironmentVariables();
							});
						});
		}
	}
}