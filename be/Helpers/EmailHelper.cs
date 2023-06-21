﻿using be.DTOs;
using be.Models; 
namespace be.Helpers
{
    public class EmailHelper
    {
        private readonly DbJiraCloneContext _context;

        public EmailHelper()
        {
            _context = new DbJiraCloneContext();
        }
        private static EmailHelper instance;
        public static EmailHelper Instance
        {
            get { if (instance == null) instance = new EmailHelper(); return EmailHelper.instance; }
            private set { EmailHelper.instance = value; }
        }
        public string Body(string fullname, string account, string password)
        {
            return "<!DOCTYPE html>\r\n<html>\r\n\r\n<head>\r\n\r\n    <meta charset=\"utf-8\">\r\n    <meta http-equiv=\"x-ua-compatible\" content=\"ie=edge\">\r\n    <title>Email Confirmation</title>\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\r\n    <style type=\"text/css\">\r\n        @media screen {\r\n            @font-face {\r\n                font-family: 'Source Sans Pro';\r\n                font-style: normal;\r\n                font-weight: 400;\r\n                src: local('Source Sans Pro Regular'), local('SourceSansPro-Regular'), url(https://fonts.gstatic.com/s/sourcesanspro/v10/ODelI1aHBYDBqgeIAH2zlBM0YzuT7MdOe03otPbuUS0.woff) format('woff');\r\n            }\r\n\r\n            @font-face {\r\n                font-family: 'Source Sans Pro';\r\n                font-style: normal;\r\n                font-weight: 700;\r\n                src: local('Source Sans Pro Bold'), local('SourceSansPro-Bold'), url(https://fonts.gstatic.com/s/sourcesanspro/v10/toadOcfmlt9b38dHJxOBGFkQc6VGVFSmCnC_l7QZG60.woff) format('woff');\r\n            }\r\n        }\r\n\r\n        body,\r\n        table,\r\n        td,\r\n        a {\r\n            -ms-text-size-adjust: 100%;\r\n            -webkit-text-size-adjust: 100%;\r\n        }\r\n\r\n        table,\r\n        td {\r\n            mso-table-rspace: 0pt;\r\n            mso-table-lspace: 0pt;\r\n        }\r\n\r\n        img {\r\n            -ms-interpolation-mode: bicubic;\r\n        }\r\n\r\n        a[x-apple-data-detectors] {\r\n            font-family: inherit !important;\r\n            font-size: inherit !important;\r\n            font-weight: inherit !important;\r\n            line-height: inherit !important;\r\n            color: inherit !important;\r\n            text-decoration: none !important;\r\n        }\r\n\r\n        div[style*=\"margin: 16px 0;\"] {\r\n            margin: 0 !important;\r\n        }\r\n\r\n        body {\r\n            width: 100% !important;\r\n            height: 100% !important;\r\n            padding: 0 !important;\r\n            margin: 0 !important;\r\n        }\r\n\r\n        table {\r\n            border-collapse: collapse !important;\r\n        }\r\n\r\n        button {\r\n            background-color: #1a82e2;\r\n            cursor: pointer;\r\n        }\r\n        button:hover{\r\n            background-color: #06294983;\r\n        }\r\n        img {\r\n            height: auto;\r\n            line-height: 100%;\r\n            text-decoration: none;\r\n            border: 0;\r\n            outline: none;\r\n        }\r\n    </style>\r\n\r\n</head>\r\n\r\n<body style=\"background-color: #e9ecef;\">\r\n    <div class=\"preheader\" style=\"display: none; max-width: 0; max-height: 0; overflow: hidden; font-size: 1px; line-height: 1px; color: #fff; opacity: 0;\">\r\n    </div>\r\n    <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">\r\n        <tr>\r\n            <td align=\"center\" bgcolor=\"#e9ecef\">\r\n                <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"max-width: 600px;\">\r\n                    <tr>\r\n                        <td align=\"left\" bgcolor=\"#ffffff\" style=\"padding: 36px 24px 0; border-top: 3px solid #d4dadf;\">\r\n                            <h1 style=\"margin: 0; font-size: 32px; font-weight: 700; letter-spacing: -1px; line-height: 48px;text-align: center;\">Notification</h1>\r\n                        </td>\r\n                    </tr>\r\n                </table>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td align=\"center\" bgcolor=\"#e9ecef\">\r\n                <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"max-width: 600px;\">\r\n                    <tr>\r\n                        <td align=\"left\" bgcolor=\"#ffffff\" style=\"padding: 24px; font-size: 16px; line-height: 24px;\">\r\n                            <p style=\"margin: 0;\">Dear " + fullname + ", <br />\r\n                            Welcome to our Fsoft, we send you an employee account<br /><br />\r\n                 Account: <strong>" + account + "</strong><br /><br />\r\n                            Password: <strong>" + password + "</strong><br /><br /> Thank you very much!\r\n                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" bgcolor=\"#ffffff\">\r\n                            <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">\r\n                                <tr>\r\n                                    <td align=\"center\" bgcolor=\"#ffffff\" style=\"padding: 12px;\">\r\n                                        <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\">\r\n                                            <tr>\r\n                                                <td align=\"center\" bgcolor=\"#1a82e2\" style=\"border-radius: 6px;\">\r\n                                                    \r\n                                                </td>\r\n                                            </tr>\r\n                                        </table>\r\n                                    </td>\r\n                                </tr>\r\n                            </table>\r\n                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" bgcolor=\"#ffffff\"\r\n                            style=\"padding: 24px; font-size: 16px; line-height: 24px; border-bottom: 3px solid #d4dadf\">\r\n                            <p style=\"margin: 0;\">Sincerely,<br> Paste</p>\r\n                        </td>\r\n                    </tr>\r\n                </table>\r\n            </td>\r\n        </tr>\r\n    </table>\r\n</body>\r\n<script>\r\n    function onClick(){\r\n        navigator.clipboard.writeText(\"" + password + "\");\r\n    }\r\n</script>\r\n</html>>";
        }

        public string BodyReset(string password)
        {
            return "<!DOCTYPE html>\r\n<html>\r\n\r\n<head>\r\n\r\n    <meta charset=\"utf-8\">\r\n    <meta http-equiv=\"x-ua-compatible\" content=\"ie=edge\">\r\n    <title>Email Confirmation</title>\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\r\n    <style type=\"text/css\">\r\n        @media screen {\r\n            @font-face {\r\n                font-family: 'Source Sans Pro';\r\n                font-style: normal;\r\n                font-weight: 400;\r\n                src: local('Source Sans Pro Regular'), local('SourceSansPro-Regular'), url(https://fonts.gstatic.com/s/sourcesanspro/v10/ODelI1aHBYDBqgeIAH2zlBM0YzuT7MdOe03otPbuUS0.woff) format('woff');\r\n            }\r\n\r\n            @font-face {\r\n                font-family: 'Source Sans Pro';\r\n                font-style: normal;\r\n                font-weight: 700;\r\n                src: local('Source Sans Pro Bold'), local('SourceSansPro-Bold'), url(https://fonts.gstatic.com/s/sourcesanspro/v10/toadOcfmlt9b38dHJxOBGFkQc6VGVFSmCnC_l7QZG60.woff) format('woff');\r\n            }\r\n        }\r\n\r\n        body,\r\n        table,\r\n        td,\r\n        a {\r\n            -ms-text-size-adjust: 100%;\r\n            -webkit-text-size-adjust: 100%;\r\n        }\r\n\r\n        table,\r\n        td {\r\n            mso-table-rspace: 0pt;\r\n            mso-table-lspace: 0pt;\r\n        }\r\n\r\n        img {\r\n            -ms-interpolation-mode: bicubic;\r\n        }\r\n\r\n        a[x-apple-data-detectors] {\r\n            font-family: inherit !important;\r\n            font-size: inherit !important;\r\n            font-weight: inherit !important;\r\n            line-height: inherit !important;\r\n            color: inherit !important;\r\n            text-decoration: none !important;\r\n        }\r\n\r\n        div[style*=\"margin: 16px 0;\"] {\r\n            margin: 0 !important;\r\n        }\r\n\r\n        body {\r\n            width: 100% !important;\r\n            height: 100% !important;\r\n            padding: 0 !important;\r\n            margin: 0 !important;\r\n        }\r\n\r\n        table {\r\n            border-collapse: collapse !important;\r\n        }\r\n\r\n        button {\r\n            background-color: #1a82e2;\r\n            cursor: pointer;\r\n        }\r\n        button:hover{\r\n            background-color: #06294983;\r\n        }\r\n        img {\r\n            height: auto;\r\n            line-height: 100%;\r\n            text-decoration: none;\r\n            border: 0;\r\n            outline: none;\r\n        }\r\n    </style>\r\n\r\n</head>\r\n\r\n<body style=\"background-color: #e9ecef;\">\r\n    <div class=\"preheader\" style=\"display: none; max-width: 0; max-height: 0; overflow: hidden; font-size: 1px; line-height: 1px; color: #fff; opacity: 0;\">\r\n    </div>\r\n    <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">\r\n        <tr>\r\n            <td align=\"center\" bgcolor=\"#e9ecef\">\r\n                <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"max-width: 600px;\">\r\n                    <tr>\r\n                        <td align=\"left\" bgcolor=\"#ffffff\" style=\"padding: 36px 24px 0; border-top: 3px solid #d4dadf;\">\r\n                            <h1 style=\"margin: 0; font-size: 32px; font-weight: 700; letter-spacing: -1px; line-height: 48px;text-align: center;\">Send Your Account</h1>\r\n                        </td>\r\n                    </tr>\r\n                </table>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td align=\"center\" bgcolor=\"#e9ecef\">\r\n                <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"max-width: 600px;\">\r\n                    <tr>\r\n                        <td align=\"left\" bgcolor=\"#ffffff\" style=\"padding: 24px; font-size: 16px; line-height: 24px;\">\r\n                            <p style=\"margin: 0;\">Dear sir, <br />\r\n                                We have received your request for a new password. Please login with your new password and quickly change it.<br /><br />\r\n                        Your New Password: <strong>" + password + "</strong><br /><br /> Thank you very much!\r\n                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" bgcolor=\"#ffffff\">\r\n                            <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">\r\n                                <tr>\r\n                                    <td align=\"center\" bgcolor=\"#ffffff\" style=\"padding: 12px;\">\r\n                                        <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\">\r\n                                            <tr>\r\n                                                <td align=\"center\" bgcolor=\"#1a82e2\" style=\"border-radius: 6px;\">\r\n                                                    \r\n                                                </td>\r\n                                            </tr>\r\n                                        </table>\r\n                                    </td>\r\n                                </tr>\r\n                            </table>\r\n                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" bgcolor=\"#ffffff\"\r\n                            style=\"padding: 24px; font-size: 16px; line-height: 24px; border-bottom: 3px solid #d4dadf\">\r\n                            <p style=\"margin: 0;\">Sincerely,<br> Paste</p>\r\n                        </td>\r\n                    </tr>\r\n                </table>\r\n            </td>\r\n        </tr>\r\n    </table>\r\n</body>\r\n<script>\r\n    function onClick(){\r\n        navigator.clipboard.writeText(\"" + password + "\");\r\n    }\r\n</script>\r\n</html>>";
        }
      
        public string BodyUpdateEmail(Issue issue)
        {

            string nameProduct = _context.Products.Where(x => x.ProductId == issue.ProductId).Select(x => x.ProductName).FirstOrDefault();
            string nameProject = _context.Projects.Where(x => x.ProjectId == issue.ProjectId).Select(x => x.ProjectName).FirstOrDefault();
            string nameComponent = _context.Components.Where(x => x.ComponentId == issue.ComponentId).Select(x => x.ComponentName).FirstOrDefault();
            string nameStatusIssue = _context.StatusIssues.Where(x => x.StatusIssueId == issue.StatusIssueId).Select(x => x.StatusIssueName).FirstOrDefault();
            string nameIssueType = _context.IssueTypes.Where(x => x.IssueTypeId == issue.IssueTypeId).Select(x => x.IssueTypeName).FirstOrDefault();
            string nameAssignee = _context.Users.Where(x => x.UserId == issue.AssigneeId).Select(x => x.FullName).FirstOrDefault();
            string nameReporter = _context.Users.Where(x => x.UserId == issue.ReporterId).Select(x => x.FullName).FirstOrDefault();
            string namePriority = _context.Priorities.Where(x => x.PriorityId == issue.PriorityId).Select(x => x.PriorityName).FirstOrDefault();
            string nameQC = _context.Qcactivities.Where(x => x.QcactivityId == issue.QcactivityId).Select(x => x.QcactivityName).FirstOrDefault();
            return "<!DOCTYPE html>\r\n<html lang=\"en\">\r\n  <head>\r\n <meta charset=\"UTF-8\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n    <title>Document</title>\r\n    <style>\r\n       .main-table {\r\n        border: solid 1px gray;\r\n        border-collapse: collapse;\r\n      }\r\n      th,\r\n      td {\r\n        padding: 10px;\r\n        color: rgb(70, 68, 68);\r\n      }\r\n  .status {\r\n        color: black;\r\n       background-color: rgb(171, 169, 169);\r\n       }\r\n  </style>\r\n  </head>\r\n  <body>\r\n    <table class=\"small-table\">\r\n        <tr>\r\n            <td>This issue has been <b style=\"color: rgb(97, 97, 243) ;\">CREATED</b></td>\r\n        </tr>\r\n        <tr>\r\n            <td>This issue is now <b>assigned to you</b> </td>\r\n        </tr>\r\n        \r\n    </table>\r\n    <table class=\"main-table\">\r\n      <tbody>\r\n        <tr>\r\n          <td colspan=\"2\" style=\"color: rgb(97, 97, 243)\">\r\n            " + nameProject + "  /FSOFTACADEMY- " + issue.IssueId + "  <b class=\"status\">" + nameStatusIssue+"</b>\r\n          </td>\r\n        </tr>\r\n        <tr>\r\n          <td colspan=\"2\" style=\"font-size: 30px\"><b>" + issue.Summary+"</b></td>`\r\n        </tr>\r\n        <tr>\r\n          <td colspan=\"2\">\r\n            <a href=\"http://127.0.0.1:3000/issues/detail/" + issue.IssueId+ "\">View Issue</a>\r\n          </td>\r\n        </tr>\r\n        <tr>\r\n          <td colspan=\"2\" style=\"font-size: large\">Issue created</td>\r\n        </tr>\r\n        <tr>\r\n          <td colspan=\"2\">\r\n            <b>"+ nameReporter+"</b> created this issue on "+issue.CreateTime.ToString("dd/MMMM/yy hh:mm tt") + "\r\n            \r\n          </td>\r\n        </tr>\r\n        <tr>\r\n          <td>Summary:</td>\r\n          <td>"+issue.Summary + "</td>\r\n        </tr>\r\n        <tr>\r\n          <td>Issue Type:</td>\r\n          <td>"+nameIssueType+ "</td>\r\n        </tr>\r\n        <tr>\r\n          <td>Assignee:</td>\r\n          <td>"+ nameAssignee+ "</td>\r\n        </tr>\r\n        <tr>\r\n          <td>Components:</td>\r\n          <td>"+ nameComponent+ "</td>\r\n        </tr>\r\n        <tr>\r\n          <td>Created:</td>\r\n          <td>"+ issue.CreateTime+ "</td>\r\n        </tr>\r\n        <tr>\r\n          <td>Priority:</td>\r\n          <td>"+ namePriority + "</td>\r\n        </tr>\r\n        <tr>\r\n          <td>Reporter:</td>\r\n          <td>"+ nameReporter + "</td>\r\n        </tr>\r\n        <tr>\r\n          <td>Security Level:</td>\r\n          <td>\r\n            "+issue.SecurityLevel+" \r\n                    </td>\r\n        </tr>\r\n        <tr>\r\n          <td>Check Result:</td>\r\n          <td>OK</td>\r\n        </tr>\r\n        <tr>\r\n          <td>Product:</td>\r\n          <td>"+ nameProduct + "</td>\r\n        </tr>\r\n        <tr>\r\n          <td>QC Activity:</td>\r\n          <td>"+ nameQC + "</td>\r\n        </tr>\r\n        <tr>\r\n          <td>Description:</td>\r\n          <td>"+issue.Description+"</td>\r\n        </tr>\r\n      </tbody>\r\n    </table>\r\n  </body>\r\n</html>\r\n"; 
        }

        public string BodyUpdate(string fullname, string account, string password)
        {
            return "<!DOCTYPE html>\r\n<html>\r\n\r\n<head>\r\n\r\n    <meta charset=\"utf-8\">\r\n    <meta http-equiv=\"x-ua-compatible\" content=\"ie=edge\">\r\n    <title>Email Confirmation</title>\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\r\n    <style type=\"text/css\">\r\n        @media screen {\r\n            @font-face {\r\n                font-family: 'Source Sans Pro';\r\n                font-style: normal;\r\n                font-weight: 400;\r\n                src: local('Source Sans Pro Regular'), local('SourceSansPro-Regular'), url(https://fonts.gstatic.com/s/sourcesanspro/v10/ODelI1aHBYDBqgeIAH2zlBM0YzuT7MdOe03otPbuUS0.woff) format('woff');\r\n            }\r\n\r\n            @font-face {\r\n                font-family: 'Source Sans Pro';\r\n                font-style: normal;\r\n                font-weight: 700;\r\n                src: local('Source Sans Pro Bold'), local('SourceSansPro-Bold'), url(https://fonts.gstatic.com/s/sourcesanspro/v10/toadOcfmlt9b38dHJxOBGFkQc6VGVFSmCnC_l7QZG60.woff) format('woff');\r\n            }\r\n        }\r\n\r\n        body,\r\n        table,\r\n        td,\r\n        a {\r\n            -ms-text-size-adjust: 100%;\r\n            -webkit-text-size-adjust: 100%;\r\n        }\r\n\r\n        table,\r\n        td {\r\n            mso-table-rspace: 0pt;\r\n            mso-table-lspace: 0pt;\r\n        }\r\n\r\n        img {\r\n            -ms-interpolation-mode: bicubic;\r\n        }\r\n\r\n        a[x-apple-data-detectors] {\r\n            font-family: inherit !important;\r\n            font-size: inherit !important;\r\n            font-weight: inherit !important;\r\n            line-height: inherit !important;\r\n            color: inherit !important;\r\n            text-decoration: none !important;\r\n        }\r\n\r\n        div[style*=\"margin: 16px 0;\"] {\r\n            margin: 0 !important;\r\n        }\r\n\r\n        body {\r\n            width: 100% !important;\r\n            height: 100% !important;\r\n            padding: 0 !important;\r\n            margin: 0 !important;\r\n        }\r\n\r\n        table {\r\n            border-collapse: collapse !important;\r\n        }\r\n\r\n        button {\r\n            background-color: #1a82e2;\r\n            cursor: pointer;\r\n        }\r\n        button:hover{\r\n            background-color: #06294983;\r\n        }\r\n        img {\r\n            height: auto;\r\n            line-height: 100%;\r\n            text-decoration: none;\r\n            border: 0;\r\n            outline: none;\r\n        }\r\n    </style>\r\n\r\n</head>\r\n\r\n<body style=\"background-color: #e9ecef;\">\r\n    <div class=\"preheader\" style=\"display: none; max-width: 0; max-height: 0; overflow: hidden; font-size: 1px; line-height: 1px; color: #fff; opacity: 0;\">\r\n    </div>\r\n    <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">\r\n        <tr>\r\n            <td align=\"center\" bgcolor=\"#e9ecef\">\r\n                <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"max-width: 600px;\">\r\n                    <tr>\r\n                        <td align=\"left\" bgcolor=\"#ffffff\" style=\"padding: 36px 24px 0; border-top: 3px solid #d4dadf;\">\r\n                            <h1 style=\"margin: 0; font-size: 32px; font-weight: 700; letter-spacing: -1px; line-height: 48px;text-align: center;\">Notification</h1>\r\n                        </td>\r\n                    </tr>\r\n                </table>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td align=\"center\" bgcolor=\"#e9ecef\">\r\n                <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"max-width: 600px;\">\r\n                    <tr>\r\n                        <td align=\"left\" bgcolor=\"#ffffff\" style=\"padding: 24px; font-size: 16px; line-height: 24px;\">\r\n                            <p style=\"margin: 0;\">Dear " + fullname + ", <br />\r\n                            You have just updated your full name, We send you a new account<br /><br />\r\n                 Account: <strong>" + account + "</strong><br /><br />\r\n                            Password: <strong>" + password + "</strong><br /><br /> Thank you very much!\r\n                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" bgcolor=\"#ffffff\">\r\n                            <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">\r\n                                <tr>\r\n                                    <td align=\"center\" bgcolor=\"#ffffff\" style=\"padding: 12px;\">\r\n                                        <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\">\r\n                                            <tr>\r\n                                                <td align=\"center\" bgcolor=\"#1a82e2\" style=\"border-radius: 6px;\">\r\n                                                    \r\n                                                </td>\r\n                                            </tr>\r\n                                        </table>\r\n                                    </td>\r\n                                </tr>\r\n                            </table>\r\n                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" bgcolor=\"#ffffff\"\r\n                            style=\"padding: 24px; font-size: 16px; line-height: 24px; border-bottom: 3px solid #d4dadf\">\r\n                            <p style=\"margin: 0;\">Sincerely,<br> Paste</p>\r\n                        </td>\r\n                    </tr>\r\n                </table>\r\n            </td>\r\n        </tr>\r\n    </table>\r\n</body>\r\n<script>\r\n    function onClick(){\r\n        navigator.clipboard.writeText(\"" + password + "\");\r\n    }\r\n</script>\r\n</html>>";
        }

    }
}
