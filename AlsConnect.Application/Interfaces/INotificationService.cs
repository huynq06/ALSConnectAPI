using AlsConnect.Application.ViewModels.Notification;
using AlsConnect.Application.ViewModels.NotificationMobile;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AlsConnect.Utilities.Dtos;
namespace AlsConnect.Application.Interfaces
{
    public interface INotificationService
    {
        Task<ResponseModel> SendNotification(NotificationModel notificationModel);
        Task<NotificationResultTopic> SendTopic(NotificationTopicViewModel topic);
        List<NotificationViewModel> GetAll();
        List<NotificationViewModel> GetByUserId(Guid userId);
        PagedResult<NotificationViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize);
        NotificationViewModel GetById(int id);
        NotificationViewModel Add(NotificationViewModel product);
        void Delete(int id);
        void Save();
    }
}
