﻿using System;
using System.Collections.Generic;

namespace AlsConnect.Data.EF.Entities
{
    public partial class AppUserToken
    {
        public Guid UserId { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
