namespace BugTrackerGetIT.Core.Abstraction
{
    using MediatR;

    public interface IQuery<T> : IRequest<T>
    {
    }
}