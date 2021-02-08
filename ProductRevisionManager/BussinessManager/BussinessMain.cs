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

            //RevisionManager.GenerateUserTestData();
            //RevisionManager.GenerateProjectTestData();
            //RevisionManager.GetUsersAndTheirProjects();
            //RevisionManager.GetProjectInfoFromUserID(13);
            //RevisionManager.GenerateRevisionForProjectID(10);
            //RevisionManager.GetProjectsAndTheirRevisionsFromUsers();
            //RevisionManager.AddTaskToRevisionID(3);
            RevisionManager.GetTasksFromRevisionID(3);

        }

    }
}
