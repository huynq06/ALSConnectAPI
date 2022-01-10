using System;
using System.Collections.Generic;
using System.Text;

namespace AlsConnect.Application.ViewModels.System
{
    public class ChangePasswordRequest
    {
        public string UserName { set; get; }
        public string CurrentPassWord { set; get; }
        public string NewPassWord { set; get; }
    }
}
