using Devoluiva.AnonymousPoll.CliV2.Entities;
using Devoluiva.AnonymousPoll.Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Devoluiva.AnonymousPoll.CliV2.DBContext;

public class StudentContext : DbContext
{
    public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<StudentEntity> Students { get; set; }
}
