using System;
using System.Threading.Tasks;
using ApplicationCore.NotificationConfig;
using ApplicationCore.ServiceInterfaces;
using Microsoft.Azure.NotificationHubs;
using Newtonsoft.Json;

namespace ApplicationCore.ServiceImplementations
{
    public class SubscribeService : ISubscribeService
    {
        private readonly NotificationHubClient hub;

        public SubscribeService()
        {
            this.hub = Notifications.Instance.Hub;
        }

        public async Task<NotificationOutcome> Notify(NotificationConfig.Notification notification)
        {
            var jsonNotif = JsonConvert.SerializeObject(new
            {
                notification =
                new { body = notification.Body, title = notification.Title, tags = notification.Tags }
            });
            return await Notifications.Instance.Hub.SendGcmNativeNotificationAsync(jsonNotif);
        }

        public async Task<GcmRegistrationDescription> Subsribe(string[] tags, string regId)
        {
            GcmRegistrationDescription result = null;
            var isRegIdExist = await this.hub.RegistrationExistsAsync(regId);
            if (isRegIdExist)
            {
                await this.hub.DeleteRegistrationAsync(regId);
            }

            if (tags != null)
                result = await this.hub.CreateGcmNativeRegistrationAsync(regId, tags);
            else
                result = await this.hub.CreateGcmNativeRegistrationAsync(regId);
            return result;
        }

        public async Task<bool> Unsubscribe(string[] tags, string id)
        {
            try
            {
                foreach (var item in tags)
                {
                    await this.hub.DeleteRegistrationAsync(id, item);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}