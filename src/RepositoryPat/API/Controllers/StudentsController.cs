using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pat.Domain.DAL;
using Microsoft.EntityFrameworkCore;
using Pat.Domain.Models;
using RepositoryPat.DAL;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RepositoryPat.APIControllers
{
    public class StudentsController : Controller
    {
        private IStudentRepository studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        [Route("api/students")]
        // GET: /<controller>/
        public async Task<IEnumerable<Student>> Index()
        {
            return await studentRepository.GetStudentsAsync();
        }

        public async Task<Student> Details(int id)
        {
            var student = await studentRepository.GetStudentByIdAsync(id);

            if (student == null)
            {
                return null;
            }

            return student;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("EnrollmentDate,FirstMidName,LastName")] Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    studentRepository.InsertStudent(student);
                    studentRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(student);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var studentToUpdate = await studentRepository.GetStudentByIdAsync(id);
            return View(studentToUpdate);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id, LastName, FirstMidName, EnrollmentDate")] Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    studentRepository.UpdateStudent(student);
                    studentRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            }
            return View(student);
        }

        public IActionResult Delete(int id = 0, bool? saveChangesError = false)
        {
            var student = studentRepository.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = studentRepository.GetStudentByIdAsync(id);
            if (student == null)
            {
                return RedirectToAction("Index");
            }

            try
            {
                studentRepository.DeleteStudent(id);
                studentRepository.Save();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
        }
    }
}
