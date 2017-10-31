using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AndroidAPP02.Models
{
    public class UserToProjectViewModels1
    {
        [Required]
        public string id { get; set; }
    }
    public class UserToProjectViewModels2
    {
        [Required]
        public string UserId { get; set; }
    }
    public class UserToProjectViewModels3
    {
        [Required]
        public string ProjectId { get; set; }
    }
    public class UserToProjectViewModels4
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string ProjectId { get; set; }
    }
}