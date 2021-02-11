using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndModels
{
    public class MonokayuDbContext:DbContext
    {
        public static MonokayuDbContext Instance { get; } = new MonokayuDbContext();

        // test table
        public virtual DbSet<Customer> Customers { get; set; }


        // modified tables for joining - NEW
        public virtual DbSet<User2> Users2 { get; set; }
        public virtual DbSet<Project2> Projects2 { get; set; }
        public virtual DbSet<UserProject> UserProjects { get; set; }

        // tables
        //public virtual DbSet<User> Users { get; set; }
        //public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Revision> Revisions { get; set; }
        public virtual DbSet<RevisionTask> RevisionTasks { get; set; }
        public virtual DbSet<TaskComment> TaskComments { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Monokayu;");
            }
        }

        // added for the many to many -NEW
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProject>()
              .HasOne(x => x.Users2)
              .WithMany(x => x.UserProjects)
              .HasForeignKey(x => x.userID);

            modelBuilder.Entity<UserProject>()
              .HasOne(x => x.Projects2)
              .WithMany(x => x.UserProjects)
              .HasForeignKey(x => x.projectID);

        }
    }
}
