namespace BugTracker.API.Configuration
{
	using BugTracker.SharedKernel.Abstract;
	using Lamar;

	public static class IoCContainerConfiguration
	{
		public static ServiceRegistry CreateServiceRegistry()
		{
			var registry = new ServiceRegistry();
			registry.Scan(scan =>
			{
				scan.TheCallingAssembly();
				scan.ConnectImplementationsToTypesClosing(typeof(IQueryHandler<,>));
				scan.ConnectImplementationsToTypesClosing(typeof(ICommandHandler<>));
				scan.ConnectImplementationsToTypesClosing(typeof(ICommandHandler<,>));
				scan.RegisterConcreteTypesAgainstTheFirstInterface();
			});

			return registry;
		}
	}
}