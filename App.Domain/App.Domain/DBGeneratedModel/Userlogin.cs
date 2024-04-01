using System;
using System.Collections.Generic;

namespace App.Domain.DBGeneratedModel
{
    public partial class Userlogin
    {
        public string Loginprovider { get; set; } = null!;
        public string Providerkey { get; set; } = null!;
        public string Userid { get; set; } = null!;
        public string? Providerdisplayname { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
