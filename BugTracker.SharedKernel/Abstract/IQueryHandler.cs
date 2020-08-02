namespace BugTracker.SharedKernel.Abstract
{
	using LanguageExt.Common;
	using MediatR;

	public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
		where TQuery : IQuery<TResult>
	{
	}
}