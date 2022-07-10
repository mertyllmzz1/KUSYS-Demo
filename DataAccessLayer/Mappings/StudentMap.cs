using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappings
{
    public class StudentMap : IEntityTypeConfiguration<Students>
    {
        public void Configure(EntityTypeBuilder<Students> builder)
        {
            builder.HasKey(p=>p.Id);
            builder.Property(p=>p.Id).ValueGeneratedOnAdd();
            builder.Property(p=>p.FirstName).HasMaxLength(100);
            builder.Property(p=>p.LastName).HasMaxLength(100);
            builder.Property(p => p.BirthDate).HasColumnType("datetime");

            //A Student can have many (one ore more than one) courses.
            builder.HasMany(p => p.CoursesAndStudentsMatches).WithOne(p => p.Students).HasForeignKey(p => p.StudentsId);
            builder.ToTable("Students");
        }
    }
}
