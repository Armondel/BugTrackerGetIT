namespace BugTrackerGetIT.Persistence.Repositories
{
    using BugTrackerGetIT.Core.Bug;
    using BugTrackerGetIT.Core.Bug.Contracts;
    using BugTrackerGetIT.Persistence.Base;

    public class BugRepository : BaseRepository<Bug>, IBugRepository
    {
        public BugRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}