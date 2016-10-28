using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPat.Tests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var t = new StudentsControllerTests();
            t.Index_ReturnsAViewResult_WithAListOfBrainstormSessions();
        }
    }
}
