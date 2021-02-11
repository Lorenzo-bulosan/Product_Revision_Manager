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
        public static int Login(string name, string surname)
        {
            using (var db = new MonokayuDbContext())
            {
                var userInfo = db.Users2
                     .Where(u => u.firstName == name)
                     .Where(u => u.lastName == surname).FirstOrDefault();

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
