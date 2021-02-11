using NUnit.Framework;
using BussinessManager;
using DataAndModels;
using System.Linq;
using System;
using Microsoft.Data.SqlClient;

namespace UnitTests
{
    public class Tests
    {
        RevisionManager _revisionManager;
        private int _userIdToTest = 99999;
        private int _revisionIdToTest = 99999;
        private int _projectIdToTest = 99999;

        [SetUp]
        public void Setup()
        {
            // instantiate
            _revisionManager = new RevisionManager();

            // remove test entry in DB if present
            using (var db = new MonokayuDbContext())
            {
                var selectedUsers =
                from u in db.Users2
                where u.UserID == _userIdToTest
                select u;

                db.Users2.RemoveRange(selectedUsers);
                db.SaveChanges();
            }

        }

        [Test]
        public void AddingAtaskToArevisionIncreasesNumberOfTasksByOne_WITHINSERTONOFF()
        {

            // to be able to insert your own id

            //"Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Monokayu; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            //using (var command = new SqlCommand
            //    (
            //        "SET IDENTITY_INSERT dbo.Users OFF",
            //        connection
            //    )
            //)
            //{
            //    int affected = command.ExecuteNonQuery();
            //}

            // create test data
            using (var db = new MonokayuDbContext())
            {
                // Generate test user
                db.Add(new User() { UserID = _userIdToTest, firstName = "Lorenzo0", lastName = "Bulosan", securityLevel = 0, password = "12345678" });
                // Generate project for user
                db.Add(new Project() { ProjectID = _projectIdToTest, projectName = "project1", UserID = _userIdToTest });
                // Generate Revision for project
                db.Add(new Revision() { RevisionID = _revisionIdToTest, deadline = new DateTime(), ProjectID = _projectIdToTest });

                db.SaveChanges();
            }

            // to be able to insert your own id
            //using (var command = new SqlCommand
            //    (
            //        "SET IDENTITY_INSERT dbo.Users ON",
            //        connection
            //    )
            //)
            //{
            //    int affected = command.ExecuteNonQuery();
            //}

            // testing
            using (var db = new MonokayuDbContext())
            {
                var numberOfTasksBefore = db.RevisionTasks.Count();
                _revisionManager.AddTaskToRevision(_revisionIdToTest, "Testing title", "Description test", 3, 0, "empty url");
                var numberOfTasksAfter = db.RevisionTasks.Count();

                Assert.AreEqual(numberOfTasksBefore + 1, numberOfTasksAfter);
            }
        }

        [TestCase(5, "Testing title", "Description test", 3, 0, "empty url")]
        [TestCase(6, "in revision 6", "Description test", 3, 0, "empty url")]
        [TestCase(7, "in revision 7", "Description test", 3, 0, "empty url")]
        public void AddingAtaskToArevisionIncreasesNumberOfTasksByOne(int revisionID, string title, string description, int urgency, int progress, string url)
        {

            // known project id, also that this will result in revision id 5
            //GenerateRevisionForProjectID(9);

            // testing
            using (var db = new MonokayuDbContext())
            {
                var numberOfTasksBefore = db.RevisionTasks.Count();
                _revisionManager.AddTaskToRevision(revisionID, title, description, urgency, progress, url);
                var numberOfTasksAfter = db.RevisionTasks.Count();

                Assert.AreEqual(numberOfTasksBefore + 1, numberOfTasksAfter);
            }
        }

        [TestCase(14, "UNCHANGED","description",1,1,"url","CHANGED", "CHANGED")]
        [TestCase(15, "UNCHANGED", "description", 1, 1, "url", "CHANGED", "CHANGED")]
        [TestCase(16, "UNCHANGED", "description", 1, 1, "url", "CHANGED", "CHANGED")]
        public void UpdatingTaskRowsCorrectly(int taskID, string title, string description, int urgency, int progress, string url, string knownAnswer, string editTitle)
        {

            // update
            _revisionManager.UpdateRevisionTask(taskID, editTitle, description, urgency, progress, url);

            // testing
            using (var db = new MonokayuDbContext())
            {
                var information = db.RevisionTasks.Where(r => r.TaskID == taskID).FirstOrDefault();
                Assert.AreEqual(knownAnswer, information.title);
            }

            // change back
            _revisionManager.UpdateRevisionTask(taskID, title, description, urgency, progress, url);
        }

        [TearDown]
        public void TearDown()
        {
            // remove test entry in DB if present
            using (var db = new MonokayuDbContext())
            {
                var selectedUsers =
                from u in db.Users2
                where u.UserID == _userIdToTest
                select u;

                db.Users2.RemoveRange(selectedUsers);
                db.SaveChanges();
            }
        }

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
    }
}