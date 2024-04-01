using System;
using System.Collections.Generic;

namespace App.Domain.DBGeneratedModel
{
    public partial class KnowledgebaseRole
    {
        public short KnowledgebaseId { get; set; }
        public string RoleId { get; set; } = null!;

        public virtual Knowledgebase Knowledgebase { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
    }
}
