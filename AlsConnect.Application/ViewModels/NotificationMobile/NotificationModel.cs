using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace AlsConnect.Application.ViewModels.NotificationMobile
{
    public class NotificationModel
    {
        [JsonProperty("deviceId")]
        public string DeviceId { get; set; }
        [JsonProperty("isAndroiodDevice")]
        public bool IsAndroiodDevice { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("userID")]
        public Guid? UserID { get; set; }
    }
}
