using System;
using System.Collections.Generic;
using System.Text;
using JaP_Tenis.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JaP_Tenis.Data
{
	public class TennisContext : IdentityDbContext<ApplicationUser>
	{
		public TennisContext(DbContextOptions<TennisContext> options)
			: base(options)
		{
		}
		public DbSet<Match> Matches { get; set; }
		public DbSet<Set> Sets { get; set; }
		public DbSet<Game> Games { get; set; }
		public DbSet<Curt> Curts { get; set; }
		public DbSet<Photo> Photos { get; set; }
	}
}
