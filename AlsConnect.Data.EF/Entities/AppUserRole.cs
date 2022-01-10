using System;
using System.Collections.Generic;

namespace AlsConnect.Data.EF.Entities
{
    public partial class AppUserRole
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
