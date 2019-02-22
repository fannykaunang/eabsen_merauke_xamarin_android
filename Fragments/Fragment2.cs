using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using NavDrawer.Interface;
using NavDrawer.Model;
using Refit;
using System;
using System.Threading;

namespace NavDrawer.Fragments
{
    public class Fragment2 : Fragment
    {
        PostContentAPI postContentAPI;
        ProgressBar circleprogressbar;
        Button btnget;
        TextView txtAbsensi;
        int progressValue = 0;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static Fragment2 NewInstance()
        {
            var frag2 = new Fragment2 { Arguments = new Bundle() };
            return frag2;
        }

        private void getUsers()
        {
            while (progressValue < 100)
            {
                progressValue += 10;
                circleprogressbar.Progress = progressValue;
                Thread.Sleep(300);
            }

            Activity.RunOnUiThread( async() =>
            {

                postContentAPI = RestService.For<PostContentAPI>("https://jsonplaceholder.typicode.com");
                PostContent post = new PostContent
                {
                    //userId = 1,
                    //id = 2,
                    //body = "this body from Xamarin",
                    //name = "fannykaunang from Xamarin",
                    //title = "title from Xamarin"
                };

                PostContent result = await postContentAPI.SubmitPost(post);

                txtAbsensi.Text = result.body.ToString();
                circleprogressbar.Visibility = ViewStates.Invisible;
            });
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            //var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            //return inflater.Inflate(Resource.Layout.fragment2, null);
            var rootView = inflater.Inflate(Resource.Layout.fragment2, container, false);

            circleprogressbar = rootView.FindViewById<ProgressBar>(Resource.Id.progBar);
            txtAbsensi = rootView.FindViewById<TextView>(Resource.Id.txtAbsensi);
            btnget = rootView.FindViewById<Button>(Resource.Id.btnGet);

            btnget.Click += async delegate
            {
                circleprogressbar.Visibility = ViewStates.Visible;
                postContentAPI = RestService.For<PostContentAPI>("https://jsonplaceholder.typicode.com");
                PostContent post = new PostContent
                {
                    //user = "01",
                    //title = "title from Xamarin",
                    body = "this body from Xamarin"
                };

                PostContent result = await postContentAPI.SubmitPost(post);

                txtAbsensi.Text = result.body.ToString();
                circleprogressbar.Visibility = ViewStates.Invisible;
            };

            //txtAbsensi.Text = "Absensi hari ini, tanggal " + DateTime.Now.ToString("dd MMMM yyyy");

            return rootView;
        }
    }
}