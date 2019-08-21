using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BugTrackerGetIT.WebApp.Models;

namespace BugTrackerGetIT.WebApp.DTO
{
    public class BugDto
    {

	    public string Id { get; set; }

	    public DateTime DateCreated { get; set; }

	    public string Preview { get; set; }

	    public string UserUserName { get; set; }

	    public string StatusName { get; set; }

	    public string PriorityName { get; set; }

	    public string CriticalityName { get; set; }


	}
}
