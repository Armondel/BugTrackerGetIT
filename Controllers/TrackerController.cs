using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BugTrackerGetIT.Data;
using BugTrackerGetIT.DTO;
using BugTrackerGetIT.Models;
using BugTrackerGetIT.Models.TrackerViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugTrackerGetIT.Controllers
{
	[Authorize]
	public class TrackerController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<ApplicationUser> _userManager;

		public TrackerController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
		{
			_context = context;
			_userManager = userManager;

		}

		[Route("/tracker/all")]
		public IActionResult Index()
		{


			return View();
		}

		[Route("/tracker/bug/{id}")]
		public IActionResult ViewBug(string id)
		{
			var bug = _context.Bugs.
				Include(b => b.User).
				Include(b => b.Status).
				SingleOrDefault(b => b.Id == id);
			if (bug == null)
				return NotFound();

			var bugModel = new DetailedBugViewModel
			{
				DetailedBugDto = Mapper.Map<Bug, DetailedBugDto>(bug),
				Priorities = _context.Priority.ToList(),
				Criticalities = _context.Criticality.ToList()
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
				},
				Criticalities = _context.Criticality.ToList(),
				Priorities = _context.Priority.ToList()
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
					DetailedBugDto = new DetailedBugDto(),
					Criticalities = _context.Criticality.ToList(),
					Priorities = _context.Priority.ToList()
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

			var bug = _context.Bugs.SingleOrDefault(b => b.Id == detailedBugDto.Id);
			if (bug == null)
			{
				bug = Mapper.Map<DetailedBugDto, Bug>(detailedBugDto);
				_context.Bugs.Add(bug);
			}
			else
			{
				bug.Description = detailedBugDto.Description;
				bug.PriorityId = detailedBugDto.PriorityId;
				bug.CriticalityId = detailedBugDto.CriticalityId;
				bug.StatusId = detailedBugDto.StatusId;
			}
			var bugRecord = Mapper.Map<Bug, BugHistoryDto>(bug);

			bugRecord.Description = detailedBugDto.Comment;

			await SaveToHistoryAsyncResult(bugRecord);

			return View("Index");
		}

		[HttpPost]
		private async Task<bool> SaveToHistoryAsyncResult(BugHistoryDto recordDto)
		{
			var record = Mapper.Map<BugHistoryDto, BugHistory>(recordDto);

			record.DateChanged = DateTime.Now;

			_context.BugHistory.Add(record);

			await _context.SaveChangesAsync();

			return true;
		}
	}
}