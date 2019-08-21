using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BugTrackerGetIT.Core.Bug;

namespace BugTrackerGetIT.WebApp.DTO
{
    public class DetailedBugDto
    {
	    public string Id { get; set; }

	    public DateTime DateCreated { get; set; }

		[Required]
		[StringLength(50)]
	    public string Preview { get; set; }
		[Required]
		[StringLength(250)]
	    public string Description { get; set; }

	    public UserDto User { get; set; }
	    public string UserId { get; set; }

	    public Status Status { get; set; }
		[Required]
	    public byte StatusId { get; set; }

	    public Priority Priority { get; set; }
		[Required]
	    public byte PriorityId { get; set; }

	    public Criticality Criticality { get; set; }
		[Required]
	    public byte CriticalityId { get; set; }

		[Required]
		[StringLength(100)]
	    public string Comment { get; set; }
	}
}
