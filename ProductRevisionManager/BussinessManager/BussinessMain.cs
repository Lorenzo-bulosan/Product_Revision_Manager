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

            RevisionManager.GenerateUserTestData();

        }

    }
}
