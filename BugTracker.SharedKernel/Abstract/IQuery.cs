namespace BugTracker.SharedKernel.Abstract
{
	using LanguageExt.Common;
	using MediatR;

	public interface IQuery<out T> : IRequest<T>
	{
	}
}