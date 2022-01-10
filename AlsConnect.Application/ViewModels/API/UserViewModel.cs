using System;
using System.Collections.Generic;
using System.Text;

namespace AlsConnect.Application.ViewModels.API
{
    public class UserViewModel
    {
         public Guid? Id { set; get; }
         public string Name { set; get; }
        public string Phone { set; get; }
        public DateTime? DOB { set; get; }
        public string token { set; get; }
        public string AvatarUrl { set; get; }
    }
}
