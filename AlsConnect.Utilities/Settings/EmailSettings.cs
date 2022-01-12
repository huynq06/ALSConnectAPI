using System;
using System.Collections.Generic;
using System.Text;

namespace AlsConnect.Utilities.Settings
{
    public class EmailSettings
    {
        public string Sender { set; get; }
        public string Mail_SMTP { set; get; }
        public string Mail_Port { set; get; }
        public string Password { set; get; }
    }
}
