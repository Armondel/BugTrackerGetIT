namespace BugTracker.SharedKernel.Abstract
{
	using LanguageExt.Common;
	using MediatR;

	public interface ICommand<out T> : IRequest<T>
	{
	}

	public interface ICommand : IRequest<Unit>
	{
	}
}