using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackerGetIT.DTO
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

	    public StatusDto Status { get; set; }
		[Required]
	    public byte StatusId { get; set; }

	    public PriorityDto Priority { get; set; }
		[Required]
	    public byte PriorityId { get; set; }

	    public CriticalityDto Criticality { get; set; }
		[Required]
	    public byte CriticalityId { get; set; }

		[Required]
		[StringLength(100)]
	    public string Comment { get; set; }
	}
}
