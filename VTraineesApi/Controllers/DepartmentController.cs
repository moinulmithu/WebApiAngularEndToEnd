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
        //public ResponseModel Get()
        //{
        //    VTraineesDBEntitiesOne db = new VTraineesDBEntitiesOne();
        //    var departments =
        //        db.Departments.AsEnumerable()
        //            .Select(x => new Department() {Id = x.Id, Dept_Name = x.Dept_Name }).ToList();
        //    return new ResponseModel(departments);
        //}
        public ResponseModel Get()
        {
            VTraineesDBEntitiesOne db = new VTraineesDBEntitiesOne();
            List<Department> departments =
                db.Departments.AsEnumerable()
                    .Select(x => new Department() {Id = x.Id, Dept_Name = x.Dept_Name})
                    .ToList();
            return new ResponseModel(departments);
        }

        public ResponseModel Get(int id)
        {
            VTraineesDBEntitiesOne db = new VTraineesDBEntitiesOne();
            ResponseModel responseModel;
            Department d = db.Departments.Find(id);
            if (d != null)
            {
                Department department = new Department()
                {
                    Id = d.Id,
                    Dept_Name = d.Dept_Name
                };
                responseModel = new ResponseModel(department);
            }
            else
            {
                responseModel = new ResponseModel(isSuccess:false, message: "Department not found");
            }
            return responseModel;
        }

        public ResponseModel Post(Department department)
        {
            using (VTraineesDBEntitiesOne db = new VTraineesDBEntitiesOne())
            {
                bool isNotNull = department != null;
                if (isNotNull)
                {
                    if (department.Id != 0)
                    {
                        department.Trainees = null;
                        db.Entry(department).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Departments.Add(department);
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
                db.Departments.Remove(db.Departments.Find(id));
                db.SaveChanges();
                return new ResponseModel();
            }
            else
            {
                response = new ResponseModel(isSuccess:false, message:"Department not found");
            }
            return response;
            
        }
    }
}

