using System.Net;
using BugTrackerGetIT.Core.Abstraction;

namespace BugTrackerGetIT.Core.Base
{
    public class BaseException : DomainException
    {
        public BaseException(string message)
        {
            this.message = message;
            this.responseCode = HttpStatusCode.BadRequest;
        }

        public HttpStatusCode GetStatusCode() => this.responseCode;
    }
}