using MyAppSLN.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace MyAppSLN.EntityServices.BaseClass
{
    public class BaseClass : TaskResponseHandler
    {
    protected readonly TaskDBEntities _taskDBEntities;
    private string _connectionString = string.Empty;
    public BaseClass()
    {

        _connectionString = WebConfigurationManager.ConnectionStrings["TaskDBEntities"].ConnectionString;
        _taskDBEntities = new TaskDBEntities(_connectionString);
        _taskDBEntities.Tasks.ToList();
    }
}
}
