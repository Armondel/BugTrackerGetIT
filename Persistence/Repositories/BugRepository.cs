namespace BugTrackerGetIT.Persistence.Repositories
{
    using BugTrackerGetIT.Core.Bug;
    using BugTrackerGetIT.Core.Bug.Contracts;
    using BugTrackerGetIT.Persistence.Base;
    using BugTrackerGetIT.Persistence.DbConfiguration;

    public class BugRepository : BaseRepository<Bug>, IBugRepository
    {
        public BugRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}