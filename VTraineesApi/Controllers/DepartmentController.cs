using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using DataAccess;
using VTraineesApi.Models;

namespace VTraineesApi.Controllers
{
    public class DepartmentController : ApiController
    {
        public ResponseModel Get()
        {
            VTraineesDBEntitiesOne db = new VTraineesDBEntitiesOne();
            var departments = db.Departments.AsEnumerable().Select(x => new Department() {Id = x.Id, Dept_Name = x.Dept_Name}).ToList();
            return new ResponseModel(departments);
        }

        public ResponseModel Post(Department department)
        {
            //using (VTraineesDBEntitiesOne db = new VTraineesDBEntitiesOne())
            //{
            //    bool isNotNull = department != null;
            //    if (isNotNull)
            //    {
            //        if (department.Id != 0)
            //        {
            //            db.Entry(department).State = EntityState.Modified;
            //        }
            //        else
            //        {
            //            db.Departments.Add(department);
            //        }
            //        db.SaveChanges();
            //    }
                return new ResponseModel(department);
            }
        }
    }

