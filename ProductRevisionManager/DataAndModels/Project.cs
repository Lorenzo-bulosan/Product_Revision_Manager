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

        }

        [Key]
        public int ProjectID { get; set; }

        // need to make revision id col

        public string projectName { get; set; }

        // associations
        [ForeignKey("User")]
        public int UserID { get; set; }
        public virtual User User { get; set; } 
    }
}
