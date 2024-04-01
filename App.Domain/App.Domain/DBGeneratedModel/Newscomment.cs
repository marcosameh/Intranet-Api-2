using System;
using System.Collections.Generic;

namespace App.Domain.DBGeneratedModel;

public partial class Newscomment
{
    public decimal Id { get; set; }

    public string Content { get; set; } = null!;

    public decimal? Userid { get; set; }

    public decimal? Newsid { get; set; }

    public DateTime? Timestamp { get; set; }
}
