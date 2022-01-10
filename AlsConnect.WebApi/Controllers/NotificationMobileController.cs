using AlsConnect.Application.Interfaces;
using AlsConnect.Application.ViewModels.NotificationMobile;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlsConnect.WebApi.Controllers
{
    [Route("api/notification")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [Route("send")]
        [HttpPost]
        public async Task<IActionResult> SendNotification(NotificationModel notificationModel)
        {
            var result = await _notificationService.SendNotification(notificationModel);
            return Ok(result);
        }
        [Route("sendTopic")]
        [HttpPost]
        public async Task<IActionResult> SendNotificationTopic(NotificationTopicViewModel topic)
        {
            var result = await _notificationService.SendTopic(topic);
            return Ok(result);
        }
        [HttpGet]
        public IActionResult Get(string userId)
        {
            var notifications = _notificationService.GetByUserId(Guid.Parse(userId));
            return Ok(notifications);
        }

    }
}
