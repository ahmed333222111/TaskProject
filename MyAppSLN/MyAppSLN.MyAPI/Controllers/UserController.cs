using MyAppSLN.Entity;
using MyAppSLN.EntityServices;
using MyAppSLN.EntityServices.BaseClass;
using MyAppSLN.MyAPI.Router;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace MyAppSLN.MyAPI.Controllers
{
    public class UserController : ApiController
    {
        #region GetAll
        [Route(TaskRouter.UserRooting.Login)]
        [HttpGet]
        public HttpResponseMessage Login(string userName, string password)
        {
            try
            {
                string authenticationToken = Thread.CurrentPrincipal.Identity.Name;

                return Request.CreateResponse(HttpStatusCode.OK, authenticationToken);
                /*User _usr = new User();
                TaskResponse<bool> RuturnData = new TaskResponse<bool>();
                UserManager userManager = new UserManager();
                string[] dataOfUser = new string[2];
                userManager.Login(userName, password, out _usr, out RuturnData);
                if (RuturnData.Data == true)
                {
                    if (_usr != null)
                    {
                        dataOfUser[0] = _usr.UserName;
                        dataOfUser[1] = _usr.Password;
                        return Ok(dataOfUser);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                return BadRequest();*/
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------
        #endregion
    }
}
