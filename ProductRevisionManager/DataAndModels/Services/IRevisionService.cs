using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndModels.Services
{
    public interface IRevisionService
    {
        public User2 GetUser(int userID);
        public Dictionary<int, string> GetProjectsFromUserID(int userID);
        public void GenerateRevisionForProjectID(int projectId, DateTime deadline);
        public Dictionary<int, DateTime> GetRevisionsFromProject(int projectID);
        public void AddTaskToRevision(int revisionID, string title, string description, int urgency, int progress = 0, string url = "");
        public List<RevisionTask> GetTasksFromRevisionID(int revisionId);
        public void UpdateRevisionTask(int taskID, string title, string description, int urgency, int progress, string url);
        public void AddCommentToTaskID(int taskID, string comment, string senderName);
        public List<TaskComment> RetrieveCommentsFromTaskID(int taskID);
        public IEnumerable<Object> RetrieveCommentsOfTaskFromUser(int userID, int taskId);
    }
}
