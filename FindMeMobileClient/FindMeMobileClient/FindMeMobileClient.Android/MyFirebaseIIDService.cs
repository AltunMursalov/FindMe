using Android.App;
using Firebase.Iid;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.WindowsAzure.MobileServices;

namespace FindMeMobileClient.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class MyFirebaseIIDService : FirebaseInstanceIdService
    {
        public override void OnTokenRefresh()
        {
            var refreshedToken = FirebaseInstanceId.Instance.Token;
            Console.WriteLine($"Token received: {refreshedToken}");
            //SendRegistrationToServerAsync(refreshedToken);
        }

        async Task SendRegistrationToServerAsync(string token)
        {
            try
            {
                // Formats: https://firebase.google.com/docs/cloud-messaging/concept-options
                // The "notification" format will automatically displayed in the notification center if the 
                // app is not in the foreground.
                const string templateBodyFCM =
                    "{" +
                        "\"notification\" : {" +
                        "\"body\" : \"$(messageParam)\"," +
                          "\"title\" : \"Find Me\"," +
                        "\"icon\" : \"myicon\" }" +
                    "}";
                var templates = new JObject();
                templates["genericMessage"] = new JObject
                {
                    {"body", templateBodyFCM}
                };
                var client = new MobileServiceClient(App.MobileServiceUrl);
                var push = client.GetPush();
                await push.RegisterAsync(token, templates);
                // Push object contains installation ID afterwards.
                Console.WriteLine(push.InstallationId.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Debugger.Break();
            }
        }
    }   
}