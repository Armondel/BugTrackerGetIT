namespace BugTrackerGetIT.Core.Bug
{
    using System;
    using BugTrackerGetIT.Core.Abstraction;
    using BugTrackerGetIT.Core.User;

    public class Bug : DomainModel
    {
        private readonly Guid key;
        private readonly DateTimeOffset dateCreated;
        private string preview;
        private string description;
        private int userId;
        private Status status;
        private Priority priority;
        private Criticality criticality;

        protected Bug() : base()
        {
            dateCreated = DateTimeOffset.Now;
            key = new Guid();
        }   

        public Bug(int userId) : base()
        {
            this.userId = userId;
            this.status = Status.NEW;
        }

        public User User { get; }

        public Guid Key => key;

        public DateTimeOffset DateCreated => dateCreated;

        public int UserId => userId;

        public Status Status => status;

        public string Preview { get => preview; set => preview = value; }

        public string Description { get => description; set => description = value; }

        public Priority Priority { get => priority; set => priority = value; }

        public Criticality Criticality { get => criticality; set => criticality = value; }

        public bool SetOpen(out string comment)
        {
            switch(status)
            {
                case Status.NEW:
                case Status.RESOLVED:
                    status = Status.OPEN;
                    comment = String.Empty;
                    return true;
                default:
                    comment = "Closed bug cannot be opened";
                    return false;
            }
        }

        public bool SetResolve(out string comment)
        {
            switch(status)
            {
                case Status.OPEN:
                    status = Status.RESOLVED;
                    comment = String.Empty;
                    return true;
                default:
                    comment = "Only opened bugs can be resolved";
                    return false;
            }
        }

        public bool SetClosed(out string comment)
        {
            switch(status)
            {
                case Status.RESOLVED:
                    status = Status.CLOSED;
                    comment = String.Empty;
                    return true;
                default:
                    comment = "Only resolved bugs can be resolved";
                    return false;
            }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}