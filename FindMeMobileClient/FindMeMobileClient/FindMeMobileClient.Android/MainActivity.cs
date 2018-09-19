using Android.App;
using Android.Content.PM;
using Android.Gms.Common;
using Android.Graphics;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using Firebase.Iid;
using System;
using System.Threading.Tasks;

namespace FindMeMobileClient.Droid
{
    [Activity(Label = "FindMeMobileClient", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public const string TAG = "MainActivity";

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            Window.SetSoftInputMode(SoftInput.AdjustResize);

            IsPlayServicesAvailable();

#if DEBUG
            // Force refresh of the token. If we redeploy the app, no new token will be sent but the old one will
            // be invalid.
            Task.Run(() =>
            {
                // This may not be executed on the main thread.
                FirebaseInstanceId.Instance.DeleteInstanceId();
                Console.WriteLine("Forced token: " + FirebaseInstanceId.Instance.Token);
            });
#endif
        }

        public bool IsPlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                {
                    // In a real project you can give the user a chance to fix the issue.
                    Console.WriteLine($"Error: {GoogleApiAvailability.Instance.GetErrorString(resultCode)}");
                }
                else
                {
                    Console.WriteLine("Error: Play services not supported!");
                    Finish();
                }
                return false;
            }
            else
            {
                Console.WriteLine("Play Services available.");
                return true;
            }
        }
    }

    public class AndroidBug5497WorkaroundForXamarinAndroid
    {
        private readonly View mChildOfContent;
        private int usableHeightPrevious;
        private FrameLayout.LayoutParams frameLayoutParams;

        public static void assistActivity(Activity activity, IWindowManager windowManager)
        {
            new AndroidBug5497WorkaroundForXamarinAndroid(activity, windowManager);
        }

        private AndroidBug5497WorkaroundForXamarinAndroid(Activity activity, IWindowManager windowManager)
        {

            var softButtonsHeight = getSoftbuttonsbarHeight(windowManager);

            var content = (FrameLayout)activity.FindViewById(Android.Resource.Id.Content);
            mChildOfContent = content.GetChildAt(0);
            var vto = mChildOfContent.ViewTreeObserver;
            vto.GlobalLayout += (sender, e) => possiblyResizeChildOfContent(softButtonsHeight);
            frameLayoutParams = (FrameLayout.LayoutParams)mChildOfContent.LayoutParameters;
        }

        private void possiblyResizeChildOfContent(int softButtonsHeight)
        {
            var usableHeightNow = computeUsableHeight();
            if (usableHeightNow != usableHeightPrevious)
            {
                var usableHeightSansKeyboard = mChildOfContent.RootView.Height - softButtonsHeight;
                var heightDifference = usableHeightSansKeyboard - usableHeightNow;
                if (heightDifference > (usableHeightSansKeyboard / 4))
                {
                    // keyboard probably just became visible
                    frameLayoutParams.Height = usableHeightSansKeyboard - heightDifference + (softButtonsHeight / 2);
                }
                else
                {
                    // keyboard probably just became hidden
                    frameLayoutParams.Height = usableHeightSansKeyboard;
                }
                mChildOfContent.RequestLayout();
                usableHeightPrevious = usableHeightNow;
            }
        }

        private int computeUsableHeight()
        {
            var r = new Rect();
            mChildOfContent.GetWindowVisibleDisplayFrame(r);
            return (r.Bottom - r.Top);
        }

        private int getSoftbuttonsbarHeight(IWindowManager windowManager)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                var metrics = new DisplayMetrics();
                windowManager.DefaultDisplay.GetMetrics(metrics);
                int usableHeight = metrics.HeightPixels;
                windowManager.DefaultDisplay.GetRealMetrics(metrics);
                int realHeight = metrics.HeightPixels;
                if (realHeight > usableHeight)
                    return realHeight - usableHeight;
                else
                    return 0;
            }
            return 0;
        }
    }
}