using System;
using ishgroup.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ishgroup.Controllers
{
    [Route("/")]
    public class MainPage : Controller
    {
        
        #region private variables
        
        private static string _emailSender;
        private static string _password;

        private static string _emailReceiver;

        private static int _requestCount = 0;
        
        #endregion

        private readonly IOptions<EmailSettings> _config;

        
        public MainPage(IOptions<EmailSettings> config)
        {
            _emailSender = config.Value.SenderAddress;
            _password = config.Value.Password;
            _emailReceiver = config.Value.ReceiverAddress;
        }
        
        // GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmailRequest(string name, string phoneNumber)
        {
            _requestCount += _requestCount == int.MaxValue ? -int.MaxValue : 1;
            
            #region params
            
            name = string.IsNullOrEmpty(name) ? "-" : name;
            phoneNumber = string.IsNullOrEmpty(phoneNumber) ? "-" : phoneNumber;

            #endregion

            Email emailSender = new Email(_emailSender);
            emailSender.Password = _password;
            
            emailSender.Subject = $"Заявка №{_requestCount}";
            emailSender.Text = $"Имя: {name}\nНомер телефона: {phoneNumber}\n";

            emailSender.SendEmail("Iskander",_emailReceiver);

            return View("Index");
        }
    }
}