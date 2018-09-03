using Android.Util;
using Android.App;
using Android.Content.PM;
using Android.OS;

namespace FindMeMobileClient.Droid {
    
    [Activity(Label = "FindMeMobileClient", MainLauncher = true, ConfigurationChanges =ConfigChanges.ScreenSize | ConfigChanges.Orientation, Icon = "@mipmap/icon", Theme = "@style/MainTheme")]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity {
        public const string TAG = "MainActivity";

        protected override void OnCreate(Bundle bundle) {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(bundle);

            #region Rohans changes
            Rg.Plugins.Popup.Popup.Init(this, bundle);
            Xamarin.Forms.Forms.Init(this, bundle); 
            #endregion
            if (Intent.Extras != null) {
                foreach (var key in Intent.Extras.KeySet()) {
                    if (key != null) {
                        var value = Intent.Extras.GetString(key);
                        Log.Debug(TAG, "Key: {0} Value: {1}", key, value);
                    }
                }
            }



            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        public override void OnBackPressed() {
            if (Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed)) {
                // Do something if there are some pages in the `PopupStack`
            } else {
                // Do something if there are not any pages in the `PopupStack`
            }
        }
    }
}