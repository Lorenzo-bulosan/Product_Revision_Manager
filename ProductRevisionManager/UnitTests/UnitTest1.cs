using NUnit.Framework;
using BussinessManager;
using DataAndModels;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace UnitTests
{
    public class BussinessManagerTests
    {
        RevisionManager _revisionManager;
        MethodsForTesting _testMethods;
        private int _userIdToTest;
        private int _revisionIdToTest;
        private int _projectIdToTest;

        [SetUp]
        public void Setup()
        {
            // instantiate
            _revisionManager = new RevisionManager();

            // Create User and Project Test Data
            using (var db = new MonokayuDbContext())
            {
                // create user and project to test
                db.Add(new User2() { firstName = "PersonNameTest", lastName = "PersonLastNameTest", securityLevel = 0, password = "12345" });
                db.Add(new Project2() { projectName = "ProjectNameForTesting" });
                
                db.SaveChanges();
            }

            // Set global variables
            using (var db = new MonokayuDbContext())
            {
                // locate data and obtain ids
                var userID = db.Users2.Where(u => u.firstName == "PersonNameTest").Where(c => c.lastName == "PersonLastNameTest").FirstOrDefault().UserID;
                var projectID = db.Projects2.Where(p => p.projectName == "ProjectNameForTesting").FirstOrDefault().ProjectID;

                // assign users to project using joining table
                db.Add(new UserProject() { userID = userID, projectID = projectID });

                _userIdToTest = userID;
                _projectIdToTest = projectID;
                db.SaveChanges();
            }

            //using (var db = new MonokayuDbContext())
            //{
            //    db.Add(new Revision() { ProjectID = _projectIdToTest, deadline = DateTime.Now });
            //    db.SaveChanges();
            //}
        }

        [Test]
        public void GettingAllProjectsFromTestUserReturnsOne()
        {
            var count = _revisionManager.GetProjectsFromUserID(_userIdToTest).Count();
            Assert.AreEqual(count, 1);
        }

        [Test]
        public void QueryUserTestDataNameReturnsKnownString()
        {
            var user = _revisionManager.GetUserInformationFromUserID(_userIdToTest);
            Assert.AreEqual(user.firstName, "PersonNameTest");
        }

        [Test]
        public void QueryUserTestDataPasswordReturnsKnownString()
        {
            var user = _revisionManager.GetUserInformationFromUserID(_userIdToTest);
            Assert.AreEqual(user.password, "12345");
        }

        [Test]
        public void AddingRevisionIncreasesCountByOne()
        {
            using (var db = new MonokayuDbContext())
            {
                DateTime deadline = DateTime.Now;
                int countBefore = db.Revisions.Where(r => r.ProjectID == _projectIdToTest).Count();
                _revisionManager.GenerateRevisionForProjectID(_projectIdToTest, deadline);
                int countAfter = db.Revisions.Where(r => r.ProjectID == _projectIdToTest).Count();

                Assert.AreEqual(countAfter,countBefore+1);
            }
        }

        [Test]
        public void RetrivingRevisionFromProjectThatDoesNotExistReturnsEmpty()
        {
            var revisions = _revisionManager.GetRevisionsFromProject(_projectIdToTest);
            Assert.AreEqual(revisions.Count(), 0);
        }

        [Test]
        public void RetrivingRevisionFromProjectReturnsOneMoreThanBeforeWhenAddingOneRevision()
        {
            var revisions = _revisionManager.GetRevisionsFromProject(_projectIdToTest);
            
            using (var db = new MonokayuDbContext())
            {
                db.Add(new Revision() { deadline = DateTime.Now, ProjectID = _projectIdToTest });
                db.SaveChanges(); 
            }

            var revisionsAfter = _revisionManager.GetRevisionsFromProject(_projectIdToTest);

            Assert.AreEqual(revisions.Count()+1, revisionsAfter.Count());
        }

        [Test]
        public void AddingAtaskToArevisionIncreasesNumberOfTasksByOne_()
        {
            // generate revision first and get id
            _revisionManager.GenerateRevisionForProjectID(_projectIdToTest, DateTime.Now);
            Dictionary<int, DateTime> revisionInfo = (Dictionary<int, DateTime>)_revisionManager.GetRevisionsFromProject(_projectIdToTest);
            int revisionId = revisionInfo.FirstOrDefault().Key;

            // now add task to revision
            using (var db = new MonokayuDbContext())
            {
                _revisionManager.AddTaskToRevision(revisionId, "Title test", "Description Test", 0, 1, "monokayu.com");
                int countBefore = db.RevisionTasks.Where(r => r.RevisionID == revisionId).Count();
                _revisionManager.AddTaskToRevision(revisionId, "Title test", "Description Test", 0, 1, "monokayu.com");
                int countAfter = db.RevisionTasks.Where(r => r.RevisionID == revisionId).Count();

                Assert.AreEqual(countBefore+1, countAfter);
            }
        }

        [Test]
        [TestCase ("Title test", "Description Test", 0, 1, "monokayu.com", "Title test")]
        [TestCase ("Title test1", "Description Test", 0, 1, "monokayu.com", "Title test1")]
        [TestCase ("Title test2", "Description Test", 0, 1, "monokayu.com", "Title test2")]
        public void WhenRetrievingTaskFromRevissionAndAskingForTitleReturnsCorrectAnswer(string title, string description, int urgency, int progress, string url, string correctTitle)
        {
            // generate revision first and get id
            _revisionManager.GenerateRevisionForProjectID(_projectIdToTest, DateTime.Now);
            Dictionary<int, DateTime> revisionInfo = (Dictionary<int, DateTime>)_revisionManager.GetRevisionsFromProject(_projectIdToTest);
            int revisionId = revisionInfo.FirstOrDefault().Key;

            // generate task for testing
            _revisionManager.AddTaskToRevision(revisionId, title, description, urgency, progress, url);

            // retrieve the task information and assert
            var taskFromRevision = _revisionManager.GetTasksFromRevisionID(revisionId).FirstOrDefault();
            Assert.AreEqual(taskFromRevision.title, correctTitle);
        }

        [Test]
        [TestCase("Original", "UpdatedTitle", "UpdatedTitle")]
        [TestCase("Original123", "UpdatedTitle", "UpdatedTitle")]
        public void WhenUpdatingTaskCheckThatItIsCorrectlyUpdated(string title, string titleUpdated,string correctTitle)
        {
            // generate revision first and get id
            _revisionManager.GenerateRevisionForProjectID(_projectIdToTest, DateTime.Now);
            Dictionary<int, DateTime> revisionInfo = (Dictionary<int, DateTime>)_revisionManager.GetRevisionsFromProject(_projectIdToTest);
            int revisionId = revisionInfo.FirstOrDefault().Key;

            // generate task for testing
            _revisionManager.AddTaskToRevision(revisionId, title, "description", 0, 1, "google");
            int taskID = _revisionManager.GetTasksFromRevisionID(revisionId).FirstOrDefault().TaskID;

            // update the task with new title and assert
            _revisionManager.UpdateRevisionTask(taskID, titleUpdated, "description", 0, 1, "google");
            string resultTitle = _revisionManager.GetTasksFromRevisionID(revisionId).FirstOrDefault().title;

            Assert.AreEqual(resultTitle, correctTitle);
        }

        [Test]
        public void WhenAddingCommentToTaskCountByOne()
        {
            // generate revision first and get id
            _revisionManager.GenerateRevisionForProjectID(_projectIdToTest, DateTime.Now);
            Dictionary<int, DateTime> revisionInfo = (Dictionary<int, DateTime>)_revisionManager.GetRevisionsFromProject(_projectIdToTest);
            int revisionId = revisionInfo.FirstOrDefault().Key;

            // generate task for testing
            _revisionManager.AddTaskToRevision(revisionId, "title", "description", 0, 1, "google");
            int taskID = _revisionManager.GetTasksFromRevisionID(revisionId).FirstOrDefault().TaskID;

            // add comment and count before and after
            using (var db = new MonokayuDbContext())
            {
                var countBefore = db.TaskComments.Where(c => c.TaskID == taskID).Count();                
                _revisionManager.AddCommentToTaskID(taskID, "Test comment", "LB");
                var countAfter = db.TaskComments.Where(c => c.TaskID == taskID).Count();

                Assert.AreEqual(countAfter, countBefore+1);
            }
        }

        [Test]
        public void WhenRetrievingACommentMakeReturnsCorrectInformation()
        {
            // generate revision first and get id
            _revisionManager.GenerateRevisionForProjectID(_projectIdToTest, DateTime.Now);
            Dictionary<int, DateTime> revisionInfo = (Dictionary<int, DateTime>)_revisionManager.GetRevisionsFromProject(_projectIdToTest);
            int revisionId = revisionInfo.FirstOrDefault().Key;

            // generate task for testing
            _revisionManager.AddTaskToRevision(revisionId, "title", "description", 0, 1, "google");
            int taskID = _revisionManager.GetTasksFromRevisionID(revisionId).FirstOrDefault().TaskID;

            // add comment to test
            _revisionManager.AddCommentToTaskID(taskID, "Test comment", "LB");

            // query comment
            var comment = _revisionManager.RetrieveCommentsFromTaskID(taskID).FirstOrDefault();
            Assert.AreEqual(comment.comment, "Test comment");
        }

        [TearDown]
        public void TearDown()
        {
            // remove test entry in DB if present

            using (var db = new MonokayuDbContext())
            {
                var users = db.Users2.Where(u => u.firstName == "PersonNameTest").Where(u => u.lastName == "PersonLastNameTest");
                db.Users2.RemoveRange(users);

                var projects = db.Projects2.Where(p => p.projectName == "ProjectNameForTesting");
                db.Projects2.RemoveRange(projects);

                db.SaveChanges();
            }
        }
    } // end of class
} // end of namespace
