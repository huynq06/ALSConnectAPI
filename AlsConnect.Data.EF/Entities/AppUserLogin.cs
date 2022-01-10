using System;
using System.Collections.Generic;

namespace AlsConnect.Data.EF.Entities
{
    public partial class AppUserLogin
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public Guid UserId { get; set; }
    }
}
