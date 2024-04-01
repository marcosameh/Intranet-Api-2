using System;
using System.Collections.Generic;

namespace App.Domain.DBGeneratedModel
{
    public partial class KnowledgebaseArticle
    {
        public short ArticleId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public short? CategroyId { get; set; }

        public virtual KnowledgebaseCategroy Categroy { get; set; }
    }
}
