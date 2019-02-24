using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace NavDrawer
{
    [Activity(Label = "@string/app_name", MainLauncher = false, NoHistory = true, Icon = "@drawable/fingerprint_icon72")]
    public class SplashActivity : AppCompatActivity
    {

        protected override void OnResume()
        {
            base.OnResume();

            Task.Run(() =>
            {
                StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            });
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Splash);

            //System.Threading.Thread.Sleep(5000);
            //StartActivity(typeof(MainActivity));
        }
    }
}