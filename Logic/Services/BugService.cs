namespace Logic.Services
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using BugTrackerGetIT.Core.Bug;
    using BugTrackerGetIT.Core.Bug.Contracts;
    using BugTrackerGetIT.Core.Bug.Command;
    using CSharpFunctionalExtensions;

    public class BugService : IBugService
    {
        private readonly IBugRepository bugRepository;

        public BugService(IBugRepository bugRepository)
        {
            this.bugRepository = bugRepository;
        }

        public async Task<Result<Bug>> Handle(CreateBug request, CancellationToken cancellationToken)
        {
            var bug = new Bug(request.UserId);
            bug.Preview = request.Preview;
            bug.Description = request.Description;
            bug.Priority = request.Priority;
            bug.Criticality = request.Criticality;

            bugRepository.Insert(bug);

            var result = await bugRepository.SaveChangesAsync();
            
            return result.IsSuccess ? Result.Ok(bug) : Result.Fail<Bug>(result.Error);
        }
    }
}
