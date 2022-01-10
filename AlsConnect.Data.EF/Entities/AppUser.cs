using AlsConnect.Data.Enums;
using AlsConnect.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlsConnect.Data.EF.Entities
{
    [Table("AppUsers")]
    public partial class AppUser : IdentityUser<Guid>, IDateTracking, ISwitchable
    {
        //public AppUser()
        //{
        //    Announcements = new HashSet<Announcement>();
        //    Bills = new HashSet<Bill>();
        //}
        public AppUser() { }
        public AppUser(Guid id, string fullName, string userName,
            string email, string phoneNumber, string avatar, Status status)
        {
            Id = id;
            FullName = fullName;
            UserName = userName;
            Email = email;
            PhoneNumber = phoneNumber;
            Avatar = avatar;
            Status = status;
        }

        public string FullName { get; set; }
        public DateTime? BirthDay { get; set; }
        public decimal Balance { get; set; }
        public string Avatar { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
      
        public virtual ICollection<Announcement> Announcements { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public Status Status { get; set; }
    }
}
