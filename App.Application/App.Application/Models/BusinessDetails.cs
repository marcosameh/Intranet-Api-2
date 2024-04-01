namespace App.Application.Models
{
    public class BusinessDetailsSettings
    {
        public string BusinessName { get; set; }
        public string SiteLogo { get; set; }
        public string HostName { get; set; }

        public string Address { get; set; }
        public string Telphone { get; set; }
        public string Email { get; set; }
    }
    public class MailSettings {
        public string APIKey { get; set; }
        public string FromName { get; set; }
        public string FromEmail { get; set; }
    }

    public class AvailabilityCalendarSettings
    {
        public int BookingCutOffDays { get; set;}
    }
}
