using System;
using System.Collections.Generic;
using System.Text;

namespace AlsConnect.Application.ViewModels.System
{
    public class RegisterRequest
    {
        public string Email { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
    }
}
