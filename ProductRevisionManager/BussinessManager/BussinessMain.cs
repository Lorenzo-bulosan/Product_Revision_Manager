using System;
using DataAndModels;
using System.Collections.Generic;
using System.Linq;

namespace BussinessManager
{
    public class BussinessMain
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Product Revision Management App");
        }

        public static int Test()
        {
            return 0;
        }

        public void addingLorenzo()
        {
            using (var db = new MonokayuDbContext())
            {
                Console.WriteLine("Creating some customers");
                db.Add(new Customer() { CustomerId = "0", City = "London", ContactName = "Lorenzo", PostalCode = "W3 6hg", Country = "Uk" });
                db.SaveChanges();
            }
        }

        public string TestString()
        {
            return "From inside main";
        }

        public List<Customer> RetrieveAll()
        {
            using (var db = new MonokayuDbContext())
            {
                var res = db.Customers.ToList();
                return res;
            }
        }

    }
}
