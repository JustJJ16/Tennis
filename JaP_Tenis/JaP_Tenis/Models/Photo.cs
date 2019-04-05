using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JaP_Tenis.Models
{
	public class Photo
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string PhotoPath { get; set; }
		[Required]
		public Match Match { get; set; }
	}
}
