﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAndModels;

namespace BussinessManager
{
    public class RevisionManager
    {
        
        public static void GenerateUserTestData()
        {
            //using (var db = new MonokayuDbContext())
            //{
            //    Console.WriteLine("Creating some customers");
            //    db.Add(new User() { CustomerId = "1", City = "London", ContactName = "Lorenzo", PostalCode = "W3 6hg", Country = "Uk" });
            //    db.Add(new Project() { CustomerId = "2", City = "London", ContactName = "Lorenzo", PostalCode = "W3 6hg", Country = "Uk" });
            //    db.Add(new Customer() { CustomerId = "3", City = "London", ContactName = "Lorenzo", PostalCode = "W3 6hg", Country = "Uk" });
            //    db.SaveChanges();
            //}
        }

        public static int Test()
        {
            return 0;
        }

        public static void addingTestData()
        {
            using (var db = new MonokayuDbContext())
            {
                Console.WriteLine("Creating some customers");
                db.Add(new Customer() { CustomerId = "1", City = "London", ContactName = "Lorenzo", PostalCode = "W3 6hg", Country = "Uk" });
                db.Add(new Customer() { CustomerId = "2", City = "London", ContactName = "Lorenzo", PostalCode = "W3 6hg", Country = "Uk" });
                db.Add(new Customer() { CustomerId = "3", City = "London", ContactName = "Lorenzo", PostalCode = "W3 6hg", Country = "Uk" });
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