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
            return Courses;
        }
        [HttpPost]
        public void NewCourse([FromBody]Course c)
        {
            c.Id = Courses.Count;
            Courses.Add(c);
        }
        [HttpPut]
        public void Put(int id,[FromBody]Course c)
        {
            var course = Get(id);
            course.Title = c.Title;

        }
        [HttpDelete]
        public void RemoveCourse(int id)
        {

            Courses.Remove(Get(id));
        }
        [HttpGet]
        public Course Get(int id)
        {
            var ret = (from c in Courses
                       where c.Id == id
                       select c).FirstOrDefault();
            return ret;
        }

        static readonly List<Course> Courses = InitCourses();

        private static List<Course> InitCourses()
        {
            var ret = new List<Course>
            {
                new Course {Id = 0, Title = "WebApi"},
                new Course {Id = 1, Title = "MVC"}
            };
            return ret;

        }
    }

    public class Course
    {
        public int Id;
        public string Title;

    }
}
