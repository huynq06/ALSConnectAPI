using AlsConnect.Application.ViewModels.Email;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlsConnect.Application.Interfaces
{
    public interface IEmailService
    {
        Task<ResponseSendEmail> SendEmail(EmailModel emailModel);
    }
}
