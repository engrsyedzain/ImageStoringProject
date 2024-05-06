using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ImageStoringProject.Model
{
    public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Photo> Photos { get; set; }
}
}
