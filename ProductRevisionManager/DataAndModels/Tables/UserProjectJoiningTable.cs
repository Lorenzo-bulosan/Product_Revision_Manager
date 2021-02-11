using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndModels
{
    public class UserProject
    {
        // many to many User-Project

        public int Id { get; set; }

        // users table 2
        public int userID { get; set; }
        public User2 Users2 { get; set; }

        // project table 2
        public int projectID { get; set; }
        public Project2 Projects2 { get; set; }
    }
}
