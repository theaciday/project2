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
        public int[] RollingUser7()
        {
            int [] mass = new int [7];
            for (int i = 0; i <= 7; i++)
            {
                var userInstall = DB.Users.Where(x => x.DateRegistration <= DateTime.Now.AddDays(-i)).Count();
                var usersDateRegistr = DB.Users.Where(x => (DateTime.Now - x.DateLastVisit).Days >= i).Count();
                int userVisit = Convert.ToInt32(userInstall);
                int userRegist = Convert.ToInt32(usersDateRegistr);
                int result = (userVisit / userRegist) * (userVisit / userRegist);
                mass[i] = result;
            } 
            return mass;
                
        }
        public TimeSpan[] GetLiveSpan() 
        {
           
            var userDateReg = DB.Users.Select(u => u.DateLastVisit - u.DateRegistration).ToArray();
            
            return userDateReg;
            
        }

       
    }
}
