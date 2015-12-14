using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTraineesApi.Models
{
    public class ResponseModel
    {
        public ResponseModel(object data = null, bool isSuccess = true, string message = "Success")
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
        }

        public object Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
