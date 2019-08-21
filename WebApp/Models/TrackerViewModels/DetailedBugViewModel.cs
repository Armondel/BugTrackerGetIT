using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BugTrackerGetIT.Core.Bug;
using BugTrackerGetIT.WebApp.DTO;

namespace BugTrackerGetIT.WebApp.Models.TrackerViewModels
{
    public class DetailedBugViewModel
    {
	    public DetailedBugDto DetailedBugDto { get; set; }

	    public IEnumerable<Criticality> Criticalities { get; set; }

	    public IEnumerable<Priority> Priorities { get; set; }
    }
}
