using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using static DInTaskSchedulerApi.Tools.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace DInTaskSchedulerApi.Tools
{
    /// <summary>
    /// Tool for send emails
    /// </summary>
    public static class EmailHelper
    {
        public static bool SendEmail(IConfiguration configuration, EmailObject mail)
        {
            try
            {
                var emailSettings = GetEmailSettings(configuration);
                string bodyHtml = mail.Body;
                using (var mailMessage = new MailMessage())
                {
                    using (var client = new SmtpClient(emailSettings.SmtpServer, emailSettings.SmtpPort))
                    {
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential(emailSettings.User, emailSettings.Password);
                        client.EnableSsl = emailSettings.EnableSsl;

                        mailMessage.From = new MailAddress(emailSettings.User);
                        mail.Destinataries.ToList().ForEach(e =>
                        {
                            mailMessage.To.Add(new MailAddress(e));
                        });
                        mailMessage.Subject = mail.Subject;
                        mailMessage.IsBodyHtml = mail.IsHtml;

                        mail.EmbeddedResources.ToList().ForEach(embeddedResource =>
                        {
                            mailMessage.AlternateViews.Add(GetEmbeddedImage(embeddedResource, ref bodyHtml));
                        });

                        mailMessage.Body = bodyHtml;
                        client.Send(mailMessage);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #region Private methods

        private static ConfigEmail GetEmailSettings(IConfiguration configuration)
        {
            return new ConfigEmail()
            {
                SmtpServer = configuration.GetString("EmailSettings:SmtpServer"),
                SmtpPort = configuration.GetInt("EmailSettings:SmtpPort"),
                User = configuration.GetString("EmailSettings:User"),
                Password = Utils.DecodeBase64(configuration.GetString("EmailSettings:Password")),
                EnableSsl = configuration.GetBoolean("EmailSettings:EnableSsl")
            };
        }

        private static AlternateView GetEmbeddedImage(EmailEmbeddedResource embeddedResource, ref string htmlBodyEmail)
        {
            LinkedResource resource = new LinkedResource(embeddedResource.Content);
            string htmlBody = string.Empty;

            if (embeddedResource.Type == EmailEmbeddedResourceType.IMAGE)
            {
                resource = new LinkedResource(embeddedResource.Content, Image.Jpeg);
                if (!string.IsNullOrEmpty(htmlBodyEmail.Trim()))
                {
                    htmlBody = htmlBodyEmail.Replace(string.Format("<img src=\"cid:{0}\"", embeddedResource.Name), string.Format("<img src=\"cid:{0}\"", embeddedResource.GuidId));
                    htmlBodyEmail = htmlBody;
                }
                else
                    htmlBody = string.Format("<img src=\"cid:{0}\">", embeddedResource.GuidId);
            }

            resource.ContentId = embeddedResource.GuidId;
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, Text.Html);
            alternateView.LinkedResources.Add(resource);
            return alternateView;
        }

        private static Attachment GetAttachment(EmailEmbeddedResource embeddedResource)
        {
            Attachment attachment = new Attachment(embeddedResource.Content, embeddedResource.FileName);
            attachment.ContentDisposition.Inline = true;
            return attachment;
        }

        #endregion
    }
}
