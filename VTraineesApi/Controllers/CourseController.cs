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
                        x => new Course() { Id = x.Id, Name = x.Name, Credit = x.Credit })
                    .ToList();
            return new ResponseModel(Courses);
        }
        public ResponseModel Get(int id)
        {
            VTraineesDBEntitiesOne db = new VTraineesDBEntitiesOne();
            ResponseModel response;
            Course c = db.Courses.Find(id);
            if (c != null)
            {
                Course course = new Course()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Credit = c.Credit
                };
                return  new ResponseModel(course);
            }
            else
            {
                response = new ResponseModel(isSuccess:false,message:"Course not found");
            }
            return response;
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

        public ResponseModel Delete(int id)
        {
            ResponseModel response;   
            if (id != 0)
            {
                VTraineesDBEntitiesOne db = new VTraineesDBEntitiesOne();
                db.Courses.Remove(db.Courses.Find(id));
                db.SaveChanges();
                return new ResponseModel();
            }
            else
            {
                response = new ResponseModel(isSuccess:false,message:"Course Not Found");
            }
            return response;
        }
    }
}
