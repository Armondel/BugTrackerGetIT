namespace BugTracker.API.Configuration
{
	using BugTracker.SharedKernel.Abstract;
	using Lamar;
	using LanguageExt;

	public static class IoCContainerConfiguration
	{
		public static ServiceRegistry CreateServiceRegistry()
		{
			var services = new ServiceRegistry();
			services.Scan(scan =>
			{
				scan.TheCallingAssembly();
				scan.ConnectImplementationsToTypesClosing(typeof(IQueryHandler<,>));
				scan.ConnectImplementationsToTypesClosing(typeof(ICommandHandler<>));
				scan.ConnectImplementationsToTypesClosing(typeof(ICommandHandler<,>));
				scan.RegisterConcreteTypesAgainstTheFirstInterface();
			});

			return services;
		}
	}
}