using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAppSLN.EntityServices.BaseClass
{
    public class TaskResponseHandler
    {
        #region Function
        public TaskResponse<T> Task_Login<T>(T entity, object Meta = null)
        {
            return new TaskResponse<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = "Login Successfully",
                Meta = Meta
            };
        }
        public TaskResponse<T> Task_NotLogin<T>(T entity, object Meta = null)
        {
            return new TaskResponse<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Succeeded = true,
                Message = "Not Found",
                Meta = Meta
            };
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public TaskResponse<T> Task_Success<T>(T entity, object Meta = null)
        {
            return new TaskResponse<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = "Success",
                Meta = Meta
            };
        }
        public TaskResponse<T> Task_Unauthorized<T>(string Message = null)
        {
            return new TaskResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Succeeded = true,
                Message = Message == null ? "Unauthorized" : Message
            };
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public TaskResponse<T> Task_NotFound<T>(string message = null)
        {
            return new TaskResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message == null ? "NotFound" : message
            };
        }
        public TaskResponse<T> Task_NotFound<T>(T entity, object Meta = null)
        {
            return new TaskResponse<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Succeeded = true,
                Message = "NotFound",
                Meta = Meta
            };
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public TaskResponse<T> Task_BadRequest<T>(T entity, object Meta = null)
        {
            return new TaskResponse<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = "BadRequest",
                Meta = Meta
            };
        }
        public TaskResponse<T> Task_BadRequest<T>(string Message = null)
        {
            return new TaskResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = Message == null ? "BadRequest" : Message
            };
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public TaskResponse<T> Task_Created<T>(T entity, string message, object Meta = null)
        {
            return new TaskResponse<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.Created,
                Succeeded = false,
                Message = message,
                Meta = Meta
            };
        }
        public TaskResponse<T> Task_NotCreated<T>(T entity, string message, object Meta = null)
        {
            return new TaskResponse<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = message,
                Meta = Meta
            };
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public TaskResponse<T> Task_Updated<T>(T entity, string message, object Meta = null)
        {
            return new TaskResponse<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = message,
                Meta = Meta
            };
        }
        public TaskResponse<T> Task_NotUpdated<T>(T entity, string message, object Meta = null)
        {
            return new TaskResponse<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = message,
                Meta = Meta
            };
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public TaskResponse<T> Task_Deleted<T>(T entity, string Message = null)
        {
            return new TaskResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = Message == null ? "Deleted" : Message
            };
        }
        public TaskResponse<T> Task_NotDeleted<T>(T entity, string Message = null)
        {
            return new TaskResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = Message == null ? "Deleted" : Message
            };
        }
        #endregion
    }
}
