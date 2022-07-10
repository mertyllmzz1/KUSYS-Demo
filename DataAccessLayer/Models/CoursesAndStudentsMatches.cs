using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class CoursesAndStudentsMatches
    {
        //SQL üzerinde, Course tablosunda veya Student Tablosunda XML tipte tutulabilirdi ancak daha düzenli olması açısından bu şekilde yapıldı
        public int Id { get; set; }
        public int StudentsId { get; set; }
        public int CoursesId { get; set; }
        public Students Students{ get; set; }
        public Courses Courses { get; set; }
    }
}
