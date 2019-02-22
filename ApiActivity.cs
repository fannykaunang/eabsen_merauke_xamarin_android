using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using NavDrawer.Interface;
using NavDrawer.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Refit;

namespace NavDrawer
{
    [Activity(Label = "@string/app_name", MainLauncher = false, LaunchMode = LaunchMode.SingleTop, Icon = "@drawable/fingerprint_icon72")]
    public class ApiActivity : Activity
    {
        IGitHubApi gitHubApi;
        List<User> users = new List<User>();
        List<String> user_names = new List<String>();
        //Button btn_list_users;
        IListAdapter ListAdapter;
        ListView listView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);

                SetContentView(Resource.Layout.fragment1);
                //btn_list_users = FindViewById<Button>(Resource.Id.btn_list_users);
                listView = FindViewById<ListView>(Resource.Id.listview_users);
                //btn_list_users.Click += btn_list_users_Click;

                JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    Converters = { new StringEnumConverter() }
                };

                gitHubApi = RestService.For<IGitHubApi>("https://api.github.com");

            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.StackTrace, ToastLength.Long).Show();
            }
        }

        private async void getUsers()
        {
            try
            {
                ApiResponse response = await gitHubApi.GetUser();
                users = response.items;

                foreach (User user in users)
                {
                    user_names.Add(user.ToString());
                }
                ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, user_names);
                listView.Adapter = ListAdapter;

            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.StackTrace, ToastLength.Long).Show();

            }

        }

        void btn_list_users_Click(object sender, EventArgs e)
        {
            getUsers();
        }
    }
}