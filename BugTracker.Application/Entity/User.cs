namespace BugTracker.Application.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(20, MinimumLength = 1)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        public string Password { get; set; }
    }
}
