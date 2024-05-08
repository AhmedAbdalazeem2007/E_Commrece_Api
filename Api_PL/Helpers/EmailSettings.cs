

namespace Api_PL.Helpers
{
    public  class EmailSettings:IMailSettings
    {
        private readonly MailSettings options;

        public EmailSettings(IOptions<MailSettings> options)
        {
            this.options = options.Value;
        }
        public  void SendEmail(Email email)
        {
         /*   var mail = new MimeMessage()
            {
                Sender = MailboxAddress.Parse(options.email),
                Subject=email.Subject
            }*/
           /* var client = new SmtpClient();
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("email", "password");*/
          //  client.Send()
        
        }

        public void SendEmail(MailSettings mailSettings)
        {
            throw new NotImplementedException();
        }
    }
}
