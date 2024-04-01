using System;
using System.Collections.Generic;

namespace App.Domain.DBGeneratedModel
{
    public partial class Knowledgebase
    {
        public Knowledgebase()
        {
            KnowledgebaseSections = new HashSet<KnowledgebaseSection>();
        }

        public short Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<KnowledgebaseSection> KnowledgebaseSections { get; set; }
    }
}
