using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BugTrackerGetIT.Core.Bug;
using BugTrackerGetIT.Core.BugHistory;
using BugTrackerGetIT.Core.User;
using BugTrackerGetIT.WebApp.Data;
using BugTrackerGetIT.WebApp.DTO;
using BugTrackerGetIT.WebApp.Models;
using BugTrackerGetIT.WebApp.Models.TrackerViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugTrackerGetIT.WebApp.Controllers
{
	[Authorize]
	public class TrackerController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<User> _userManager;
		private readonly IMapper _mapper;

		public TrackerController(ApplicationDbContext context, UserManager<User> userManager, IMapper mapper)
		{
			_context = context;
			_userManager = userManager;
			_mapper = mapper;

		}

		[Route("/tracker/all")]
		public IActionResult Index()
		{


			return View();
		}

		[Route("/tracker/bug/{id}")]
		public IActionResult ViewBug(string id)
		{
			Bug bug = null;
			if (bug == null)
				return NotFound();

			var bugModel = new DetailedBugViewModel
			{
				DetailedBugDto = _mapper.Map<Bug, DetailedBugDto>(bug)
			};

			return bugModel.DetailedBugDto.StatusId == 4 ? View("ClosedViewBug", bugModel) : View("ViewBug", bugModel);
		}

		[Route("/tracker/new")]
		public IActionResult NewBug()
		{
			var bugModel = new DetailedBugViewModel
			{
				DetailedBugDto = new DetailedBugDto
				{
					Comment = "The issue created",
					DateCreated = DateTime.Now,
					UserId = _userManager.GetUserId(HttpContext.User),
					StatusId = 1
				}
			};

			return View(bugModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> SaveBug(DetailedBugDto detailedBugDto, string status)
		{
			if (!ModelState.IsValid)
			{
				var bugModel = new DetailedBugViewModel
				{
					DetailedBugDto = new DetailedBugDto()
				};

				return View("NewBug", bugModel);
			}

			switch (status)
			{
				case "Open":
					detailedBugDto.StatusId = 2;
					break;
				case "Resolve":
					detailedBugDto.StatusId = 3;
					break;
				case "Close":
					detailedBugDto.StatusId = 4;
					break;
				default:
					detailedBugDto.StatusId = 1;
					break;
			}

			var bug = _context.Bugs.SingleOrDefault(b => b.Id.ToString() == detailedBugDto.Id);
			if (bug == null)
			{
				bug = _mapper.Map<DetailedBugDto, Bug>(detailedBugDto);
				_context.Bugs.Add(bug);
			}
			else
			{
				bug.Description = detailedBugDto.Description;
				bug.Priority = detailedBugDto.Priority;
				bug.Criticality = detailedBugDto.Criticality;
				bug.Status = detailedBugDto.Status;
			}
			var bugRecord = _mapper.Map<Bug, BugHistoryDto>(bug);

			bugRecord.Description = detailedBugDto.Comment;

			await SaveToHistoryAsyncResult(bugRecord);

			return View("Index");
		}

		[HttpPost]
		private async Task<bool> SaveToHistoryAsyncResult(BugHistoryDto recordDto)
		{
			var record = _mapper.Map<BugHistoryDto, BugHistory>(recordDto);

			record.DateChanged = DateTime.Now;

			_context.BugHistory.Add(record);

			await _context.SaveChangesAsync();

			return true;
		}
	}
}