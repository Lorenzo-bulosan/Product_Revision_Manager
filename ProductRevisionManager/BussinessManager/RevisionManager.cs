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
        
        public static void GenerateUserTestData()
        {
            using (var db = new MonokayuDbContext())
            {
                Console.WriteLine("Creating some Users");

                db.Add(new User() { firstName = "Lorenzo0", lastName = "Bulosan", securityLevel = 0, password = "12345678" });
                db.Add(new User() { firstName = "Angel", lastName = "Hidalgo", securityLevel = 1, password = "12345678" });
                db.Add(new User() { firstName = "Taner", lastName = "Cagali", securityLevel = 1, password = "12345678" });

                db.SaveChanges();
            }
        }

        public static void GenerateProjectTestData()
        {
            using (var db = new MonokayuDbContext())
            {
                Console.WriteLine("Creating some projects");

                db.Add(new Project() { projectName = "project1", UserID = 13 });
                db.Add(new Project() { projectName = "project2", UserID = 14 });
                db.Add(new Project() { projectName = "project3", UserID = 14 }); 
                db.SaveChanges();
            }
        }

        public static void GenerateRevisionForProjectID(int projectId)
        {
            using (var db = new MonokayuDbContext())
            {
                Console.WriteLine($"Creating some Revision for projectID: {projectId}");
                db.Add(new Revision() { deadline = new DateTime(), ProjectID = projectId });
                db.SaveChanges();
            }
        }

        public static void GetUsersAndTheirProjects()
        {
            using (var db = new MonokayuDbContext())
            {
                Console.WriteLine("\nRetrieving all users and their projects");
                var userProjectsQuery = 
                    db.Users
                    .Join(
                        db.Projects ,
                        u => u.UserID,
                        p => p.UserID,
                        (u, p) => new {p, u}
                    );

                foreach (var item in userProjectsQuery)
                {
                    Console.WriteLine($"Users {item.u.firstName} of ID: {item.u.UserID}");
                    Console.WriteLine($"Projects of this user: {item.p.projectName}");
                }
            }
        }

        public static void GetProjectInfoFromUserID(int id)
        {
            using (var db = new MonokayuDbContext())
            {
                Console.WriteLine($"\nRetrieving project info from userid: {id}");
                var userProjectQuery =
                    db.Users
                    .Join(
                        db.Projects,
                        u => u.UserID,
                        p => p.UserID,
                        (u, p) => new { p, u }
                    ).Where(user => user.u.UserID == id);

                foreach (var userProject in userProjectQuery)
                {
                    Console.WriteLine($"project name: {userProject.p.projectName}");
                }
            }
        }

        public static void GetProjectsAndTheirRevisionsFromUsers()
        {
            using (var db = new MonokayuDbContext())
            {
                Console.WriteLine("\nRetrieving users with projects that have revisions");
                var projectRevisionQuery =
                    db.Users
                    .Join(
                        db.Projects,
                        u => u.UserID,
                        p => p.UserID,
                        (u, p) => new { p, u }
                    ).Join(
                        db.Revisions,
                        u => u.p.ProjectID,
                        rr => rr.ProjectID,
                        (rr, u) => new { u, rr }
                    );

                foreach (var item in projectRevisionQuery)
                {
                    Console.WriteLine($"Users {item.rr.u.firstName} of ID: {item.rr.u.UserID}");
                    Console.WriteLine($"ProjectsID: {item.rr.p.ProjectID} with name: {item.rr.p.projectName}");
                    Console.WriteLine($"Has this RevisionID: {item.u.RevisionID} with deadline {item.u.deadline}");
                }
            }
        }

        public static void AddTaskToRevisionID(int revisionID)
        {
            Console.WriteLine($"\nAdding tasks to RevisionID: {revisionID}");

            using (var db = new MonokayuDbContext())
            {
                db.Add(new RevisionTask { 
                    RevisionID = revisionID,
                    title="Log in function", 
                    description="start on different frame and then verify uniqueness",
                    urgency=4,
                    progress=0,
                    links="https://Monokayu.com"
                });

                db.SaveChanges();
            }
        }

        public static void GetTasksFromRevisionID_Dev(int revisionId)
        {
            Console.WriteLine($"\nQuerying tasks from RevisionID: {revisionId}");

            using (var db = new MonokayuDbContext())
            {
                var TaskQuery =
                    db.Revisions
                    .Join(
                        db.RevisionTasks,
                        r => r.RevisionID,
                        rt => rt.RevisionID,
                        (r, rt) => new { r, rt }
                    ).Where(z => z.r.RevisionID == revisionId);

                foreach (var task in TaskQuery)
                {
                    Console.WriteLine($"RevisionID {task.r.RevisionID} has taskID {task.rt.TaskID}");
                    Console.WriteLine($"Details of this task: " +
                                      $"\n -title: {task.rt.title} " +
                                      $"\n -description: {task.rt.description} " +
                                      $"\n -urgency: {task.rt.urgency}" +
                                      $"\n -progress: {task.rt.progress}");
                }
            }
        }

        public static void AddCommentToTaskID_void(int taskID)
        {
            Console.WriteLine($"\nAdding comments to taskID: {taskID}");

            using (var db = new MonokayuDbContext())
            {
                db.Add(new TaskComment
                {
                    TaskID = taskID,
                    comment = "Hi is this done yet?",
                    time = new DateTime()
                }); 

                db.SaveChanges();
            }
        }

        public static void GetCommentsFromTaskID(int taskID)
        {
            Console.WriteLine($"\nQuerying comments from taskID: {taskID}");

            using (var db = new MonokayuDbContext())
            {
                var CommentQuery =
                    db.RevisionTasks
                    .Join(
                        db.TaskComments,
                        rt => rt.TaskID,
                        tc => tc.TaskID,
                        (rt, tc) => new { rt, tc }
                    ).Where(c => c.rt.TaskID == taskID);

                foreach (var comment in CommentQuery)
                {
                    Console.WriteLine($"tasksID {comment.rt.TaskID} has commentID {comment.tc.CommentID}");
                    Console.WriteLine($"Details of this comment: " +
                                      $"\n -comment: '{comment.tc.comment}' " +
                                      $"\n -time written: {comment.tc.time}");
                }
            }
        }

        public static int Test()
        {
            return 0;
        }

        public static void addingTestData()
        {
            using (var db = new MonokayuDbContext())
            {
                Console.WriteLine("Creating some customers");
                db.Add(new Customer() { CustomerId = "1", City = "London", ContactName = "Lorenzo", PostalCode = "W3 6hg", Country = "Uk" });
                db.Add(new Customer() { CustomerId = "2", City = "London", ContactName = "Lorenzo", PostalCode = "W3 6hg", Country = "Uk" });
                db.Add(new Customer() { CustomerId = "3", City = "London", ContactName = "Lorenzo", PostalCode = "W3 6hg", Country = "Uk" });
                db.SaveChanges();
            }
        }

        public string TestString()
        {
            return "From inside main";
        }

        // for wpf
        public RevisionTask SelectedRevisionTask { get; set; }

        public void SetSelectedRevisionTask(Object ListBoxSelectedItem)
        {
            SelectedRevisionTask = (RevisionTask)ListBoxSelectedItem;
        }

        public List<RevisionTask> GetTasksFromRevisionID(int revisionId)
        {
            using (var db = new MonokayuDbContext())
            {
                var res = db.RevisionTasks.Where(r => r.RevisionID == revisionId).ToList();
                return res;
            }
        }

        public List<int> GetRevisionsFromProject(string uniqueName)
        {
            using (var db = new MonokayuDbContext())
            {
                var res = from r in db.Revisions 
                          where r.Project.projectName == uniqueName
                          select r.RevisionID;
                return res.ToList();
            }
        }

        public void AddTaskToRevision( int revisionID, string title, string description, int urgency, int progress=0 ,string url="")
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

        public List<TaskComment> RetrieveCommentsFromTaskID(int taskID)
        {
            using (var db = new MonokayuDbContext())
            {
                var CommentQuery = db.TaskComments.Where(c => c.TaskID == taskID);

                return CommentQuery.ToList();
            }
        }

        public IEnumerable<Object> RetrieveCommentsOfTaskFromUser(int taskID)
        {
            using (var db = new MonokayuDbContext())
            {
                var commentsFromUser = from u in db.Users
                                       join p in db.Projects on u.UserID equals p.UserID
                                       join r in db.Revisions on p.ProjectID equals r.ProjectID
                                       join t in db.RevisionTasks on r.RevisionID equals t.RevisionID
                                       join c in db.TaskComments on t.TaskID equals c.TaskID
                                       where t.TaskID == taskID    
                                       select new
                                       {
                                            u.firstName,
                                            u.lastName,
                                            c.time,
                                            c.comment,
                                            c
                                       };

                return commentsFromUser.ToList();
            }
        }

        public void AddCommentToTaskID(int taskID, string comment)
        {
            using (var db = new MonokayuDbContext())
            {
                db.Add(new TaskComment
                {
                    TaskID = taskID,
                    comment = comment,
                    time = DateTime.Now
            });

                db.SaveChanges();
            }
        }
    }
}
