using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndModels
{
    public partial class Project
    {
        public Project()
        {
            Revisions = new HashSet<Revision>();
        }

        [Key]
        public int ProjectID { get; set; }

        public string projectName { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        // associations
        public virtual User User { get; set; }
        public virtual ICollection<Revision> Revisions { get; set; }
    }
}
