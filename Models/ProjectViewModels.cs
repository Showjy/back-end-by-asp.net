using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AndroidAPP02.Models
{
    public class ProjDetailsViewModels
    {
        [Required]
        public string id { get; set; }
    }

    public class ProjViewModels
    {
        [Required]
        public string Theme { get; set; }
        
        [Required]
        public string Detail { get; set; }
        
        [Required]
        public string Requirements { get; set; }
        
        [Required]
        public int Member { get; set; }
        
        [Required]
        public string Deadline { get; set; }
        
        [Required]
        public string Author { get; set; }
    }

    public class MyProjectViewModels
    {
        [Required]
        public string Author { get; set; }
    }
}