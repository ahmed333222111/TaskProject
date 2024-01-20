using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAppSLN.MyAPI.Router
{
    public class TaskRouter
    {
        public const string root = "ApplicationTask/";
        public const string list = "List";
        public const string id = "{id}";
        public const string maxId = "max";
        public const string create = "Create";
        public const string edit = "Edit";
        public const string delete = "Delete/";
        public const string getMax = "GetMax";
        public const string paginated = "Paginated";
        public const string search = "Search/";
        public const string login = "Login/";
        public const string excel = "Excel";
        //------------------------------------------------------------------------------------------------------------------------
        public static class TaskRooting
        {
            public const string Prefix = root + "Task/";
            public const string Paginated = Prefix + paginated;
            public const string List = Prefix + list;
            public const string GetById = Prefix + id;
            public const string GetMaxId = Prefix + getMax;
            public const string Create = Prefix + create;
            public const string Edit = Prefix + edit;
            public const string Delete = Prefix + delete + id;
            public const string Search = Prefix + search;
        }
        //------------------------------------------------------------------------------------------------------------------------
        public static class UserRooting
        {
            public const string Prefix = root + "User/";
            public const string Login = Prefix + login;
        }
        //------------------------------------------------------------------------------------------------------------------------
        public static class ExportDataRooting
        {
            public const string Prefix = root + "ExportData/";
            public const string Excel = Prefix + excel  ;
        }
        //------------------------------------------------------------------------------------------------------------------------
    }
}