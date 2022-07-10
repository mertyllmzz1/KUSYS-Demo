using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Students
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public List<CoursesAndStudentsMatches> CoursesAndStudentsMatches { get; set; }
    }
}
