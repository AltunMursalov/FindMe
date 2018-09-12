using Android.App;
using Firebase.Iid;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

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
            SendRegistrationToServerAsync(refreshedToken);
        }

        async Task SendRegistrationToServerAsync(string token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var data = JsonConvert.SerializeObject(new string[] { "Height:175", "Gender:Male" });
                    var stringContent = new StringContent(data, UnicodeEncoding.UTF8, "application/json");
                    await client.PostAsync($"{App.MobileServiceUrl}/api/register/{token}", stringContent);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Debugger.Break();
            }
        }
    }
}