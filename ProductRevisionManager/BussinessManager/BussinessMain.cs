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

            /* Generates user, project and retrieves */
            //RevisionManager.GenerateUserTestData();
            //RevisionManager.GenerateProjectTestData();
            RevisionManager.GetUsersAndTheirProjects();
            RevisionManager.GetProjectInfoFromUserID(14);

            /* Generates revision for a project and retrieves */
            //RevisionManager.GenerateRevisionForProjectID(10);
            RevisionManager.GetProjectsAndTheirRevisionsFromUsers();

            /* Generate task for a specific revision and retrieve */
            //RevisionManager.AddTaskToRevisionID(3);
            RevisionManager.GetTasksFromRevisionID(3);

            /* Generate comment for a task and retrieve */
            //RevisionManager.AddCommentToTaskID(1);
            RevisionManager.GetCommentsFromTaskID(1);
        }

    }
}
