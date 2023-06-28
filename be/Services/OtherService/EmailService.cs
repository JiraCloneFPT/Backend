using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MailKit.Security;

using be.Helpers;
using be.Models;
using be.DTOs;
using be.Services.UserService;
using be.Services.HistoryService;
using be.Services.WatcherService;
using DocumentFormat.OpenXml.Bibliography;

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
                } else if (type == 2)
                {
                    _text = EmailHelper.Instance.Body(fullname, account, password);
                }else
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
        public async Task<bool> SendMailCreate(Models.Issue issue, User assignee )
        {


            try
            {
                
                string _text = "";
                    _text = EmailHelper.Instance.BodyEmailCreateIssue(issue);
                
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
        public async Task<bool> SendMailUpdate(List<string> listwatcher, HistoryForEmail historyForEmail)
        {

            try
            {
                List<string> finalListEmail = new List<string>();

                finalListEmail.Add(historyForEmail.ReporterEmail);
                finalListEmail.Add(historyForEmail.AssigneeEmail);

                for (int i = 0; i < listwatcher.Count; i++)
                {
                    if (listwatcher[i] != historyForEmail.ReporterEmail && listwatcher[i] != historyForEmail.AssigneeEmail)
                    {
                        finalListEmail.Add(listwatcher[i]); 
                    }
                }

                string bodyUpdate = "";

                for (int i = 0; i < historyForEmail.Properties.Count; i++)
                {
                    bodyUpdate += "<tr>\r\n          <td>" + historyForEmail.Properties[i].Property + "</td>\r\n          <td><s>"+ historyForEmail.Properties[i].Orginal + "</s> "+ historyForEmail.Properties[i].New +" </td>\r\n        </tr>";
                }

                string _text = "";
                _text = EmailHelper.Instance.BodyEmailUpdateIssue(historyForEmail, bodyUpdate);

                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("jira.service.fpt@gmail.com"));
                for (int i = 0; i < finalListEmail.Count; i++)
                {

                    email.To.Add(MailboxAddress.Parse(finalListEmail[i]));

                }
                //email.Subject = "[FI2.0 JIRA3] Updates for FSOFTACADEMY-" + issue.IssueId + ": " + issue.Summary + "";
                email.Subject = "[FI2.0 JIRA3] Updates for "+ historyForEmail.ProjectShortName + "-" + historyForEmail.IssueId + " : "+ historyForEmail.IssueSummary+ " "  ;

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
