using Microsoft.EntityFrameworkCore;

namespace StudentManagementSys_SURE.Models
{
    public class StudentManagContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> departments { get; set; }
        public StudentManagContext(DbContextOptions<StudentManagContext> options)
            : base(options)
        {

        }

        //no need it because the builder override it 
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=StudentManagementSURE;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Department>()
                .HasData(new Department[]
                {
                    new Department {Id=1, Name="AI",ManagerName="Ahmed"},
                    new Department {Id=2,Name="SE",ManagerName="Mohamed"},

                });

            modelBuilder.Entity<Student>()
                .HasData(new Student[] {

                new Student {Id=1,Name="Ammar",Age=22,Address="cairo",DepartmentId=1},
                new Student {Id=2,Name="Mai",Age=24,Address="Mansoura",DepartmentId=1},
                new Student {Id=3,Name="Hazem",Age=20,Address="Alex",DepartmentId=2}

                });
        }
    }
}
