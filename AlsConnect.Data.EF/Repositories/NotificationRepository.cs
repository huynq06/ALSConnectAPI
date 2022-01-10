using AlsConnect.Data.EF.Entities;
using AlsConnect.Data.EF.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
namespace AlsConnect.Data.EF.Repositories
{
    public class NotificationRepository : EFRepository<Notification, int>, INotificationRepository
    {
        public NotificationRepository(AppDbContext context) : base(context)
        {
        }
    }
}
