using System;
using System.Collections.Generic;

namespace AlsConnect.Data.EF.Entities
{
    public partial class AppRoleClaim
    {
        public int Id { get; set; }
        public Guid RoleId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
