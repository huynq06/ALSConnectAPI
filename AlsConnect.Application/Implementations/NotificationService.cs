using AlsConnect.Application.Interfaces;
using AlsConnect.Application.ViewModels.NotificationMobile;
using AlsConnect.Utilities.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CorePush.Google;
using static AlsConnect.Application.ViewModels.NotificationMobile.GoogleNotification;
using FirebaseAdmin.Messaging;
using AlsConnect.Infrastructure.Interfaces;
using AlsConnect.Data.EF.IRepository;
using AlsConnect.Application.ViewModels.Notification;
using AlsConnect.Utilities.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;

namespace AlsConnect.Application.Implementations
{
    public class NotificationService : INotificationService
    {
        private readonly FcmNotificationSetting _fcmNotificationSetting;
        IUnitOfWork _unitOfWork;
        INotificationRepository _notificationRepository;
        public NotificationService(IOptions<FcmNotificationSetting> settings, INotificationRepository notificationRepository, IUnitOfWork unitOfWork)
        {
            _fcmNotificationSetting = settings.Value;
            this._notificationRepository = notificationRepository;
            this._unitOfWork = unitOfWork;
        }

        public NotificationViewModel Add(NotificationViewModel notifyVM)
        {
            var notify = Mapper.Map<NotificationViewModel, AlsConnect.Data.EF.Entities.Notification>(notifyVM);
           _notificationRepository.Add(notify);
            return notifyVM;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<NotificationViewModel> GetAll()
        {
            return _notificationRepository.FindAll().ProjectTo<NotificationViewModel>().ToList();
        }

        public PagedResult<NotificationViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public NotificationViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<NotificationViewModel> GetByUserId(Guid userId)
        {
            return _notificationRepository.FindAll(c=>c.UserID==userId).ProjectTo<NotificationViewModel>().ToList();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> SendNotification(NotificationModel notificationModel)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                if (notificationModel.IsAndroiodDevice)
                {
                    /* FCM Sender (Android Device) */
                    FcmSettings settings = new FcmSettings()
                    {
                        SenderId = _fcmNotificationSetting.SenderId,
                        ServerKey = _fcmNotificationSetting.ServerKey
                    };
                    HttpClient httpClient = new HttpClient();

                    string authorizationKey = string.Format("keyy={0}", settings.ServerKey);
                    string deviceToken = notificationModel.DeviceId;

                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authorizationKey);
                    httpClient.DefaultRequestHeaders.Accept
                            .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    DataPayload dataPayload = new DataPayload();
                    dataPayload.Title = notificationModel.Title;
                    dataPayload.Body = notificationModel.Body;

                    GoogleNotification notification = new GoogleNotification();
                    notification.Data = dataPayload;
                    notification.Notification = dataPayload;

                    var fcm = new FcmSender(settings, httpClient);
                    var fcmSendResponse = await fcm.SendAsync(deviceToken, notification);

                    if (fcmSendResponse.IsSuccess())
                    {
                        response.IsSuccess = true;
                        response.Message = "Notification sent successfully";
                        NotificationViewModel notifyVM = new NotificationViewModel();
                        notifyVM.UserID = notificationModel.UserID;
                        notifyVM.Title = notificationModel.Title;
                        notifyVM.Body = notificationModel.Body;
                        notifyVM.Description = "";
                        notifyVM.Type = notificationModel.Type;
                        notifyVM.Description = notificationModel.Description;
                        var notify = Mapper.Map<NotificationViewModel, AlsConnect.Data.EF.Entities.Notification>(notifyVM);
                        _notificationRepository.Add(notify);
                        _unitOfWork.Commit();
                        return response;
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.Message = fcmSendResponse.Results[0].Error;
                        return response;
                    }
                }
                else
                {
                    /* Code here for APN Sender (iOS Device) */
                    //var apn = new ApnSender(apnSettings, httpClient);
                    //await apn.SendAsync(notification, deviceToken);
                }
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Something went wrong";
                return response;
            }
        }

        public async Task<NotificationResultTopic> SendTopic(NotificationTopicViewModel topic)
        {

            var message = new Message()
            {
                Notification = new FirebaseAdmin.Messaging.Notification()
                {
                    Title = topic.Title,
                    Body = topic.Body,
                },
                Topic = "ALS",
            };
            var result = await FirebaseMessaging.DefaultInstance.SendAsync(message);

            return new NotificationResultTopic()
            {
                Error= "No",
                Code = 200,
                Message = result
            };
        }
    }
}
