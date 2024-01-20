using MyAppSLN.Entity;
using MyAppSLN.EntityServices;
using MyAppSLN.MyAPI.Router;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Security.Policy;
using System.Text;
using System.Web.Http;

namespace MyAppSLN.MyAPI.Controllers
{
    public class TaskController : ApiController
    {
        #region Get
        #region GetAll
        [Route(TaskRouter.TaskRooting.List)]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                return Ok(new TaskManager().GetAll().Data);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------
        #endregion
        #region GetById
        [Route(TaskRouter.TaskRooting.GetById)]
        [HttpGet]
        public IHttpActionResult GetById([FromUri] int id)
        {
            try
            {
                return Ok(new TaskManager().GetById(id).Data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------
        #endregion
        #region GetMaxId
        [Route(TaskRouter.TaskRooting.GetMaxId)]
        [HttpGet]
        public IHttpActionResult GetMaxId()
        {
            try
            {
                return Ok(new TaskManager().GetMaxId());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------
        #endregion
        #endregion
        #region Operations
        #region Create
        [Route(TaskRouter.TaskRooting.Create)]
        public IHttpActionResult Post(Entity.Task task)
        {
            try
            {
                SendEmail();
                return Ok(new TaskManager().Insert(task));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------
        #endregion
        #region Put
        [Route(TaskRouter.TaskRooting.Edit)]
        public IHttpActionResult Put([FromBody] Task task)
        {
            try
            {
                return Ok(new TaskManager().Update(task));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------
        #endregion
        #region Delete
        [Route(TaskRouter.TaskRooting.Delete)]
        public IHttpActionResult Delete([FromUri] int id)
        {
            try
            {
                return Ok(new TaskManager().Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------
        #endregion
        #endregion

        public void SendEmail()
        {

            // Specify the from and to email address
            MailMessage mailMessage = new MailMessage
                ("task18012024@gmail.com", "ahmedelshahat338@gmail.com");
            mailMessage.Body = "Welcome Task - Body";
            mailMessage.Subject = "Welcome Task - Subject";

            // No need to specify the SMTP settings as these 
            // are already specified in web.config
            SmtpClient smtpClient = new SmtpClient();
            // Finall send the email message using Send() method
            smtpClient.Send(mailMessage);

        }
    }
}
