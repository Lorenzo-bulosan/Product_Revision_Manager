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

        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Monokayu;");
            }
        }
    }
}
