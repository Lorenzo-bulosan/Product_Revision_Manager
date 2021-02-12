using System;
using BussinessManager;
using DataAndModels;
using System.Linq;

namespace UnitTests
{
    class MethodsForTesting
    {
        // methods for testing
        public static void GenerateRevisionForProjectID(int projectId)
        {
            using (var db = new MonokayuDbContext())
            {
                Console.WriteLine($"Creating some Revision for projectID: {projectId}");
                db.Add(new Revision() { deadline = new DateTime(), ProjectID = projectId });
                db.SaveChanges();
            }
        }

        public static void DeleteTestData()
        {
            using (var db = new MonokayuDbContext())
            {
                var user = db.Users2.Where(u => u.firstName == "PersonNameTest").Where(u => u.lastName == "PersonLastNameTest");
                var project = db.Projects2.Where(p => p.projectName == "ProjectNameForTesting");
                if (user != null || project != null) return;

                db.Users2.RemoveRange(user);

                db.SaveChanges();
            }
        }

        public (int userIdToTest, int projectIdToTest) GenerateTestDataForUnitTests()
        {

            Console.WriteLine("Generating test data");

            using (var db = new MonokayuDbContext())
            {
                // query first if exist
                //var user = db.Users2.Where(u => u.firstName == "PersonNameTest").Where(u => u.lastName == "PersonLastNameTest").FirstOrDefault();
                //var project = db.Projects2.Where(p => p.projectName == "ProjectNameForTesting").FirstOrDefault();

                //// if exist
                //if (user != null || project != null)
                //{
                //    return (user.UserID, project.ProjectID);
                //}
                //else
                //{
                    // create user and project to test
                    db.Add(new User2() { firstName = "PersonNameTest", lastName = "PersonLastNameTest", securityLevel = 0, password = "12345" });
                    db.Add(new Project2 { projectName = "ProjectNameForTesting" });

                    // locate data and obtain ids
                    int userID = db.Users2.Where(u => u.firstName == "PersonNameTest").Where(u => u.lastName == "PersonLastNameTest").FirstOrDefault().UserID;
                    int projectID = db.Projects2.Where(p => p.projectName == "ProjectNameForTesting").FirstOrDefault().ProjectID;

                    // assign users to project
                    db.Add(new UserProject { userID = userID, projectID = projectID });

                    //save and return
                    db.SaveChanges();
                    return (userID, projectID);
                //return (user.UserID, project.ProjectID);
                //}
            }
        } // end of GenerateTestData()
    }
}
