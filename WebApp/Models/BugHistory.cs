using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BugTrackerGetIT.Core.Bug;

namespace BugTrackerGetIT.WebApp.Models
{
    public class BugHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }

        public Bug Bug { get; set; }

        [Required]
        public string BugId { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:HH:mm dd:MM:yyyy}")]
        [Required]
        public DateTime DateChanged { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1)]
        public string Description { get; set; }

	    public Status Status { get; set; }

		[Required]
	    public byte StatusId { get; set; }

        public ApplicationUser User { get; set; }
        [Required]
        public string UserId { get; set; }



    }
}