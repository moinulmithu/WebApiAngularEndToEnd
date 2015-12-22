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
            List<Trainee> trainees =
                db.Trainees.AsEnumerable()
                    .Select(
                        x =>
                            new Trainee()
                            {
                                Id = x.Id,
                                Name = x.Name,
                                Phone = x.Phone,
                                DepartmentId = x.DepartmentId,
                                Department = new Department() { Id = x.Department.Id, Dept_Name = x.Department.Dept_Name }
                            })
                    .ToList();
            return new ResponseModel(trainees);
        }

        public ResponseModel Get(int id)
        {
            VTraineesDBEntitiesOne db = new VTraineesDBEntitiesOne();
            ResponseModel response;
            Trainee x = db.Trainees.Find(id);
            if (x != null)
            {
                Trainee trainee = new Trainee()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Phone = x.Phone,
                    DepartmentId = x.DepartmentId,
                    Department = new Department() {Id = x.Department.Id, Dept_Name = x.Department.Dept_Name}
                };
                response = new ResponseModel(trainee);
            }
            else
            {
                response = new ResponseModel(isSuccess:false,message:"Trainee not found");
            }
            return response;
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

        public ResponseModel Delete(int id)
        {
            ResponseModel response;
            if (id != 0)
            {
                VTraineesDBEntitiesOne db = new VTraineesDBEntitiesOne();
                db.Trainees.Remove(db.Trainees.Find(id));
                db.SaveChanges();
                return new ResponseModel();
            }
            else
            {
                response = new ResponseModel(isSuccess:false,message:"Trainee not found");
            }
            return response;
        }
    }
}
