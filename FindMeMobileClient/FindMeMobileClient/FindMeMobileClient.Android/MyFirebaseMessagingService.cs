using Android.App;
using Android.Content;
using Firebase.Messaging;
using System;
using Xamarin.Forms;

namespace FindMeMobileClient.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        public override void OnMessageReceived(RemoteMessage message)
        {
            base.OnMessageReceived(message);

            Console.WriteLine("Received: " + message);

            // Android supports different message payloads. To use the code below it must be something like this (you can paste this into Azure test send window):
            // {
            //   "notification" : {
            //      "body" : "The body",
            //                 "title" : "The title",
            //                 "icon" : "myicon"
            //   }
            // }
            try
            {
                string[] body = { message.GetNotification().Body, message.GetNotification().Title };
                MessagingCenter.Send<object, string[]>(this, App.NotificationReceivedKey, body);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error extracting message: " + ex);
            }
        }
    }
}