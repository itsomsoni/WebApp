using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext()
        {

        }
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        { }
        public virtual DbSet<StudentModel> Students { get; set; }
        public virtual DbSet<CourseModel> Courses { get; set; }
    }
}
