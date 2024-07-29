using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            var _data = StudentRepo.GetStudents();
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
            var Data = StudentRepo.GetStudents().FirstOrDefault(x => x.StudentPhone == model.StudentPhone && model.StudentId == 0);

            if (Data != null)
                return BadRequest("Student Already Exists.");

            if (ModelState.IsValid)
            {
                StudentRepo.AddStudents(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public IActionResult EditStudent(int id)
        {
            ViewBag.Action = nameof(EditStudent);
            var data = StudentRepo.GetStudentById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult EditStudent(int id, StudentModel model)
        {
            var Data = StudentRepo.GetStudents().FirstOrDefault(x => x.StudentPhone == model.StudentPhone && model.StudentId != x.StudentId);

            if (Data != null)
                return BadRequest("Student Already Exists.");

            if (ModelState.IsValid)
            {
                StudentRepo.UpdateStudents(id, model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public IActionResult DeleteStudent(int id)
        {
            StudentRepo.DeleteStudent(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
