using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace NavDrawer
{
    [Activity(Label = "@string/app_name", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, Icon = "@drawable/fingerprint_icon72")]
    public class LoginActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login);
            this.Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

            Button BtnLogin = FindViewById<Button>(Resource.Id.login_button);
            BtnLogin.Click += BtnLogin_Click;
        }

        void BtnLogin_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }

    }
}