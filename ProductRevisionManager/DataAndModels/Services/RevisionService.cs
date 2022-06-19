using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndModels.Services
{
    public class RevisionService : IRevisionService
    {
        private readonly MonokayuDbContext _db;

        public RevisionService()
        {
            _db = new MonokayuDbContext();
        }

        public void AddCommentToTaskID(int taskID, string comment, string senderName)
        {
            throw new NotImplementedException();
        }

        public void AddTaskToRevision(int revisionID, string title, string description, int urgency, int progress = 0, string url = "")
        {
            throw new NotImplementedException();
        }

        public void GenerateRevisionForProjectID(int projectId, DateTime deadline)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, string> GetProjectsFromUserID(int userID)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, DateTime> GetRevisionsFromProject(int projectID)
        {
            throw new NotImplementedException();
        }

        public List<RevisionTask> GetTasksFromRevisionID(int revisionId)
        {
            throw new NotImplementedException();
        }

        public User2 GetUser(int userID)
        {
            return _db.Users2.Where(c => c.UserID == userID).FirstOrDefault();
        }

        public List<TaskComment> RetrieveCommentsFromTaskID(int taskID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> RetrieveCommentsOfTaskFromUser(int userID, int taskId)
        {
            throw new NotImplementedException();
        }

        public void UpdateRevisionTask(int taskID, string title, string description, int urgency, int progress, string url)
        {
            throw new NotImplementedException();
        }
    }
}
