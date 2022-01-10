using AlsConnect.Data.Enums;
using AlsConnect.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;

namespace AlsConnect.Data.EF.Entities
{
    public class Notification : DomainEntity<int>
    {
        public Notification()
        {
        }
        public Notification(string title, string subTitle, string body,
             Guid? userId,
            string description, int? type,string note)
        {
            Title = title;
            SubTitle = subTitle;
            Body = body;
            Created = DateTime.Now;
            UserID = userId;
            Description = description;
            Type = type;
            Note = note;

        }
        public string Title { set; get; }
        public string SubTitle { set; get; }
        public string Body { set; get; }
        public DateTime? Created { set; get; }
        public Guid? UserID { set; get; }
        public string Description { set; get; }
        public int? Type { set; get; }
        public string Note { set; get; }
    }
}
