using System;
using System.Collections.Generic;

namespace AlsConnect.Data.EF.Entities
{
    public partial class Announcement
    {
        public Announcement()
        {
            AnnouncementUsers = new HashSet<AnnouncementUser>();
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int Status { get; set; }

        public virtual AppUser User { get; set; }
        public virtual ICollection<AnnouncementUser> AnnouncementUsers { get; set; }
    }
}
