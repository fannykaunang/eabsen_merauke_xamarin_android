using Android.App;
using Android.OS;
using Android.Views;

namespace NavDrawer.Fragments
{
    public class Login : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static Login NewInstance()
        {
            var login = new Login { Arguments = new Bundle() };
            return login;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return inflater.Inflate(Resource.Layout.login, null);
        }
    }
}