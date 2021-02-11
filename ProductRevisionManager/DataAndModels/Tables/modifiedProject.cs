using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndModels
{
    public partial class Project2
    {
        public Project2()
        {
            Revisions = new HashSet<Revision>();
        }

        [Key]
        public int ProjectID { get; set; }

        public string projectName { get; set; }

        // associations
        public virtual User User { get; set; }
        public virtual ICollection<Revision> Revisions { get; set; }

        // many to many user-project
        // through a one to many with joining table
        public virtual ICollection<UserProject> UserProjects { get; set; }
    }
}
