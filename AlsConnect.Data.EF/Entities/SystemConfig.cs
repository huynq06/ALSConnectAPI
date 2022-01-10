using System;
using System.Collections.Generic;

namespace AlsConnect.Data.EF.Entities
{
    public partial class SystemConfig
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Value1 { get; set; }
        public int? Value2 { get; set; }
        public bool? Value3 { get; set; }
        public DateTime? Value4 { get; set; }
        public decimal? Value5 { get; set; }
        public int Status { get; set; }
    }
}
