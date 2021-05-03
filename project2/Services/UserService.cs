using Project2;
using System;
using System.Data;
using System.Linq;

namespace project2.Services
{
    public class UserService:IUserService
    {
        private readonly ContextDB DB;
        public UserService(ContextDB DB)
        {
            this.DB = DB;
        }
        public string RollingUser7()
        {
            int result=0;
            try
            {
                
                
                
                    var userInstall = DB.Users.Where(x => x.DateRegistration <= DateTime.Now.AddDays(7)).Count();
                    var usersDateRegistr = DB.Users.Where(x => (DateTime.Now - x.DateLastVisit).Days >= 7).Count();
                    int userVisit = Convert.ToInt32(userInstall);
                    int userRegist = Convert.ToInt32(usersDateRegistr);
                    result = (userVisit / userRegist) * (userVisit / userRegist);
                    string rresult= result.ToString();
                    return rresult;
                
                
            }
            catch (DivideByZeroException)
            {
                string err = "Нет пользователей!(возможно нужно добавить больше поьзователей)";
                return err;
            }
            
        }
        public TimeSpan[] GetLiveSpan() 
        {
           
            var userDateReg = DB.Users.Select(u => u.DateLastVisit - u.DateRegistration).ToArray();
            
            return userDateReg;
            
        }

       
    }
}
