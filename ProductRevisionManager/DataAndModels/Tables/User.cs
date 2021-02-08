using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndModels
{
    public partial class User
    {
        public User()
        {
            Projects = new HashSet<Project>();
        }

        [Key]
        public int UserID { get; set; }
        
        // Fields
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int securityLevel { get; set; }
        public string password { get; set; }

        // associations
        public virtual ICollection<Project> Projects { get; set; }
    }
}
