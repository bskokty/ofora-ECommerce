using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Commonn
{
    public class MailOparation
    {



        public class MailOparations
        {



            public static bool sendMailFORapp(string subject, string body, string to)
            {
                string[] tof = to.Split(',');

                string smtpClient = "10.0.0.26"; // "smtp.live.com";
                int smtpPort = 25; //587;

                string displayName = "Biggrewards";

                //string displayName = "Biggstars-GLOBAL EMPLOYEE INCENTIVE & SOCIAL RECOGNITION PLATFORM";
                //string SmtpCredentialUserName = "gecici@biggrewards.com";
                //string SmtpCredentialPassword = "B7hQ8u";

                string SmtpCredentialUserName = "info@biggrewards.com";
                string SmtpCredentialPassword = "MeN86K";

                return sendMail(smtpClient, smtpPort, new System.Net.NetworkCredential(SmtpCredentialUserName, SmtpCredentialPassword), displayName, tof, subject, body);
            }

            public static bool sendMail(string host, int port, NetworkCredential senderInfo, string senderdisplayName,
                                 string[] to, string subject, string body)
            {


                var mail = new MailMessage();
                MailAddress bcc = new MailAddress("ukanaatli@aristo.com.tr");
                mail.Bcc.Add(bcc);

                //MailAddress bcc2 = new MailAddress("dcay@sanalmagaza.com");
                //mail.Bcc.Add(bcc2);

                //MailAddress bcc3 = new MailAddress("eerbak@sanalmagaza.com");
                //mail.Bcc.Add(bcc3);

                MailAddress bcc4 = new MailAddress("mgursoy@sanalmagaza.com");
                mail.Bcc.Add(bcc4);


                MailAddress bcc5 = new MailAddress("makdeniz@sanalmagaza.com");
                mail.Bcc.Add(bcc5);

                mail.From = new MailAddress(senderInfo.UserName, senderdisplayName);


                foreach (var item in to)
                {
                    mail.To.Add(item);
                }


                mail.Subject = subject;
                mail.IsBodyHtml = true;
                mail.Body = body;

                var smtp = new SmtpClient
                {
                    Host = host,
                    Port = port,
                    EnableSsl = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderInfo.UserName, senderInfo.Password)
                };


                try
                {
                    smtp.Send(mail);
                }
                catch (Exception ex)
                {
                    return false;
                }
                return true;
            }


        }
    }
}