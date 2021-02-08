using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndModels
{
    public partial class RevisionTask
    {
        public RevisionTask()
        {

        }

        [Key]
        public int TaskID { get; set; }

        [ForeignKey("Revision")]
        public int RevisionID { get; set; }

        public string title { get; set; }
        public string description { get; set; }
        public int urgency { get; set; }
        public int progress { get; set; }
        public string links { get; set; }

        // associations
        public virtual Revision Revision { get; set; }

    }
}
