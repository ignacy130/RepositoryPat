using Pat.Domain.DAL;
using Pat.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPat.DAL
{
    public class UnitOfWork : IDisposable
    {
        private SchoolContext context = new SchoolContext(new Microsoft.EntityFrameworkCore.DbContextOptions<SchoolContext>());
        private Repository<Course> courseRepository;
        private Repository<Department> departmentRepository;

        public Repository<Course> CourseRepository
        {
            get
            {

                if (this.courseRepository == null)
                {
                    this.courseRepository = new Repository<Course>(context);
                }
                return courseRepository;
            }
        }

        public Repository<Department> DepartmentRepository
        {
            get
            {

                if (this.departmentRepository == null)
                {
                    this.courseRepository = new Repository<Course>(context);
                }
                return departmentRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
