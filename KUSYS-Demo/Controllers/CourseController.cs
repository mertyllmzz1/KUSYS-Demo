using BusinessLayer.Abstract;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace KUSYSDemo.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService service;
        private readonly ICoursesAndStudentsMatchesService serviceMatches;

        public CourseController(ICourseService _service, ICoursesAndStudentsMatchesService _serviceMatches)
        {
            service = _service;
            serviceMatches = _serviceMatches;
        }
        public IActionResult Index()
        {
            return View(service.GetAllList());
        }

        public IEnumerable<CoursesAndStudentsMatches> GetCourseDetailById(int id)// Kurs Idsine göre hangi öğrencilerin kursu aldığına erişilebilir
        {
            List<CoursesAndStudentsMatches> course;
            course = serviceMatches.GetListById(p => p.CoursesId == id, p => p.Students, p => p.Courses);
            return course;
        }

        public IEnumerable<Courses> GetUnassignedCourseForStudent(int id) // Sadece Öğrenciye atanmamış kursları listelememizi sağlayan Metot
        {
            IList<Courses> courses;
            List<int> coursesAndStudents;
            coursesAndStudents = (List<int>)serviceMatches.GetListById(p => p.StudentsId == id, p => p.Students, p => p.Courses).Select(p=>p.CoursesId).ToList();
            courses = (IList<Courses>)service.GetAllList().Where(p=>!coursesAndStudents.Contains(p.Id)).ToList(); // Match tablomuzda ilgili öğrenciye ait olmayan kursları listeler
            return courses;
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Courses course)
        {
            ViewBag.Message = service.Insert(course);
            return View();
        }
        [HttpGet]
        [Route("/Course/Update/{Id}")]
        public IActionResult Update(int Id)
        {
            return View(service.GetById(x => x.Id == Id));
        }
        [HttpPost]
        [Route("/Course/Update/{Id}")]
        public IActionResult Update(int Id, Courses course)
        {
            course.Id = Id;
            ViewBag.Message = service.Update(course);
            return View(service.GetById(x => x.Id == Id));
        }
        [HttpGet]
        [Route("/Course/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            service.Delete(x => x.Id == Id);
            return Redirect("/Course");
        }
    }
}
