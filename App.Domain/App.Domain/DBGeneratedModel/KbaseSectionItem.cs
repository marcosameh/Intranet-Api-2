using System;
using System.Collections.Generic;

namespace App.Domain.DBGeneratedModel
{
    public partial class KbaseSectionItem
    {
        public short ItemId { get; set; }
        public string ItemName { get; set; } = null!;
        public string ItemContent { get; set; } = null!;
        public short SectionId { get; set; }

        public virtual KnowledgebaseSection Section { get; set; } = null!;
    }
}
