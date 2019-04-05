using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JaP_Tenis.Data;
using JaP_Tenis.Models;
using JaP_Tenis.Models.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JaP_Tenis.Controllers
{
	public class AdminController : Controller
	{
		private readonly TennisContext _context;
		public AdminController(TennisContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			return View();
		}

		[Authorize(Roles = "Admin")]
		public IActionResult CurtManagement()
		{
			var model = new CurtManagementModel()
			{
				Curts = _context.Curts.ToList()
			};
			return View(model);
		}

		[Authorize(Roles = "Admin")]
		[HttpPost]
		public IActionResult CurtManagement(CurtManagementModel model)
		{
			var curt = new Curt() {Name = model.Name};
			_context.Add(curt);
			_context.SaveChanges();
			return RedirectToAction("CurtManagement", "Admin");
		}
	}
}