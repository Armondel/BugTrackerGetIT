namespace BugTracker.API
{
	using System;
	using System.IO;
	using System.Linq;
	using System.Reflection;
	using BugTracker.API.Configuration;
	using BugTracker.Persistence;
	using MediatR;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Hosting;

	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			var assemblies =
				Directory.EnumerateFiles(
							AppDomain.CurrentDomain.BaseDirectory,
							"*.dll",
							SearchOption.TopDirectoryOnly)
						.Where(filePath => Path.GetFileName(filePath).StartsWith("BugTracker"))
						.Select(Assembly.LoadFrom)
						.ToArray();

			PersistenceConfiguration.Configure(services, Configuration);
			AuthenticationConfiguration.Configure(services, Configuration);
			IdentityConfiguration.Configure(services);
			SwaggerConfiguration.Configure(services);
			services.AddMediatR(assemblies);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseCors(x => x
							.AllowAnyOrigin()
							.AllowAnyMethod()
							.AllowAnyHeader());

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseDefaultFiles();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

			UpdateDatabase(app);
		}

		private static void UpdateDatabase(IApplicationBuilder app)
		{
			using var serviceScope = app.ApplicationServices
										.GetRequiredService<IServiceScopeFactory>()
										.CreateScope();
			using var context = serviceScope.ServiceProvider.GetService<DatabaseContext>();
			context.Database.Migrate();
		}
	}
}