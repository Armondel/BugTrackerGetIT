using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BugTrackerGetIT.DTO;
using BugTrackerGetIT.Models;

namespace BugTrackerGetIT.Services
{
    public class MappingProfile : Profile
    {
	    public MappingProfile()
	    {
		    CreateMap<Bug, BugDto>();
		    CreateMap<Status, StatusDto>();
		    CreateMap<Criticality, CriticalityDto>();
		    CreateMap<Priority, PriorityDto>();
		    CreateMap<ApplicationUser, UserDto>();


		    CreateMap<BugDto, Bug>().ForMember(m => m.Id, opt => opt.Ignore());
	    }
    }
}
