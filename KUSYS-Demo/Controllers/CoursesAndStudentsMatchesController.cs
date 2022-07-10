using BusinessLayer.Abstract;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace KUSYSDemo.Controllers
{
    public class CoursesAndStudentsMatchesController : Controller
    {
        private readonly ICoursesAndStudentsMatchesService service;


        public CoursesAndStudentsMatchesController( ICoursesAndStudentsMatchesService _service)
        {
            service = _service;
        }
        public IActionResult Index()
        {
            return View(service.GetAllList(p=>p.Courses,p=>p.Students));
        }

        //public IEnumerable<CoursesAndStudentsMatches> GetCourseDetailById(int id)// Kurs Idsine göre hangi öğrencilerin kursu aldığına erişilebilir
        //{
        //    List<CoursesAndStudentsMatches> course;
        //    course = serviceMatches.GetListById(p => p.CoursesId == id, p => p.Students, p => p.Courses);
        //    return course;
        //}

        //public IEnumerable<Courses> GetUnassignedCourseForStudent(int id)
        //{
        //    IList<Courses> courses;
        //    List<int> coursesAndStudents;
        //    coursesAndStudents = (List<int>)serviceMatches.GetListById(p => p.StudentsId == id, p => p.Students, p => p.Courses).Select(p => p.CoursesId).ToList();
        //    courses = (IList<Courses>)service.GetAllList().Where(p => !coursesAndStudents.Contains(p.Id)).ToList();
        //    return courses;
        //}
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        } 
        [HttpPost]
        public JsonResult Insert([FromBody]CoursesAndStudentsMatches courseMatch)
        {
            ViewBag.Message = service.Insert(courseMatch);
            return Json("/CoursesAndStudentsMatches");
        }
        [HttpGet]
        [Route("/CoursesAndStudentsMatches/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            service.Delete(x => x.Id == Id);
            return Redirect("/CoursesAndStudentsMatches");
        }
    }
}
