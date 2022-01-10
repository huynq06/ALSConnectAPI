using System;
using System.Collections.Generic;
using System.Text;

namespace AlsConnect.Application.ViewModels.Notification
{
    public class NotificationViewModel
    {
        public string Title { set; get; }
        public string SubTitle { set; get; }
        public string Body { set; get; }
        public Guid? UserID { set; get; }
        public string Description { set; get; }
        public int? Type { set; get; }
        public string Note { set; get; }
        public DateTime? Created { set; get; }
    }
}
