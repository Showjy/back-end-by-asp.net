using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AndroidAPP02.Models
{
    public class Project
    {
        public string Id { get; set; }
        
        public string Theme { get; set; }
        
        public string Detail { get; set; }
        
        public string Requirements { get; set; }
        
        public int Member { get; set; }
        
        public string Deadline { get; set; }
        
        public string Author { get; set; }
    }
}