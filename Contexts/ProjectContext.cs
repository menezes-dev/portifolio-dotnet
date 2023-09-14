using Microsoft.EntityFrameworkCore;
using Portifólio_DotNet.Models;

namespace Portifólio_DotNet.Contexts;

public class ProjectContext : DbContext
{
    public ProjectContext(DbContextOptions<ProjectContext> options) : base(options){}
    public DbSet <Project> Projects { get; set; }
    public DbSet <Experience> Experiences { get; set; }
    public DbSet <Qualification> Qualifications { get; set; }
    public DbSet <Stack> Stacks { get; set; }
}