using System;
using MailKit.Net.Smtp;
using MimeKit;

namespace ishgroup
{
    public class Email : ISendable
    {
        #region SMTP server settings
        
        private string _smtpServer = "smtp.gmail.com";
        private int _smtpPort = 465;
        
        #endregion
        
        private string _emailAddress;

        /// <summary>
        /// Email sender.
        /// </summary>
        public string EmailAddress
        {
            get => _emailAddress;
            set
            {
                _emailAddress = value;
                // if (IsValidEmail(value))
                // {
                //     _emailAddress = value;
                // }
                // else
                // {
                //     throw new ArgumentException("Invalid email!");
                // }
            }
        }

        private string _password;

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        private string _text;
        /// <summary>
        /// Email text.
        /// </summary>
        public string Text
        {
            get => _text;
            set => _text = value;
        }

        private string _subject;
        /// <summary>
        /// Email subject.
        /// </summary>
        public string Subject
        {
            get => _subject;
            set => _subject = value;
        }

        public Email(string email) => _emailAddress = email;

        // private bool IsValidEmail(string email)
        // {
        //     try
        //     {
        //         var address = new MailAddress(email);
        //         return address.Address == email;
        //     }
        //     catch
        //     {
        //         return false;
        //     }
        // }
        
        /// <summary>
        /// Method for sending emails.
        /// </summary>
        /// <param name="name">Receiver name.</param>
        /// <param name="email">Receiver email.</param>
        /// <returns>1 - sent. 0 - failed.</returns>
        public bool SendEmail(string name, string email)
        {
            var message = new MimeMessage();
            
            #region message params
            
            message.From.Add(new MailboxAddress("ishgroup", EmailAddress));
            message.To.Add(new MailboxAddress("receiver name", email));

            message.Subject = Subject;
            message.Body = new TextPart("plain") { Text= this.Text};

            #endregion

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect(_smtpServer, _smtpPort);
                
                smtpClient.Authenticate(EmailAddress, Password);
            
                try
                {
                    Console.WriteLine("Sending email...");
                    smtpClient.Send(message);
                    Console.WriteLine("Email sent!");
                    
                    smtpClient.Disconnect(true);
                    return true;
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Error!\n{exception.Message}");
                    smtpClient.Disconnect(true);
                    return false;
                }
            }
        }
    }
}