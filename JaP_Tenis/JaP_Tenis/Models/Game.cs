using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace JaP_Tenis.Models
{
	public class Game
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public Set Set { get; set; }
		[Required]
		public ApplicationUser User { get; set; }
		[Required]
		public bool Winner { get; set; }
		[Required]
		public int LoserPoints { get; set; }
	}
}
