using System;
using System.Collections.Generic;

namespace App.Domain.DBGeneratedModel;

public partial class NewsAttachment
{
    public int Id { get; set; }

    public int NewsId { get; set; }

    public string? AttachmentName { get; set; }

    public string? Extension { get; set; }

    public string? CoverImg { get; set; }

    public virtual News News { get; set; } = null!;
}
