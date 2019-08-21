namespace BugTrackerGetIT.Core.Bug
{
    using System;
    using User;
    
    public class Bug
    {
        public int Id { get; }

        public Guid Key { get; }
        
        public DateTimeOffset DateCreated { get; }

        public string Preview { get; set; }

        public string Description { get; set; }
        
        public int UserId { get; set; }

        public User User{ get; set; }

        public Status Status { get; set; }

        public Priority Priority { get; set; }

		public Criticality Criticality { get; set; }

        protected Bug()
        {
            // Constructor for EF
        }
    }
}