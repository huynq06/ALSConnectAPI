using System;
using System.Collections.Generic;

namespace AlsConnect.Data.EF.Entities
{
    public partial class AdvertistmentPosition
    {
        public AdvertistmentPosition()
        {
            Advertistments = new HashSet<Advertistment>();
        }

        public string Id { get; set; }
        public string PageId { get; set; }
        public string Name { get; set; }

        public virtual AdvertistmentPage Page { get; set; }
        public virtual ICollection<Advertistment> Advertistments { get; set; }
    }
}
