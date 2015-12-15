using System;
using System.Collections.Generic;
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
    }
}
