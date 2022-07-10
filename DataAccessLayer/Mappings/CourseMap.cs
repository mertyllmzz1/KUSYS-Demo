using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappings
{
    public class CourseMap : IEntityTypeConfiguration<Courses>
    {
        public void Configure(EntityTypeBuilder<Courses> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.CourseName).HasMaxLength(100);

            //A Course can have many (one ore more than one) courses.
            builder.HasMany(p => p.CoursesAndStudentsMatches).WithOne(p => p.Courses).HasForeignKey(p => p.CoursesId);
            builder.ToTable("Courses");
        }
    }
}
