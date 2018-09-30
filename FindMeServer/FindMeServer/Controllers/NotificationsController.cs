using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FindMeServer.NotificationConfig;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace FindMeServer.Controllers
{
    [Produces("application/json")]
    [Route("api/Notifications")]
    public class NotificationsController : Controller
    {
        public async Task<HttpResponseMessage> Post([FromBody]JToken notification)
        {
            string message = notification["message"].ToString();
            string title = notification["title"].ToString();
            string[] tags = notification["tags"].ToObject<string[]>();

            var notif = new Notification
            {
                Body = message,
                Tags = tags,
                Title = title
            };
            Microsoft.Azure.NotificationHubs.NotificationOutcome outcome = null;
            HttpStatusCode ret = HttpStatusCode.InternalServerError;

            switch (notification["pns"].ToString().ToLower())
            {
                case "wns":
                    // Windows 8.1 / Windows Phone 8.1
                    var toast = @"<toast><visual><binding template=""ToastText01""><text id=""1"">" + message + "</text></binding></visual></toast>";
                    //outcome = await Notifications.Instance.Hub.SendWindowsNativeNotificationAsync(toast, userTag);
                    break;
                case "apns":
                    // iOS
                    var alert = "{\"aps\":{\"alert\":\"" + message + "\"}}";
                    //outcome = await Notifications.Instance.Hub.SendAppleNativeNotificationAsync(alert, userTag);
                    break;
                case "gcm":
                    // Android
                    var jsonNotif = JsonConvert.SerializeObject(new { notification = 
                        new { body = notif.Body, title = notif.Title, tags = notif.Tags} }
                    );
                    outcome = await Notifications.Instance.Hub.SendGcmNativeNotificationAsync(jsonNotif);
                    break;
            }

            if (outcome != null)
            {
                if (!((outcome.State == Microsoft.Azure.NotificationHubs.NotificationOutcomeState.Abandoned) ||
                    (outcome.State == Microsoft.Azure.NotificationHubs.NotificationOutcomeState.Unknown)))
                {
                    ret = HttpStatusCode.OK;
                }
            }

            return new HttpResponseMessage(ret);
        }
    }
}