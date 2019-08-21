using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BugTrackerGetIT.Core.Bug;
using BugTrackerGetIT.WebApp.Models;

namespace BugTrackerGetIT.WebApp.DTO
{
    public class BugHistoryDto
    {
	    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	    [Key]
	    public string Id { get; set; }

	    [Required]
	    public string BugId { get; set; }

	    public DateTime DateChanged { get; set; }

	    public string Description { get; set; }

	    public UserDto User { get; set; }

	    public string UserId { get; set; }

	    public Status Status { get; set; }

	    public byte StatusId { get; set; }

	}
}
