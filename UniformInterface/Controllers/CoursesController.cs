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
        private Course GetCourse(int id)
        {
            var ret = (from c in Courses
                       where c.Id == id
                       select c).FirstOrDefault();
            return ret;
        }
        public IEnumerable<Course> AllCourses()
        {
            return Courses;
        }
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Course c)
        {
            c.Id = Courses.Count;
            Courses.Add(c);
            var msg = Request.CreateResponse(HttpStatusCode.Created);
            msg.Headers.Location = new Uri(Request.RequestUri + c.Id.ToString());
            return msg;
        }
        [HttpPut]
        public void Put(int id,[FromBody]Course c)
        {
            var course = GetCourse(id);
            course.Title = c.Title;

        }
        [HttpDelete]
        public void RemoveCourse(int id)
        {

            Courses.Remove(GetCourse(id));
        }
        

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage msg = null;
            var ret = (from c in Courses
                       where c.Id == id
                       select c).FirstOrDefault();
            if (ret == null)
            {
                msg = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Course not found");
            }
            else
            {
                msg = Request.CreateResponse<Course>(HttpStatusCode.OK, ret);
            }
            return msg;
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
