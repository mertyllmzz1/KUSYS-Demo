using DataAccessLayer.Mappings;
namespace DataAccessLayer.Concrete
{
    public class StudentContext: DbContext
    {
        public DbSet<Students> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<CoursesAndStudentsMatches> CoursesAndStudentsMatches { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=OZATA-LT-188\SQLEXPRESS;Database=StudentManagement;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentMap());
            modelBuilder.ApplyConfiguration(new CourseMap());
            modelBuilder.ApplyConfiguration(new CourseAndStudentMatchesMap());
        }
    }
 
}
