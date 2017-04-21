using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UniformInterface.Controllers
{
    public class CoursesController : ApiController
    {
        public IEnumerable<Course> Get()
        {
            return courses;
        }


        static readonly List<Course> courses = InitCourses();

        private static List<Course> InitCourses()
        {
            var ret = new List<Course>
            {
                new Course {id = 0, title = "WebApi"},
                new Course {id = 1, title = "MVC"}
            };
            return ret;

        }
    }

    public class Course
    {
        public int id;
        public string title;

    }
}
