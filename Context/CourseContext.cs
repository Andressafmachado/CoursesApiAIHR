using Microsoft.EntityFrameworkCore;
using CourseStore.Models;

public class CourseContext : DbContext
{
    public CourseContext(DbContextOptions options) : base(options) { }
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<History> History { get; set; } = null!;

}

