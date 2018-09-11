using System.Collections.Generic;

namespace FindMeServer.NotificationConfig
{
    public class Notification
    {
        public IEnumerable<string> Tags { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}