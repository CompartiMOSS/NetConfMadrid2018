using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IS4.Auth.AspNetIdentity
{ 
    public class Role : IdentityRole
    {       
        [Required]
        public string Description { get; set; }
        [Required]
        public bool? Private { get; set; }
    }
}
