using AlsConnect.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlsConnect.Data.Interfaces
{
    public interface ISwitchable
    {
        Status Status { set; get; }
    }
}
