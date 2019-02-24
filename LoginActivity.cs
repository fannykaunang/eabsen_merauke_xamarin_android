using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace NavDrawer
{
    [Activity(Label = "@string/app_name", MainLauncher = true, NoHistory = true, LaunchMode = LaunchMode.SingleTop, Icon = "@drawable/fingerprint_icon72")]
    public class LoginActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var intent = new Intent(this, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);
            intent.AddFlags(ActivityFlags.SingleTop);
            StartActivity(intent);
            Finish();
        }

        void BtnLogin_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }

    }
}