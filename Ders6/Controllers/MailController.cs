using Ders6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace Ders6.Controllers
{
    public class MailController : Controller
    {
        //Gmail Smtp Ayarları

        private readonly string smtpAddress = "smtp.gmail.com";
        private readonly int portNumber = 587;
        private readonly bool enableSSL = true;
        private readonly string FromEmail = "zeusaku27@gmail.com";
        private readonly string Password = "admin246";


        public IActionResult Index()
        {



            return View();
        }

        [HttpPost]
        public IActionResult SendMail(EmailModel model)
        {
            try
            {

                var SmtpClient = new SmtpClient(smtpAddress)
                {
                    Port=portNumber,
                    Credentials=new NetworkCredential(FromEmail,Password),
                    EnableSsl= enableSSL

                };


                var mailMessage = new MailMessage
                {

                    From = new MailAddress(FromEmail),
                    Subject=model.Subject,
                    Body = model.Body,
                    IsBodyHtml=true


                };

                mailMessage.To.Add(model.ToEmail);
                SmtpClient.Send(mailMessage);
                ViewBag.message = "Email Başarıyla Gönderildi";
                

            }
            catch (Exception ex)
            {
                ViewBag.message = "Email Hata Meydana Geldi"+ex.ToString();


            }


            return View("Index");
        }



    }
}
