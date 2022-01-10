using System;
using System.Collections.Generic;

namespace AlsConnect.Data.EF.Entities
{
    public partial class AdvertistmentPage
    {
        public AdvertistmentPage()
        {
            AdvertistmentPositions = new HashSet<AdvertistmentPosition>();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AdvertistmentPosition> AdvertistmentPositions { get; set; }
    }
}
