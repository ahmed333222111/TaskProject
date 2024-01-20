using MyAppSLN.EntityServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MyAppSLN.MyWeb.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddTask()
        {
            return View();
        }
        public ActionResult UpdateTask(int id)
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Excel()
        {
            List<Entity.Task> obj = new List<Entity.Task>();
            obj = new TaskManager().GetAll().Data;
            StringBuilder str = new StringBuilder();
            str.Append("<table border=`" + "1px" + "`b>");
            str.Append("<tr>");
            str.Append("<td><b><font face=Arial Narrow size=3>Title</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>Description</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>Assignee</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>DueDate</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>Status</font></b></td>");
            str.Append("</tr>");
            foreach (Entity.Task val in obj)
            {
                str.Append("<tr>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + val.Title.ToString() + "</font></td>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + val.Description.ToString() + "</font></td>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + val.Assignee.ToString() + "</font></td>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + val.DueDate.ToString() + "</font></td>");
                if (val.Status == true)
                {
                    str.Append("<td><font face=Arial Narrow size=" + "14px" + "> مكتمل </font></td>");
                }
                else
                {
                    str.Append("<td><font face=Arial Narrow size=" + "14px" + "> غير مكتمل </font></td>");
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            HttpContext.Response.AddHeader("content-disposition", "attachment; filename=Information" + DateTime.Now.Year.ToString() + ".xls");
            this.Response.ContentType = "application/vnd.ms-excel";
            byte[] temp = System.Text.Encoding.UTF8.GetBytes(str.ToString());
            //SendEmail(temp);
            return File(temp, "application/vnd.ms-excel");
        }

        /*public void SendEmail(byte[] myfile)
        {
            
            // Specify the from and to email address
            MailMessage mailMessage = new MailMessage
                ("task18012024@gmail.com", "ahmedelshahat338@gmail.com");
            mailMessage.Body = "Welcome Task - Body";
            mailMessage.Subject = "Welcome Task - Subject";

            byte[] file = myfile;

            Stream stream = new MemoryStream(file);

            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment(stream,"myFile");
            mailMessage.Attachments.Add(attachment);

            // No need to specify the SMTP settings as these 
            // are already specified in web.config
            SmtpClient smtpClient = new SmtpClient();
            // Finall send the email message using Send() method
            smtpClient.Send(mailMessage);

        }*/
        public ActionResult ExcelById(int id)
        {
            List<Entity.Task> obj = new List<Entity.Task>();
            Entity.Task _singleTask = new TaskManager().GetById(id).Data;
            obj.Add(_singleTask);
            StringBuilder str = new StringBuilder();
            str.Append("<table border=`" + "1px" + "`b>");
            str.Append("<tr>");
            str.Append("<td><b><font face=Arial Narrow size=3>Title</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>Description</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>Assignee</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>DueDate</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>Status</font></b></td>");
            str.Append("</tr>");
            foreach (Entity.Task val in obj)
            {
                str.Append("<tr>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + val.Title.ToString() + "</font></td>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + val.Description.ToString() + "</font></td>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + val.Assignee.ToString() + "</font></td>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + val.DueDate.ToString() + "</font></td>");
                if (val.Status == true)
                {
                    str.Append("<td><font face=Arial Narrow size=" + "14px" + "> مكتمل </font></td>");
                }
                else
                {
                    str.Append("<td><font face=Arial Narrow size=" + "14px" + "> غير مكتمل </font></td>");
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            HttpContext.Response.AddHeader("content-disposition", "attachment; filename=Information" + DateTime.Now.Year.ToString() + ".xls");
            this.Response.ContentType = "application/vnd.ms-excel";
            byte[] temp = System.Text.Encoding.UTF8.GetBytes(str.ToString());
            return File(temp, "application/vnd.ms-excel");
        }
    }
}