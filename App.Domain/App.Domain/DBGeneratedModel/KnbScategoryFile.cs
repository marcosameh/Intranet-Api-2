using System;
using System.Collections.Generic;

namespace App.Domain.DBGeneratedModel
{
    public partial class KnbScategoryFile
    {
        public short FileId { get; set; }
        public short SubCategoryId { get; set; }
        public string FileName { get; set; } = null!;
        public string? FileOriginalName { get; set; }

        public virtual KnbSubCategory SubCategory { get; set; } = null!;
    }
}
