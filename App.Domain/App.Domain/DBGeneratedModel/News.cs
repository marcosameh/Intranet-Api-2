using System;
using System.Collections.Generic;

namespace App.Domain.DBGeneratedModel;

public partial class News
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Body { get; set; } = null!;

    public int NewsTypeId { get; set; }

    public bool? IsAdvertisement { get; set; }

    public DateTime Createdon { get; set; }

    public virtual ICollection<NewsAttachment> NewsAttachments { get; set; } = new List<NewsAttachment>();

    public virtual NewsType NewsType { get; set; } = null!;
}
