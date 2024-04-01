using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace App.Domain.DBGeneratedModel
{
    public partial class Role : IdentityRole
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public string Description { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
