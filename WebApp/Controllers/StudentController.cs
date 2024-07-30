using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class StudentController : Controller
    {
        private StudentContext _studentContext;
        public StudentController(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }
        public IActionResult Index()
        {
            var _data = _studentContext.Students.ToList();
            //var _data = StudentRepo.GetStudents();

            return View(_data);
        }
        public IActionResult AddStudent()
        {
            ViewBag.Action = nameof(AddStudent);
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(StudentModel model)
        {
            //var Data = _studentContext.Students.FirstOrDefault(x => x.StudentPhone == model.StudentPhone && model.StudentId == 0);

            //StudentRepo.GetStudents().FirstOrDefault(x => x.StudentPhone == model.StudentPhone && model.StudentId == 0);

            //if (Data != null)
            //    return BadRequest("Student Already Exists.");

            if (ModelState.IsValid)
            {
                _studentContext.Add(model);
                _studentContext.SaveChanges();
                //StudentRepo.AddStudents(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public IActionResult EditStudent(int id)
        {
            ViewBag.Action = nameof(EditStudent);
            //var data = StudentRepo.GetStudentById(id);
            var data = _studentContext.Students.FirstOrDefault(s => s.StudentId == id);
            return View(data);
        }
        [HttpPost]
        public IActionResult EditStudent(int id, StudentModel model)
        {
            //var Data = StudentRepo.GetStudents().FirstOrDefault(x => x.StudentPhone == model.StudentPhone && model.StudentId != x.StudentId);

            //if (Data != null)
            //    return BadRequest("Student Already Exists.");

            if (ModelState.IsValid)
            {
                _studentContext.Update(model);
                _studentContext.SaveChanges();
                //StudentRepo.UpdateStudents(id, model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public IActionResult DeleteStudent(int id)
        {
            var Data = _studentContext.Students.FirstOrDefault(s => s.StudentId == id);

            if (Data != null)
            {
                _studentContext.Remove(Data);
                _studentContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
