

namespace DataAccessLayer.Mappings
{
    public class CourseAndStudentMatchesMap : IEntityTypeConfiguration<CoursesAndStudentsMatches>
    {
        public void Configure(EntityTypeBuilder<CoursesAndStudentsMatches> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.HasOne(p => p.Courses).WithMany(p => p.CoursesAndStudentsMatches).HasForeignKey(p => p.CoursesId);
            builder.HasOne(p => p.Students).WithMany(p => p.CoursesAndStudentsMatches).HasForeignKey(p => p.StudentsId);
            builder.ToTable("CoursesAndStudentsMatches");
        }
    }
}
