﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using JaP_Tenis.Data;
using JaP_Tenis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace JaP_Tenis.Areas.Identity.Pages.Account
{
	[AllowAnonymous]
	public class RegisterModel : PageModel
	{
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly ILogger<RegisterModel> _logger;
		private readonly TennisContext _context;
		private readonly RoleManager<IdentityRole> _roleManager;

		public RegisterModel(
			UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager,
			ILogger<RegisterModel> logger,
			TennisContext context,
			RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_logger = logger;
			_context = context;
			_roleManager = roleManager;

		}

		[BindProperty]
		public InputModel Input { get; set; }

		public string ReturnUrl { get; set; }

		public class InputModel
		{
			[Required]
			[StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
			[Display(Name = "User name")]
			public string UserName { get; set; }

			[Required]
			[EmailAddress]
			[Display(Name = "Email")]
			public string Email { get; set; }

			[Required]
			[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
			[DataType(DataType.Password)]
			[Display(Name = "Password")]
			public string Password { get; set; }

			[DataType(DataType.Password)]
			[Display(Name = "Confirm password")]
			[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
			public string ConfirmPassword { get; set; }
		}

		public void OnGet(string returnUrl = null)
		{
			ReturnUrl = returnUrl;
		}

		public async Task<IActionResult> OnPostAsync(string returnUrl = null)
		{
			returnUrl = returnUrl ?? Url.Content("~/");
			if (ModelState.IsValid)
			{
				var users = _context.Users;
				var user = new ApplicationUser { UserName = Input.UserName, Email = Input.Email };
				var result = await _userManager.CreateAsync(user, Input.Password);
				if (result.Succeeded)
				{
					_logger.LogInformation("User created a new account with password.");

					if (users.Count() == 1)
					{
						IdentityRole adminRole = new IdentityRole();
						adminRole.Name = "Admin";
						await _roleManager.CreateAsync(adminRole);
						await _userManager.AddToRoleAsync(user, "Admin");
					}

					var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
					var callbackUrl = Url.Page(
						"/Account/ConfirmEmail",
						pageHandler: null,
						values: new { userId = user.Id, code = code },
						protocol: Request.Scheme);

					await _signInManager.SignInAsync(user, isPersistent: false);
					return LocalRedirect(returnUrl);
				}
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}

			// If we got this far, something failed, redisplay form
			return Page();
		}
	}
}
