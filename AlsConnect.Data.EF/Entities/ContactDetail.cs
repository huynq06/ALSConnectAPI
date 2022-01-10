using System;
using System.Collections.Generic;

namespace AlsConnect.Data.EF.Entities
{
    public partial class ContactDetail
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public string Other { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public int Status { get; set; }
    }
}
