using System;
using System.Collections.Generic;

namespace App.Domain.DBGeneratedModel;

public partial class NewsType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? Isenable { get; set; }

    public virtual ICollection<News> News { get; set; } = new List<News>();
}
