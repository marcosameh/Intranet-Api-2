using System;
using System.Collections.Generic;

namespace App.Domain.DBGeneratedModel
{
    public partial class KnbSubCategory
    {
        public KnbSubCategory()
        {
            KnbScategoryFiles = new HashSet<KnbScategoryFile>();
        }

        public short SubCategoryId { get; set; }
        public short MainCategoryId { get; set; }
        public string SubCategoryName { get; set; } = null!;
        public string SubCategoryContent { get; set; } = null!;

        public virtual KnbMainCategory MainCategory { get; set; } = null!;
        public virtual ICollection<KnbScategoryFile> KnbScategoryFiles { get; set; }
    }
}
