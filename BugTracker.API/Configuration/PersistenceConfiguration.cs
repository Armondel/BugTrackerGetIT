namespace BugTracker.API.Configuration
{
	using BugTracker.Persistence;
	using LanguageExt;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Npgsql;

	public static class PersistenceConfiguration
	{
		public static Unit Configure(IServiceCollection services, IConfiguration configuration)
		{
			var connectionSettings = configuration.GetSection("Connections").GetSection("Default");
			var connectionString = new NpgsqlConnectionStringBuilder
			{
				Host = connectionSettings.GetValue<string>("Host"),
				Username = connectionSettings.GetValue<string>("Username"),
				Password = connectionSettings.GetValue<string>("Password"),
				Port = connectionSettings.GetValue<int>("Port"),
				Database = connectionSettings.GetValue<string>("Database")
			};
			services.AddDbContext<IdentityContext>(builder =>
				builder.UseNpgsql(connectionString.ConnectionString));

			return Unit.Default;
		}
	}
}