using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTrackerGetIT.Models
{
    public class Criticality
    {
        [Key]
        public byte Id { get; set; }
        [Required]
        public string CriticalityName { get; set; }
    }
}