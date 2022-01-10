using System;
using System.Collections.Generic;
using System.Text;

namespace AlsConnect.Application.ViewModels.System
{
    public class ChangeAvatarRequest
    {
        public string UserName { set; get; }
        public string AvatarUrl { set; get; }
    }
}
