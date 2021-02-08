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
            //RevisionManager.GetUserAndAProject(2);
            //RevisionManager.GenerateRevisionRoundTestData(0);
            RevisionManager.GetProjectsAndTheirRevisionsFromUsers();
        }

    }
}
