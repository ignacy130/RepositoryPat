using Pat.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPat.DAL
{
    public interface IStudentRepository : IDisposable
    {
        IEnumerable<Student> GetStudents();
        Student GetStudentByID(int id);
        void InsertStudent(Student student);
        void DeleteStudent(int id);
        void UpdateStudent(Student student);
        void Save();
    }
}
