using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public class ProjectContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=WebApi;Trusted_Connection=True;MultipleActiveResultSets=true;");
            
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<AppUser> Categories { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
