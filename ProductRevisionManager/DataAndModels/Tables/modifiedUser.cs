using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndModels
{
    public partial class User2
    {
        public User2()
        {
            // from original
            //Projects = new HashSet<Project2>();
        }

        [Key]
        public int UserID { get; set; }
        
        // Fields
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int securityLevel { get; set; }
        public string password { get; set; }

        // associations

        // from original
        //public virtual ICollection<Project2> Projects { get; set; }

        // many to many user-project
        // through one to many with joining table 
        public virtual ICollection<UserProject> UserProjects { get; set; }
    }
}
