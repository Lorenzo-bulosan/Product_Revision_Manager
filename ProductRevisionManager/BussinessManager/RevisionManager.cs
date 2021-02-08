using System;
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
            using (var db = new MonokayuDbContext())
            {
                Console.WriteLine("Creating some Users");

                db.Add(new User() { firstName = "Lorenzo0", lastName = "Bulosan", securityLevel = 0, password = "12345678" });
                db.Add(new User() { firstName = "Angel", lastName = "Hidalgo", securityLevel = 1, password = "12345678" });
                db.Add(new User() { firstName = "Taner", lastName = "Cagali", securityLevel = 1, password = "12345678" });

                db.SaveChanges();
            }
        }

        public static void GenerateProjectTestData()
        {
            using (var db = new MonokayuDbContext())
            {
                Console.WriteLine("Creating some projects");

                db.Add(new Project() { projectName = "project1", UserID = 13 });
                db.Add(new Project() { projectName = "project2", UserID = 14 });
                db.Add(new Project() { projectName = "project3", UserID = 14 }); 
                db.SaveChanges();
            }
        }

        public static void GenerateRevisionForProjectID(int projectId)
        {
            using (var db = new MonokayuDbContext())
            {
                Console.WriteLine($"Creating some Revision for projectID: {projectId}");
                db.Add(new Revision() { deadline = new DateTime(), ProjectID = projectId });
                db.SaveChanges();
            }
        }

        public static void GetUsersAndTheirProjects()
        {
            using (var db = new MonokayuDbContext())
            {
                Console.WriteLine("\nRetrieving all users and their projects");
                var userProjectsQuery = 
                    db.Users
                    .Join(
                        db.Projects ,
                        u => u.UserID,
                        p => p.UserID,
                        (u, p) => new {p, u}
                    );

                foreach (var item in userProjectsQuery)
                {
                    Console.WriteLine($"Users {item.u.firstName} of ID: {item.u.UserID}");
                    Console.WriteLine($"Projects of this user: {item.p.projectName}");
                }
            }
        }

        public static void GetProjectInfoFromUserID(int id)
        {
            using (var db = new MonokayuDbContext())
            {
                Console.WriteLine("\nRetrieving some specific data");
                var userProjectQuery =
                    db.Users
                    .Join(
                        db.Projects,
                        u => u.UserID,
                        p => p.UserID,
                        (u, p) => new { p, u }
                    ).Where(user => user.u.UserID == id);

                foreach (var userProject in userProjectQuery)
                {
                    Console.WriteLine($"user {userProject.u.UserID} has these projects {userProject.p.projectName}");
                }
            }
        }

        public static void GetProjectsAndTheirRevisionsFromUsers()
        {
            using (var db = new MonokayuDbContext())
            {
                Console.WriteLine("\nRetrieving all users and their projects");
                var projectRevisionQuery =
                    db.Users
                    .Join(
                        db.Projects,
                        u => u.UserID,
                        p => p.UserID,
                        (u, p) => new { p, u }
                    ).Join(
                        db.Revisions,
                        u => u.p.ProjectID,
                        rr => rr.ProjectID,
                        (rr, u) => new { u, rr }
                    );

                foreach (var item in projectRevisionQuery)
                {
                    Console.WriteLine($"Users {item.rr.u.firstName} of ID: {item.rr.u.UserID}");
                    Console.WriteLine($"Projects of this user: {item.rr.p.ProjectID}");
                    Console.WriteLine($"Revisions in this project: {item.u.RevisionID} with deadline {item.u.deadline}");
                }
            }
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
