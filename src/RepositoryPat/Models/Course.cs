using RepositoryPat.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pat.Domain.Models
{
    public class Course : EntityBase
    {
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
