using System;
using System.Net;

namespace BugTrackerGetIT.Core.Abstraction
{
    public abstract class DomainException : Exception
    {
        protected HttpStatusCode responseCode;

        public string message;
    }
}