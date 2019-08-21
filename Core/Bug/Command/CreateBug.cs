namespace BugTrackerGetIT.Core.Bug.Command
{
    using BugTrackerGetIT.Core.Abstraction;

    public class CreateBug : ICommand<Bug>
    {
        public int UserId { get; set; }

        public string Preview { get; set; }
        public string Description { get; set; }

        public Priority Priority{ get; set; }
        public Criticality Criticality { get; set; }
    }
}