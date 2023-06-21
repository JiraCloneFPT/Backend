using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MailKit.Security;

using be.Helpers;
using be.Models;
using be.DTOs;
using be.Services.UserService;

namespace be.Services.OtherService
{
    public class EmailService
    {
        private static EmailService instance;

  

       

        public static EmailService Instance
        {
            get { if (instance == null) instance = new EmailService(); return EmailService.instance; }
            private set { EmailService.instance = value; }
        }

        public async Task<bool> SendMail(string mail, int type, string fullname, string account, string password)
        {
            try
            {
                // With type == 1, reset password
                // With type == 2, send password
                // With type == 3, update account
                string _text = "";
                if (type == 1)
                {
                    _text = EmailHelper.Instance.BodyReset(password);
                }
                if (type == 2)
                {
                    _text = EmailHelper.Instance.Body(fullname, account, password);
                }
                if (type == 3)
                {
                    _text = EmailHelper.Instance.BodyUpdate(fullname, account, password);
                }
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("jira.service.fpt@gmail.com"));
                email.To.Add(MailboxAddress.Parse(mail));
                email.Subject = "JIRA COMFIRMED ACCOUNT";
                email.Body = new TextPart(TextFormat.Html)
                {
                    Text = _text
                };
                var smtp = new SmtpClient();
                await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync("jira.service.fpt@gmail.com", "dvjgqyaqzugkciif");
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public async Task<bool> SendMailCreate(Issue issue, User assignee )
        {


            try
            {
                
                string _text = "";
                    _text = EmailHelper.Instance.BodyUpdateEmail(issue);
                
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("jira.service.fpt@gmail.com"));
                email.To.Add(MailboxAddress.Parse(assignee.Email));
                email.Subject = "[FI2.0 JIRA3] Updates for FSOFTACADEMY-"+ issue.IssueId + ": "+ issue.Summary + "";
                email.Body = new TextPart(TextFormat.Html)
                {
                    Text = _text
                };
                var smtp = new SmtpClient();
                await smtp.ConnectAsync("smtp.gmail.com", 587, false);
                await smtp.AuthenticateAsync("jira.service.fpt@gmail.com", "hcjizzxjmyobukzt");
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
    }
}
