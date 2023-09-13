using Microsoft.EntityFrameworkCore;
using Portifólio_DotNet.Models;

namespace Portifólio_DotNet.Contexts;

public class ProjectContext : DbContext
{
    public ProjectContext(DbContextOptions<ProjectContext> options) : base(options){}
    public DbSet <Project> Projects { get; set; }
}