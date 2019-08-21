using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTrackerGetIT.WebApp.Models;

namespace BugTrackerGetIT.WebApp.DTO
{
    public class UserDto
    {
	    public string Id { get; set; }

		public string UserName { get; set; }

	    public string FirstName { get; set; }

	    public string LastName { get; set; }
    }
}
