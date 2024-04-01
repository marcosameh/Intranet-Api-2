using System;
using System.Collections.Generic;

namespace App.Domain.DBGeneratedModel
{
    public partial class KnowledgebaseFile
    {
        public short FileId { get; set; }
        public string FileName { get; set; }
        public string FileNameHash { get; set; }
        public short? CategroyId { get; set; }
        public decimal? IsViewOnly { get; set; }

        public virtual KnowledgebaseCategroy Categroy { get; set; }
    }
}
