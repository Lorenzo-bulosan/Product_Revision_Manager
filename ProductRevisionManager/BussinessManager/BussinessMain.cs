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

            /* Generates user, project */
            GenerateUserTestData();
            GenerateProjectTestData();
            AssignUsersToProjects();
        }

        public static void GenerateUserTestData()
        {
            using (var db = new MonokayuDbContext())
            {
                Console.WriteLine("Creating some Users");

                db.Add(new User2() { firstName = "Lorenzo", lastName = "Bulosan", securityLevel = 0, password = "12345" });
                db.Add(new User2() { firstName = "Cathy", lastName = "French", securityLevel = 1, password = "12345" });
                db.Add(new User2() { firstName = "Martin", lastName = "Beard", securityLevel = 1, password = "12345" });

                db.SaveChanges();
            }
        }

        public static void GenerateProjectTestData()
        {
            using (var db = new MonokayuDbContext())
            {
                Console.WriteLine("Creating some projects");

                db.Add(new Project2 { projectName = "Calculator" });
                db.Add(new Project2 { projectName = "Radio" });
                db.Add(new Project2 { projectName = "Revision Manager" });

                db.SaveChanges();
            }
        }

        public static void AssignUsersToProjects()
        {
            using (var db = new MonokayuDbContext())
            {
                // locating test data ids
                var LorenzoID = db.Users2.Where(u => u.firstName == "Lorenzo").Where(u => u.lastName == "Bulosan").FirstOrDefault().UserID;
                var CathyID = db.Users2.Where(u => u.firstName == "Cathy").Where(u => u.lastName == "French").FirstOrDefault().UserID;
                var MartinID = db.Users2.Where(u => u.firstName == "Martin").Where(u => u.lastName == "Beard").FirstOrDefault().UserID;
                
                var Project1ID = db.Projects2.Where(p => p.projectName == "Calculator").FirstOrDefault().ProjectID;
                var Project2ID = db.Projects2.Where(p => p.projectName == "Radio").FirstOrDefault().ProjectID;
                var Project3ID = db.Projects2.Where(p => p.projectName == "Revision Manager").FirstOrDefault().ProjectID;

                // assigning users to projects (many to many)
                // lorenzo -> project1/project3
                // cathy -> project1/project2
                // martin -> project3

                db.Add(new UserProject { userID = LorenzoID, projectID = Project1ID});
                db.Add(new UserProject { userID = LorenzoID, projectID = Project3ID });
                db.Add(new UserProject { userID = CathyID, projectID = Project1ID });
                db.Add(new UserProject { userID = CathyID, projectID = Project2ID });
                db.Add(new UserProject { userID = MartinID, projectID = Project3ID });

                db.SaveChanges();
            }
            
        }

    }
}
