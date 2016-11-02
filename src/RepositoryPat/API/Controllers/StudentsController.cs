using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pat.Domain.DAL;
using Microsoft.EntityFrameworkCore;
using Pat.Domain.Models;
using RepositoryPat.DAL;
using System.Net.Http;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RepositoryPat.APIControllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private IStudentRepository studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Student>> Index()
        {
            return await studentRepository.GetStudentsAsync();
        }

        [HttpGet("{id}")]
        public async Task<Student> Details(int id)
        {
            var student = await studentRepository.GetStudentByIdAsync(id);

            if (student == null)
            {
                return null;
            }

            return student;
        }

        [HttpPost]
        public IActionResult Create([Bind("EnrollmentDate,FirstMidName,LastName")] Student student)
        {
            try
            {
                if (student == null)
                {
                    return BadRequest();
                }
                else
                {
                    studentRepository.InsertStudent(student);
                    studentRepository.Save();
                    return CreatedAtRoute("GetTodo", new { id = student.Id }, student);
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                return StatusCode(500, "Unable to save changes.");
            }
        }

        [HttpPatch]
        public IActionResult Edit([Bind("Id, LastName, FirstMidName, EnrollmentDate")] Student student)
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

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var student = studentRepository.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            try
            {
                studentRepository.DeleteStudent(id);
                studentRepository.Save();
                return new NoContentResult();
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return StatusCode(500, $"Unable to delete student with id = {id}.");
            }
        }
    }
}
