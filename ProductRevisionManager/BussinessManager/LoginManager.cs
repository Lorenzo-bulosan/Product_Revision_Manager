using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAndModels;
using Microsoft.EntityFrameworkCore;

namespace BussinessManager
{
    public class LoginManager
    {
        public static int Login(string name, string surname, string password)
        {
            using (var db = new MonokayuDbContext())
            {
                var userInfo = db.Users2
                     .Where(u => u.firstName == name)
                     .Where(u => u.lastName == surname)
                     .Where(u=> u.password == password)
                     .FirstOrDefault();
                     

                if (userInfo != null)
                {
                    return userInfo.UserID;
                }
                else 
                {
                    throw new ArgumentException("No user found! Make sure your details are correct"); 
                }
                
            }
        }
    }
}
