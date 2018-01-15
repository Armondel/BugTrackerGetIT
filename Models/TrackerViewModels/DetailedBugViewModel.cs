using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTrackerGetIT.DTO;

namespace BugTrackerGetIT.Models.TrackerViewModels
{
    public class DetailedBugViewModel
    {
	    public DetailedBugDto DetailedBugDto { get; set; }

	    public IEnumerable<Criticality> Criticalities { get; set; }

	    public IEnumerable<Priority> Priorities { get; set; }

    }
}
