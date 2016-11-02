using Microsoft.AspNetCore.Mvc;
using Moq;
using Pat.Domain.Models;
using RepositoryPat.Controllers;
using RepositoryPat.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RepositoryPat.Tests
{
    public class StudentsControllerTests
    {
        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfBrainstormSessions()
        {
            // Arrange
            var mockRepo = new Mock<IStudentRepository>();
            mockRepo.Setup(repo => repo.GetStudentsAsync()).Returns(Task.FromResult(GetTestStudents()));
            var controller = new StudentsController(mockRepo.Object);
            
            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Student>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        private IEnumerable<Student> GetTestStudents()
        {
            var students = new List<Student>();
            students.Add(new Student()
            {
                EnrollmentDate = new DateTime(2016, 7, 2),
                Id = 1,
                FirstMidName = "Test One"
            });
            students.Add(new Student()
            {
                EnrollmentDate = new DateTime(2016, 7, 1),
                Id = 2,
                FirstMidName = "Test Two"
            });
            return students;
        }

        [Fact]
        public void StudentEditPost_ReturnsBadRequestResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var mockRepo = new Mock<IStudentRepository>();
            mockRepo.Setup(repo => repo.GetStudentsAsync()).Returns(Task.FromResult(GetTestStudents()));
            var controller = new StudentsController(mockRepo.Object);
            controller.ModelState.AddModelError("FirstMidName", "Required");
            var editedStudent = new Student()
            {
                FirstMidName = null,
                LastName = "Kowalski",
                EnrollmentDate = DateTime.Now.AddDays(-7),
                Id = 100,
            };

            // Act
            var result = controller.Edit(editedStudent);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }
    }
}
