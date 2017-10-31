using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AndroidAPP02.Models
{
    public class UserToProject
    {
        public string id { get; set;}
        
        public string UserId { get; set; }
        
        public string ProjectId { get; set; }
        
        public string status { get; set; }//waiting,refused,accepted;
    }
}