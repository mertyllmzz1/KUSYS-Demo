using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public  class CourseManager: Repositories<Courses>,ICourseService
    {
        public CourseManager(StudentContext db):base(db)
        {
            
        }
    }
}
