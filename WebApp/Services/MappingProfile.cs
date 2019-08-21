using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BugTrackerGetIT.Core.Bug;
using BugTrackerGetIT.WebApp.DTO;
using BugTrackerGetIT.WebApp.Models;

namespace BugTrackerGetIT.WebApp.Services
{
    public class MappingProfile : Profile
    {
	    public MappingProfile()
	    {
			//Mapping from Domain to DTO
		    CreateMap<Bug, BugDto>();
		    CreateMap<Bug, DetailedBugDto>();
		    CreateMap<ApplicationUser, UserDto>();
		    CreateMap<BugHistory, BugHistoryDto>();
		    CreateMap<Bug, BugHistoryDto>().
			    ForMember(dest => dest.BugId, opts => opts.MapFrom(src => src.Id)).
			    ForMember(dest => dest.Id, opt => opt.Ignore());


			//Mapping from DTO to Domain
		    CreateMap<BugDto, Bug>().ForMember(m => m.Id, opt => opt.Ignore());
		    CreateMap<DetailedBugDto, Bug>().ForMember(m => m.Id, opt => opt.Ignore());
		    CreateMap<BugHistoryDto, BugHistory>().ForMember(m => m.Id, opt => opt.Ignore());
	    }
    }
}
