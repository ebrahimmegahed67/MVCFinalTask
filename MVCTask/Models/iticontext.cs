using Microsoft.EntityFrameworkCore;

namespace MVCTask.Models
{
    public class iticontext: DbContext
    {
        public virtual DbSet<employee> Employees { get; set; }
        public virtual DbSet<project> Projects { get; set; }
        public virtual DbSet<department> Departments { get; set; }
        public virtual DbSet<dependent> Dependents { get; set; }
        public virtual DbSet<department_location> dep_loc { get; set; }
        public virtual DbSet<works_on> WOn { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=MVCFINALTASK;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<works_on>().HasKey("Essn", "pno");
            modelBuilder.Entity<department_location>().HasKey("Dnumber", "Dloaction");
            base.OnModelCreating(modelBuilder);
        }
    }
}
