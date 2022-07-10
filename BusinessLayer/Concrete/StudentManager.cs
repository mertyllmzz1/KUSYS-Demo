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
    public class StudentManager: Repositories<Students>, IStudentService
    {
        public StudentManager(StudentContext db):base(db)
        {

        }
    }
}
