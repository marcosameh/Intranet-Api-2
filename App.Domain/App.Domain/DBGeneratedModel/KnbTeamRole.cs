using System;
using System.Collections.Generic;

namespace App.Domain.DBGeneratedModel
{
    public partial class KnbTeamRole
    {
        public short TeamId { get; set; }
        public string RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual KnowledgebaseTeam Team { get; set; }
    }
}
