using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndModels
{
    public partial class Revision
    {
        public Revision()
        {

        }

        [Key]
        public int RevisionID { get; set; }

        public DateTime deadline { get; set; }

        // associations
        public virtual Project Project { get; set; } 
    }
}
