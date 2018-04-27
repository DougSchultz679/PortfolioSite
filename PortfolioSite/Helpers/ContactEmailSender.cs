using Microsoft.AspNet.Identity;
using PortfolioSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PortfolioSite.Helpers
{
    public class ContactEmailSender
    {
        public async Task<ActionResult> SendContactMsg(ContactMsg contactForm)
        {
            try
            {
                EmailService ems = new EmailService();
                IdentityMessage msg = new IdentityMessage();

                msg.Subject = contactForm.Subject;
                msg.Body = "New contact request via portfolio site from: " + contactForm.FromName + Environment.NewLine +
                    "Contact request email: " + contactForm.FromEmail + Environment.NewLine + Environment.NewLine +
                    "Message body:" + Environment.NewLine + contactForm.Body;
                msg.Destination = "vxpx17@gmail.com";

                await ems.SendMailAsync(msg);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await Task.FromResult(0);
            }
            return new EmptyResult();
        }
    }
}