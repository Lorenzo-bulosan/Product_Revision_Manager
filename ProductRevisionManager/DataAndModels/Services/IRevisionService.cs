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
        public Project2 GetProjectFromUser(int userID);
        
        public void AddRevisionToProject();
        public void GetRevisionFromProject();
        public void AddTaskToRevision();
        public List<RevisionTask> GetTaskFromRevision();
        public void UpdateTask();
        public void AddCommentToTask();
        public List<TaskComment> RetrieveCommentsFromUser();
        public void SaveRevisionChanges();

    }
}
