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

        public User2 GetUser(int userID)
        {
            return _db.Users2.Where(c => c.UserID == userID).FirstOrDefault();
        }

        public Project2 GetProjectFromUser(int userID)
        {
            throw new NotImplementedException();
        }

        public void AddRevisionToProject()
        {
            throw new NotImplementedException();
        }
        public void GetRevisionFromProject()
        {
            throw new NotImplementedException();
        }

        public void AddTaskToRevision()
        {
            throw new NotImplementedException();
        }

        public List<RevisionTask> GetTaskFromRevision()
        {
            throw new NotImplementedException();
        }

        public void UpdateTask()
        {
            throw new NotImplementedException();
        }

        public void AddCommentToTask()
        {
            throw new NotImplementedException();
        }

        public List<TaskComment> RetrieveCommentsFromUser()
        {
            throw new NotImplementedException();
        }
        public void SaveRevisionChanges()
        {
            throw new NotImplementedException();
        }
    }
}
