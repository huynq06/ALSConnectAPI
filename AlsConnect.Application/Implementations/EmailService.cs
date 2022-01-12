using AlsConnect.Application.Interfaces;
using AlsConnect.Application.ViewModels.Email;
using AlsConnect.Utilities.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity;
using AlsConnect.Data.EF.Entities;

namespace AlsConnect.Application.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSetting;
        private readonly UserManager<AppUser> _userManager;
        public EmailService(IOptions<EmailSettings> settings, UserManager<AppUser> userManager) 
        {
            _emailSetting = settings.Value;
            _userManager = userManager;
        }
        public async Task<ResponseSendEmail> SendEmail(EmailModel emailModel)
        {
            ResponseSendEmail response = new ResponseSendEmail();
            try
            {
                EmailSettings settings = new EmailSettings()
                {
                    Sender = _emailSetting.Sender,
                    Mail_SMTP = _emailSetting.Mail_SMTP,
                    Mail_Port = _emailSetting.Mail_Port,
                    Password = _emailSetting.Password
                };
                var user = await _userManager.FindByEmailAsync(emailModel.ReceiverId);
                if(user == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Email Not exist";
                    return response;
                }
                string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, resetToken, "Abc@123");
                string mail_smtp = settings.Mail_SMTP;// "mail.als.com.vn";
                int mail_port = int.Parse(settings.Mail_Port);
                System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient();
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                System.Net.Mail.MailAddress fromAddress = new System.Net.Mail.MailAddress(settings.Sender);
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;
                message.Subject = "ALS - Reset password request";
                message.From = fromAddress;
                message.To.Add(emailModel.ReceiverId);
                message.Body = "You are receiving this message because you have requested resetting your password on the ALS Site.New password: Abc@123 .Please change password after login!";
                //string[] mails = receive.Split(';');
                //foreach (var item in mails)
                //    if (!string.IsNullOrEmpty(item))
                //        message.To.Add(item);
                smtpClient.Host = mail_smtp;
                smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtpClient.Port = Convert.ToInt32(mail_port);
                smtpClient.Credentials = new System.Net.NetworkCredential(settings.Sender, settings.Password);
                smtpClient.Send(message);
                response.IsSuccess = true;
                response.Message = "Email sent successfully";
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Something went wrong " + ex.StackTrace;
                return response;
            }
        }
    }
}
