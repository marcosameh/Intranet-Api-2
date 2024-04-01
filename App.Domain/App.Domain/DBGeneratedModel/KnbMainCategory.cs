using System;
using System.Collections.Generic;

namespace App.Domain.DBGeneratedModel
{
    public partial class KnbMainCategory
    {
        public KnbMainCategory()
        {
            KnbSubCategories = new HashSet<KnbSubCategory>();
        }

        public short MainCategoryId { get; set; }
        public short TeamId { get; set; }
        public string CategoryName { get; set; }

        public virtual KnowledgebaseTeam Team { get; set; }
        public virtual ICollection<KnbSubCategory> KnbSubCategories { get; set; }
    }
}
