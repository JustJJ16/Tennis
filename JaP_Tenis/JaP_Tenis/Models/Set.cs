using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JaP_Tenis.Models
{
	public class Set
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public int Order { get; set; }
		[Required]
		public Match Match { get; set; }
	}
}
