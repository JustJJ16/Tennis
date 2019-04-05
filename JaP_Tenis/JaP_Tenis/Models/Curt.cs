using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JaP_Tenis.Models
{
	public class Curt
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[MaxLength(50)]
		[Display(Name = "Název")]
		public string Name { get; set; }
	}
}
