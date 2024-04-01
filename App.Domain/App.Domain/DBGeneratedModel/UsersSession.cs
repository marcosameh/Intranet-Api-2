using System;
using System.Collections.Generic;

namespace App.Domain.DBGeneratedModel
{
    public partial class UsersSession
    {
        public short SeesionId { get; set; }
        public string Token { get; set; }
        public DateTime LoginTime { get; set; }
        public string UserName { get; set; }
    }
}
