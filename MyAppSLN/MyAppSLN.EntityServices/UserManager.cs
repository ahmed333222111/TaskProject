using MyAppSLN.Entity;
using MyAppSLN.EntityServices.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAppSLN.EntityServices
{
    public class UserManager : BaseClass.BaseClass
    {
        public void Login(string email, string password, out User result, out TaskResponse<bool> returnData)
        {
            try
            {
                result = _taskDBEntities.Users.FirstOrDefault(e => e.UserName.Equals(email, StringComparison.OrdinalIgnoreCase) && e.Password == password);
                if (result != null)
                {
                    returnData = Task_Login<bool>(true);
                }
                else
                {
                    returnData = Task_Login<bool>(false);
                }
            }
            catch (Exception)
            {
                result = null;
                returnData = Task_NotFound<bool>();
            }
        }

        public TaskResponse<bool>  Login(string email, string password)
        {
            try
            {
                User result = _taskDBEntities.Users.FirstOrDefault(e => e.UserName.Equals(email, StringComparison.OrdinalIgnoreCase) && e.Password == password);
                if (result != null)
                {
                    return Task_Login<bool>(true);
                }
                else
                {
                    return Task_Login<bool>(false);
                }
            }
            catch (Exception)
            {
                return Task_NotFound<bool>();
            }
        }
    }
}
