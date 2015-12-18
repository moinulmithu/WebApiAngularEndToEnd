using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess;
using VTraineesApi.Models;

namespace VTraineesApi.Controllers
{
    public class CourseController : ApiController
    {
        public ResponseModel Get()
        {
            VTraineesDBEntitiesOne db = new VTraineesDBEntitiesOne();
            var Courses =
                db.Courses.AsEnumerable()
                    .Select(
                        x => new Course() {Id  = x.Id, Name = x.Name, Credit = x.Credit})
                    .ToList();
            return new ResponseModel(Courses);
        }
        public ResponseModel Post(Course course)
        {
            using(VTraineesDBEntitiesOne db = new VTraineesDBEntitiesOne())
            {
                bool isNotNull = db.Courses != null;
                if (isNotNull)
                {
                    if (course.Id != 0)
                    {
                        course.Enrollments = null;
                        db.Entry(course).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Courses.Add(course);
                    }
                    db.SaveChanges();
                }
                return new ResponseModel(isSuccess:isNotNull);
            }
        }
    }
}
