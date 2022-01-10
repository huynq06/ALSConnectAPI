using System;
using System.Collections.Generic;

namespace AlsConnect.Data.EF.Entities
{
    public partial class Language
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public string Resources { get; set; }
        public int Status { get; set; }
    }
}
