namespace BugTrackerGetIT.Core.Bug.Contracts
{
    using BugTrackerGetIT.Core.Bug.Command;
    using CSharpFunctionalExtensions;
    using MediatR;

    public interface IBugService : IRequestHandler<CreateBug, Result<Bug>>
    {
    }
}