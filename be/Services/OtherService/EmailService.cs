using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MailKit.Security;
using Org.BouncyCastle.Crypto.Generators;
using be.Helpers;

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
                string _text = "";
                if (type == 1)
                {
                    _text = EmailHelper.Instance.BodyReset(password);
                }
                else
                {
                    _text = EmailHelper.Instance.Body(fullname, account, password);
                }
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("vmhsky7@gmail.com"));
                email.To.Add(MailboxAddress.Parse(mail));
                email.Subject = "JIRA COMFIRMED ACCOUNT";
                email.Body = new TextPart(TextFormat.Html)
                {
                    Text = _text
                };
                var smtp = new SmtpClient();
                await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync("vmhsky7@gmail.com", "dvjgqyaqzugkciif");
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
