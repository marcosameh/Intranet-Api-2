using System;
using System.Collections.Generic;

namespace App.Domain.DBGeneratedModel
{
    public partial class KnowledgebaseSection
    {
        public KnowledgebaseSection()
        {
            KbaseSectionItems = new HashSet<KbaseSectionItem>();
        }

        public short SectionId { get; set; }
        public string SectionName { get; set; } = null!;
        public short KnowledgebaseId { get; set; }

        public virtual Knowledgebase Knowledgebase { get; set; } = null!;
        public virtual ICollection<KbaseSectionItem> KbaseSectionItems { get; set; }
    }
}
