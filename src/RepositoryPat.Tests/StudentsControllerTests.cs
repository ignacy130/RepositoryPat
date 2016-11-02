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

        //[Fact]
        //public void IndexPost_ReturnsBadRequestResult_WhenModelStateIsInvalid()
        //{
        //    // Arrange
        //    var mockRepo = new Mock<IStudentRepository>();
        //    mockRepo.Setup(repo => repo.GetStudents());
        //    var controller = new StudentsController(mockRepo.Object);
        //    controller.ModelState.AddModelError("SessionName", "Required");
        //    var newSession = new StudentsController.NewSessionModel();

        //    // Act
        //    var result = controller.Index(newSession);

        //    // Assert
        //    var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        //    Assert.IsType<SerializableError>(badRequestResult.Value);
        //}

        //[Fact]
        //public async Task IndexPost_ReturnsARedirectAndAddsSession_WhenModelStateIsValid()
        //{
        //    // Arrange
        //    var mockRepo = new Mock<IStudentRepository>();
        //    mockRepo.Setup(repo => repo.InsertStudent(It.IsAny<Student>())).Verifiable();
        //    var controller = new StudentsController(mockRepo.Object);
        //    var newSession = new StudentsController.NewSessionModel()
        //    {
        //        SessionName = "Test Name"
        //    };

        //    // Act
        //    var result = await controller.Index(newSession);

        //    // Assert
        //    var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        //    Assert.Null(redirectToActionResult.ControllerName);
        //    Assert.Equal("Index", redirectToActionResult.ActionName);
        //    mockRepo.Verify();
        //}
    }
}
