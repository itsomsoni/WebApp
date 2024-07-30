using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext()
        {

        }
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        { }
        public virtual DbSet<StudentModel> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WebApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }
}
