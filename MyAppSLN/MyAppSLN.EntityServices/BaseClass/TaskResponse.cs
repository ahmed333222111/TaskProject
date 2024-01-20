using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyAppSLN.EntityServices.BaseClass
{
    public class TaskResponse<T>
    {
        #region CTOR
        public TaskResponse()
        {

        }
        public TaskResponse(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }
        public TaskResponse(string message)
        {
            Succeeded = false;
            Message = message;
        }
        public TaskResponse(string message, bool succeeded)
        {
            Succeeded = succeeded;
            Message = message;
        }
        #endregion
        #region Prop
        public HttpStatusCode StatusCode { get; set; }
        public object Meta { get; set; }

        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }

        public T Data { get; set; }
        public int? recordsFiltered { get; set; }
        public int? recordsTotal { get; set; }
        #endregion
    }
}
