using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndModels
{
    public partial class TaskComment
    {
        public TaskComment()
        {

        }

        [Key]
        public int CommentID { get; set; }

        [ForeignKey("RevisionTask")]
        public int TaskID { get; set; }
        public DateTime time { get; set; }
        public string comment { get; set; }
        public string senderName { get; set; }

        // associations
        public virtual RevisionTask RevisionTask { get; set; }

    }
}
