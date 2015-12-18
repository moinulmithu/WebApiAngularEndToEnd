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
    public class TraineeController : ApiController
    {
        public ResponseModel Get()
        {
            VTraineesDBEntitiesOne db = new VTraineesDBEntitiesOne();
            var Trainees =
                db.Trainees.AsEnumerable()
                    .Select(
                        x => new Trainee() { Id = x.Id, Name = x.Name, Phone = x.Phone, DepartmentId = x.DepartmentId })
                    .ToList();
            return new ResponseModel(Trainees);
        }
        public ResponseModel Post(Trainee trainee)
        {
            using (VTraineesDBEntitiesOne db = new VTraineesDBEntitiesOne())
            {
                bool isNotNull = trainee != null;
                if (isNotNull)
                {
                    
                    if (trainee.Id != 0)
                    {
                        trainee.Department = null;
                        db.Entry(trainee).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Trainees.Add(trainee);
                    }
                    db.SaveChanges();
                }
                return new ResponseModel(isSuccess: isNotNull);
            }
            
        }
    }
}
