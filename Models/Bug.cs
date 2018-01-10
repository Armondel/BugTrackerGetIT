using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTrackerGetIT.Models
{
    public class Bug
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
        
        
        public ApplicationUser User { get; set; }

        [Required]
        public string UserId { get; set; }

        public Status Status { get; set; }

        [Required]
        public byte StatusId  { get; set; }

        public Priority Priority { get; set; }
        [Required]
        public byte PriorityId { get; set; }

        public Criticality Criticality { get; set; }
        [Required]
        public byte CriticalityId { get; set; }



    }
}