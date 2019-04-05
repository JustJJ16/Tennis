using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace JaP_Tenis.Models
{
	public class ApplicationUser : IdentityUser
	{
		public Player Player { get; set; }
	}
}
