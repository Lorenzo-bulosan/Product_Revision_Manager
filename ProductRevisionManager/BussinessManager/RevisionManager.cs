using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAndModels;
using Microsoft.EntityFrameworkCore;

namespace BussinessManager
{
    public class RevisionManager
    {
        
        public RevisionTask SelectedRevisionTask { get; set; }

        public void SetSelectedRevisionTask(Object ListBoxSelectedItem)
        {
            SelectedRevisionTask = (RevisionTask)ListBoxSelectedItem;
        }

        // Retrieve user object
        public User2 GetUserInformationFromUserID(int userID)
        {
            using (var db = new MonokayuDbContext())
            {
                var user = db.Users2.Where(c => c.UserID == userID).FirstOrDefault();

                return user;
            }
        }

        // Obtain projects given a userID and return dictionary of projectID, projectName
        public Dictionary<int, string> GetProjectsFromUserID(int userID)
        {
            using (var db = new MonokayuDbContext())
            {
                var commentsFromUser = from u in db.Users2
                                       join up in db.UserProjects on u.UserID equals up.userID
                                       join p in db.Projects2 on up.projectID equals p.ProjectID
                                       where u.UserID == userID
                                       select new
                                       {
                                           p.ProjectID,
                                           p.projectName
                                       };

                return commentsFromUser.ToDictionary(p => p.ProjectID, p => p.projectName);
            }
        }

        // Inserts a revision given a project
        public void GenerateRevisionForProjectID(int projectId, DateTime deadline)
        {
            using (var db = new MonokayuDbContext())
            {
                db.Add(new Revision() { deadline = deadline, ProjectID = projectId });
                db.SaveChanges();
            }
        }

        // Obtain all revisions given a projectID and return dictionary of revisionID,revisionDeadline
        public Dictionary<int, DateTime> GetRevisionsFromProject(int projectID)
        {
            using (var db = new MonokayuDbContext())
            {
                var res = from r in db.Revisions
                          where r.Project.ProjectID == projectID
                          select r;
                return res.ToDictionary(r => r.RevisionID, r => r.deadline);
            }
        }

        // Insert a task given a revisionID
        public void AddTaskToRevision(int revisionID, string title, string description, int urgency, int progress = 0, string url = "")
        {
            using (var db = new MonokayuDbContext())
            {
                db.Add(new RevisionTask
                {
                    RevisionID = revisionID,
                    title = title,
                    description = description,
                    urgency = urgency,
                    progress = progress,
                    links = url
                });

                db.SaveChanges();
            }
        }

        // Obtain tasks given a revisionID and return List of Task objects
        public List<RevisionTask> GetTasksFromRevisionID(int revisionId)
        {
            using (var db = new MonokayuDbContext())
            {
                var res = db.RevisionTasks.Where(r => r.RevisionID == revisionId).ToList();
                return res;
            }
        }

        // Updates task given taskID
        public void UpdateRevisionTask(int taskID, string title, string description, int urgency, int progress, string url)
        {
            using (var db = new MonokayuDbContext())
            {
                var specificTask = db.RevisionTasks.Where(r => r.TaskID == taskID).FirstOrDefault();

                specificTask.title = title;
                specificTask.description = description;
                specificTask.urgency = urgency;
                specificTask.progress = progress;
                specificTask.links = url;

                db.SaveChanges();
            }
        }

        // Inserts a comment to an existing task
        public void AddCommentToTaskID(int taskID, string comment, string senderName)
        {

            if (comment != "")
            {
                using (var db = new MonokayuDbContext())
                {
                    db.Add(new TaskComment
                    {
                        TaskID = taskID,
                        comment = comment,
                        senderName = senderName,
                        time = DateTime.Now
                    }); ;

                    db.SaveChanges();
                }
            }
        }

        // Obtains all comments given a taskID and returns a list of comments object
        public List<TaskComment> RetrieveCommentsFromTaskID(int taskID)
        {
            using (var db = new MonokayuDbContext())
            {
                var CommentQuery = db.TaskComments.Where(c => c.TaskID == taskID);

                return CommentQuery.ToList();
            }
        }

        // Obtains all comments given userID
        public IEnumerable<Object> RetrieveCommentsOfTaskFromUser(int userID, int taskId)
        {
            using (var db = new MonokayuDbContext())
            {
                var commentsFromUser = from u in db.Users2
                                       join up in db.UserProjects on u.UserID equals up.userID
                                       join p in db.Projects2 on up.projectID equals p.ProjectID
                                       join r in db.Revisions on p.ProjectID equals r.ProjectID
                                       join t in db.RevisionTasks on r.RevisionID equals t.RevisionID
                                       join c in db.TaskComments on t.TaskID equals c.TaskID
                                       where u.UserID == userID 
                                       where t.TaskID == taskId
                                       select new
                                       {
                                            u.firstName,
                                            u.lastName,
                                            c.time,
                                            c.comment,
                                            c.senderName
                                       };

                return commentsFromUser.ToList();
            }
        }
    }
}


////public static void GetUsersAndTheirProjects()
////{
////    using (var db = new MonokayuDbContext())
////    {
////        Console.WriteLine("\nRetrieving all users and their projects");
////        var userProjectsQuery = 
////            db.Users2
////            .Join(
////                db.Projects2 ,
////                u => u.UserID,
////                p => p.user,
////                (u, p) => new {p, u}
////            );

////        foreach (var item in userProjectsQuery)
////        {
////            Console.WriteLine($"Users {item.u.firstName} of ID: {item.u.UserID}");
////            Console.WriteLine($"Projects of this user: {item.p.projectName}");
////        }
////    }
////}

////public static void GetProjectInfoFromUserID(int id)
////{
////    using (var db = new MonokayuDbContext())
////    {
////        Console.WriteLine($"\nRetrieving project info from userid: {id}");
////        var userProjectQuery =
////            db.Users
////            .Join(
////                db.Projects,
////                u => u.UserID,
////                p => p.UserID,
////                (u, p) => new { p, u }
////            ).Where(user => user.u.UserID == id);

////        foreach (var userProject in userProjectQuery)
////        {
////            Console.WriteLine($"project name: {userProject.p.projectName}");
////        }
////    }
////}

//public static void GetProjectsAndTheirRevisionsFromUsers()
//{
//    Console.WriteLine($"\nQuerying projects and their revisions from all users");

//    using (var db = new MonokayuDbContext())
//    {
//        var commentsFromUser = from u in db.Users2
//                               join up in db.UserProjects on u.UserID equals up.userID
//                               join p in db.Projects2 on up.projectID equals p.ProjectID
//                               join r in db.Revisions on p.ProjectID equals r.ProjectID
//                               join t in db.RevisionTasks on r.RevisionID equals t.RevisionID
//                               join c in db.TaskComments on t.TaskID equals c.TaskID                                      
//                               select new
//                               {
//                                   u.UserID,
//                                   u.firstName,
//                                   u.lastName,
//                                   p.ProjectID,
//                                   p.projectName,
//                                   r.RevisionID,
//                                   r.RevisionTasks,
//                                   c.comment
//                               };

//        foreach (var item in commentsFromUser)
//        {
//            Console.WriteLine($"{item.firstName} {item.lastName}" +
//                              $"\n{item.ProjectID} {item.projectName}" +
//                              $"\n{item.RevisionID} {item.RevisionTasks}" +
//                              $"\n{item.comment}");
//        }
//    }
//}

//public static void AddTaskToRevisionID(int revisionID)
//{
//    Console.WriteLine($"\nAdding tasks to RevisionID: {revisionID}");

//    using (var db = new MonokayuDbContext())
//    {
//        db.Add(new RevisionTask { 
//            RevisionID = revisionID,
//            title="Log in function", 
//            description="start on different frame and then verify uniqueness",
//            urgency=4,
//            progress=0,
//            links="https://Monokayu.com"
//        });

//        db.SaveChanges();
//    }
//}

//public static void GetTasksFromRevisionID_Dev(int revisionId)
//{
//    Console.WriteLine($"\nQuerying tasks from RevisionID: {revisionId}");

//    using (var db = new MonokayuDbContext())
//    {
//        var TaskQuery =
//            db.Revisions
//            .Join(
//                db.RevisionTasks,
//                r => r.RevisionID,
//                rt => rt.RevisionID,
//                (r, rt) => new { r, rt }
//            ).Where(z => z.r.RevisionID == revisionId);

//        foreach (var task in TaskQuery)
//        {
//            Console.WriteLine($"RevisionID {task.r.RevisionID} has taskID {task.rt.TaskID}");
//            Console.WriteLine($"Details of this task: " +
//                              $"\n -title: {task.rt.title} " +
//                              $"\n -description: {task.rt.description} " +
//                              $"\n -urgency: {task.rt.urgency}" +
//                              $"\n -progress: {task.rt.progress}");
//        }
//    }
//}

//public static void AddCommentToTaskID_void(int taskID)
//{
//    Console.WriteLine($"\nAdding comments to taskID: {taskID}");

//    using (var db = new MonokayuDbContext())
//    {
//        db.Add(new TaskComment
//        {
//            TaskID = taskID,
//            comment = "Hi is this done yet?",
//            time = new DateTime()
//        }); 

//        db.SaveChanges();
//    }
//}

//public static void GetCommentsFromTaskID(int taskID)
//{
//    Console.WriteLine($"\nQuerying comments from taskID: {taskID}");

//    using (var db = new MonokayuDbContext())
//    {
//        var commentsFromUser = from u in db.Users2
//                               join up in db.UserProjects on u.UserID equals up.userID
//                               join p in db.Projects2 on up.projectID equals p.ProjectID
//                               join r in db.Revisions on p.ProjectID equals r.ProjectID
//                               join t in db.RevisionTasks on r.RevisionID equals t.RevisionID
//                               join c in db.TaskComments on t.TaskID equals c.TaskID
//                               where t.TaskID == taskID
//                               select new
//                               {
//                                   u.UserID,
//                                   u.firstName,
//                                   u.lastName,
//                                   p.ProjectID,
//                                   p.projectName,
//                                   r.RevisionID,
//                                   r.RevisionTasks,
//                                   c.comment
//                               };

//        foreach (var item in commentsFromUser)
//        {
//            Console.WriteLine($"{item.firstName} {item.lastName}" +
//                              $"\n{item.ProjectID} {item.projectName}" +
//                              $"\n{item.RevisionID} {item.RevisionTasks}" +
//                              $"\n{item.comment}");
//        }
//    }
//}

//public static int Test()
//{
//    return 0;
//}

//public static void addingTestData()
//{
//    using (var db = new MonokayuDbContext())
//    {
//        Console.WriteLine("Creating some customers");
//        db.Add(new Customer() { CustomerId = "1", City = "London", ContactName = "Lorenzo", PostalCode = "W3 6hg", Country = "Uk" });
//        db.Add(new Customer() { CustomerId = "2", City = "London", ContactName = "Lorenzo", PostalCode = "W3 6hg", Country = "Uk" });
//        db.Add(new Customer() { CustomerId = "3", City = "London", ContactName = "Lorenzo", PostalCode = "W3 6hg", Country = "Uk" });
//        db.SaveChanges();
//    }
//}

//public string TestString()
//{
//    return "From inside main";
//}
