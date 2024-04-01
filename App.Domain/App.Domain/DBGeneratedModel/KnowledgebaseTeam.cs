using System;
using System.Collections.Generic;

namespace App.Domain.DBGeneratedModel
{
    public partial class KnowledgebaseTeam
    {
        public KnowledgebaseTeam()
        {
            KnbMainCategories = new HashSet<KnbMainCategory>();
        }

        public short TeamId { get; set; }
        public int ErpDepartmentId { get; set; }
        public string TeamName { get; set; }
        public string CreatedBy { get; set; }

        public virtual ICollection<KnbMainCategory> KnbMainCategories { get; set; }
    }
}
