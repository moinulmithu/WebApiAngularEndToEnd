using System;
using System.Collections.Generic;
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
        public ResponseModel Post(Trainee trainee)
        {
            return new ResponseModel(trainee);
        }
    }
}
