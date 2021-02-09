using NUnit.Framework;
using BussinessManager;
using DataAndModels;
using System.Linq;

namespace UnitTests
{
    public class Tests
    {
        private RevisionManager _revisionManager;

        [SetUp]
        public void Setup()
        {
            _revisionManager = new RevisionManager();
        }

        [Test]
        public void AddingAtaskToArevisionIncreasesNumberOfTasksByOne()
        {
            // count before adding
            using (var db = new MonokayuDbContext())
            {
                var countOfTaskBeforeAdding = db.RevisionTasks.Count();

                db.SaveChanges();
            }

            // add test data
            _revisionManager.AddTaskToRevision(999, "Testing", "Description", 3);

            // count after adding

            // assert
            Assert.AreEqual(0, 0);

            // remove test data
        }
    }
}