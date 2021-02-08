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

        // tables
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Project> Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Monokayu;");
            }
        }
    }
}
