using System;
using System.Collections.Generic;

namespace App.Domain.DBGeneratedModel
{
    public partial class KnowledgebaseCategroy
    {
        public KnowledgebaseCategroy()
        {
            KnowledgebaseArticles = new HashSet<KnowledgebaseArticle>();
            KnowledgebaseFiles = new HashSet<KnowledgebaseFile>();
        }

        public short CategroyId { get; set; }
        public string CategroyName { get; set; }
        public short ParentCategroyId { get; set; }

        public virtual ICollection<KnowledgebaseArticle> KnowledgebaseArticles { get; set; }
        public virtual ICollection<KnowledgebaseFile> KnowledgebaseFiles { get; set; }
    }
}
