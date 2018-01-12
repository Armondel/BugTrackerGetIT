using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BugTrackerGetIT.Models;

namespace BugTrackerGetIT.DTO
{
    public class BugDto
    {

		[Key]
	    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	    public string Id { get; set; }

	    [DataType(DataType.DateTime)]
	    [DisplayFormat(DataFormatString = "{0:HH:mm dd:MM:yyyy}")]
	    [Required]
	    public DateTime DateCreated { get; set; }

	    [MaxLength(50)]
	    public string Preview { get; set; }
	    public string Description { get; set; }


	    public UserDto User { get; set; }

		[NotMapped]
	    [Required]
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

	}
}
