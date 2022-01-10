using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace AlsConnect.Application.ViewModels.NotificationMobile
{
    public class ResponseModel
    {
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
