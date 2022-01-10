using System;
using System.Collections.Generic;

namespace AlsConnect.Data.EF.Entities
{
    public partial class AnnouncementUser
    {
        public int Id { get; set; }
        public string AnnouncementId { get; set; }
        public Guid UserId { get; set; }
        public bool? HasRead { get; set; }

        public virtual Announcement Announcement { get; set; }
    }
}
