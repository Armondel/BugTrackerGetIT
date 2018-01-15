using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BugTrackerGetIT.Data;
using BugTrackerGetIT.DTO;
using BugTrackerGetIT.Models;
using BugTrackerGetIT.Models.TrackerViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BugTrackerGetIT.Controllers
{
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
			// TBD

			return View();
		}

		[Route("/tracker/new")]
		public IActionResult NewBug()
		{
			var bugModel = new DetailedBugViewModel
			{
				DetailedBugDto = new DetailedBugDto(),
				Criticalities = _context.Criticality.ToList(),
				Priorities = _context.Priority.ToList()
			};

			return View(bugModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> SaveBug(DetailedBugDto detailedBugDto)
		{
			detailedBugDto.UserId = _userManager.GetUserId(HttpContext.User);
			detailedBugDto.DateCreated = DateTime.Now;
			if (detailedBugDto.StatusId == 0)
				detailedBugDto.StatusId = 1;
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

			var bug = Mapper.Map<DetailedBugDto, Bug>(detailedBugDto);

			lock (_context)
			{
				_context.Bugs.Add(bug);

				_context.SaveChanges();
			}

			var bugRecord = Mapper.Map<Bug, BugHistoryDto>(bug);

			await SaveToHistoryAsyncResult(bugRecord);

			return View("Index");
		}

		[HttpPost]
		private async Task<bool> SaveToHistoryAsyncResult(BugHistoryDto recordDto)
		{
			var record = Mapper.Map<BugHistoryDto, BugHistory>(recordDto);

			if (record.Description == null)
				record.Description = "Bug Created";

			if (record.DateChanged.Year == 1)
				record.DateChanged = DateTime.Now;

			_context.BugHistory.Add(record);

			await _context.SaveChangesAsync();

			return true;
		}
	}
}