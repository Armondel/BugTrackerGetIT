using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTrackerGetIT.Models
{
    public class Status
    {
        [Key]
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }
        
    }
}