using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace App.Domain.DBGeneratedModel
{
    public partial class User : IdentityUser
    {
        public User()
        {
            Userlogins = new HashSet<Userlogin>();
            Roles = new HashSet<Role>();
        }
        public string OracleNo { get; set; } = null!;
        public DateTime? LockoutEnd { get; set; }
        public bool? Isblocked { get; set; }
        public string? Title { get; set; }
        public string? Department { get; set; }

        public virtual ICollection<Userlogin> Userlogins { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
