﻿using RepositoryPat.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pat.Domain.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment : EntityBase
    {
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
