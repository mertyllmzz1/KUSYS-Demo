using BusinessLayer.Abstract;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace KUSYSDemo.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService service;
        private readonly ICoursesAndStudentsMatchesService serviceMatches;
        
        public StudentController(IStudentService _service, ICoursesAndStudentsMatchesService _serviceMatches)
        {
            service = _service;
            serviceMatches= _serviceMatches;
        }
        public IActionResult Index()
        {
            return View(service.GetAllList());
        }
     
        public IEnumerable<CoursesAndStudentsMatches> GetStudentDetailById(int id)
        {
            List<CoursesAndStudentsMatches> students;
            students = serviceMatches.GetListById(p => p.StudentsId==id, p=>p.Students, p=> p.Courses);
            return students;
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Students student)
        {
            ViewBag.Message = service.Insert(student);
            return View();
        }
        [HttpGet]
        [Route("/Student/Update/{Id}")]
        public IActionResult Update(int Id)
        {
            return View(service.GetById(x => x.Id == Id));
        }
        [HttpPost]
        [Route("/Student/Update/{Id}")]
        public IActionResult Update(int Id,Students student)
        {
            student.Id = Id;
            ViewBag.Message = service.Update(student);
            return View(service.GetById(x=>x.Id == Id));
        }
        [HttpGet]
        [Route("/Student/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            service.Delete(x=>x.Id==Id);
            return Redirect("/Student");
        }

    }
}
