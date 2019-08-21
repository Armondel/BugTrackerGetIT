namespace BugTrackerGetIT.Core.Abstraction
{
    using CSharpFunctionalExtensions;
    using MediatR;

    public interface ICommand<T> : IRequest<Result<T>>
    {
    }
}