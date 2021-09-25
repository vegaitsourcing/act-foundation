using ACTFoundation.Models.Generated;

namespace ACTFoundation.Core.Models
{
    public class EmailSettings
    {
        public EmailSettings(SiteSettings settings)
        {
            this.ServerAddress = settings.SMtpserver;
            this.Port = int.Parse(settings.SMtpport);
            this.Password = settings.Password;
            this.SenderEmailAddress = settings.SenderEmailAddress;
            this.ReceiverEmailAddress = settings.ReceiverEmailAddress;
        }
        public string ServerAddress { get; set; }

        public int Port { get; set; }

        public string SenderEmailAddress { get; set; }

        public string Password { get; set; }

        public string ReceiverEmailAddress { get; set; }
    }
}
