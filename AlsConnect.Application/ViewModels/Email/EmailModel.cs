using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace AlsConnect.Application.ViewModels.Email
{
    public class EmailModel
    {

        [JsonProperty("receiverId")]
        public string ReceiverId { get; set; }
        [JsonProperty("userName")]
        public string UserName { get; set; }
    }
}
