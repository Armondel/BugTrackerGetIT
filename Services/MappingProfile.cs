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
		    CreateMap<Bug, DetailedBugDto>();
		    CreateMap<Status, StatusDto>();
		    CreateMap<Criticality, CriticalityDto>();
		    CreateMap<Priority, PriorityDto>();
		    CreateMap<ApplicationUser, UserDto>();
		    CreateMap<Bug, BugHistoryDto>().
			    ForMember(dest => dest.BugId, opts => opts.MapFrom(src => src.Id)).
			    ForMember(dest => dest.Id, opt => opt.Ignore());

		    CreateMap<BugDto, Bug>().ForMember(m => m.Id, opt => opt.Ignore());
		    CreateMap<DetailedBugDto, Bug>().ForMember(m => m.Id, opt => opt.Ignore());
		    CreateMap<BugHistoryDto, BugHistory>().ForMember(m => m.Id, opt => opt.Ignore());
	    }
    }
}
