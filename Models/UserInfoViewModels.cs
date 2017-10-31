using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AndroidAPP02.Models
{
    public class UserDetailsViewModels
    {
        [Required]
        public string id { get; set; }
    }
}