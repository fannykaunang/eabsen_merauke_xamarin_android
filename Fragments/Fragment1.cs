using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Lsjwzh.Widget.MaterialLoadingProgressBar;
using NavDrawer.Interface;
using NavDrawer.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Refit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using static Android.Widget.AdapterView;

namespace NavDrawer.Fragments
{
    public class Fragment1 : Fragment
    {
        //IGitHubApi gitHubApi;
        List<User> users = new List<User>();
        List<string> user_names = new List<string>();
        IListAdapter ListAdapter;
        ListView listView;
        ProgressBar circleprogressbar;
        int progressValue = 0;
        private EditText _inputSearch;
        private ArrayAdapter<string> _adapter;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        //async Task btn_list_users_ClickAsync(object sender, EventArgs e)
        //{
        //    circleprogressbar.Visibility = ViewStates.Visible;
        //    ThreadStart myThreadDelegate = new ThreadStart(getUsers);

        //    Thread myThread = new Thread(myThreadDelegate);
        //    myThread.Start();
        //    //await Task.Run(() =>
        //    //{
        //    //    getUsers();
        //    //});
        //}

        private void getAllUsers()
        {
            while (progressValue < 100)
            {
                progressValue += 10;
                circleprogressbar.Progress = progressValue;
                Thread.Sleep(300);
            }

            Activity.RunOnUiThread(async () =>
            {
                //ApiResponse response = await gitHubApi.GetUser();
                //users = response.items;

                //foreach (User user in users)
                //{
                //    user_names.Add(user.ToString());
                //}

                //ListAdapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleListItem1, user_names);
                //listView.Adapter = ListAdapter;

                Uri geturi = new Uri("http://api-eabsen-merauke.somee.com/api/Pegawai"); //replace your xml url  
                HttpClient client = new HttpClient();
                HttpResponseMessage responseGet = await client.GetAsync(geturi);
                string response = await responseGet.Content.ReadAsStringAsync();

                List<Pegawai> PegawaiList = new List<Pegawai>();
                var customers = JsonConvert.DeserializeObject<List<Pegawai>>(response);
                XmlSerializer xmlSerializer = new XmlSerializer(customers.GetType());

                using (StringWriter textWriter = new StringWriter())
                {
                    xmlSerializer.Serialize(textWriter, customers);
                    var xml = textWriter.ToString();

                    string[] arr = XDocument.Parse(xml).Descendants("NAMA_PEGAWAI")
                                        .Select(element => element.Value).ToArray();

                    ListAdapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleListItem1, arr);
                    listView.Adapter = ListAdapter;
                }

                circleprogressbar.Visibility = ViewStates.Invisible;
            });
        }

        private void getUsersByName()
        {
            while (progressValue < 100)
            {
                progressValue += 10;
                circleprogressbar.Progress = progressValue;
                Thread.Sleep(300);
            }

            Activity.RunOnUiThread(async () =>
            {
                Uri geturi = new Uri("http://api-eabsen-merauke.somee.com/api/Pegawai"); //replace your xml url  
                HttpClient client = new HttpClient();
                HttpResponseMessage responseGet = await client.GetAsync(geturi);
                string response = await responseGet.Content.ReadAsStringAsync();

                List<Pegawai> PegawaiList = new List<Pegawai>();
                var customers = JsonConvert.DeserializeObject<List<Pegawai>>(response);
                XmlSerializer xmlSerializer = new XmlSerializer(customers.GetType());

                using (StringWriter textWriter = new StringWriter())
                {
                    xmlSerializer.Serialize(textWriter, customers);
                    var xml = textWriter.ToString();

                    string[] arr = XDocument.Parse(xml).Descendants("NAMA_PEGAWAI")
                                        .Select(element => element.Value).ToArray();

                    _adapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleListItem1, arr);
                    listView.Adapter = _adapter;
                    _adapter.Filter.InvokeFilter(_inputSearch.Text);
                }

                circleprogressbar.Visibility = ViewStates.Invisible;
            });
        }

        public static Fragment1 NewInstance()
        {
            var frag1 = new Fragment1 { Arguments = new Bundle() };
            return frag1;
        }

        private void callUser()
        {
            circleprogressbar.Visibility = ViewStates.Visible;
            ThreadStart myThreadDelegate = new ThreadStart(getAllUsers);

            Thread myThread = new Thread(myThreadDelegate);
            myThread.Start();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            //var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            //return inflater.Inflate(Resource.Layout.fragment1, null);

            //var view = inflater.Inflate(Resource.Layout.fragment1, container, false);
            //var button = view.FindViewById<Button>(Resource.Id.btn_list_users);


            var rootView = inflater.Inflate(Resource.Layout.fragment1, container, false);
            // I just assume the button is in HomePermainan
            var button = rootView.FindViewById<Button>(Resource.Id.btn_list_users);
            var buttonGet = rootView.FindViewById<Button>(Resource.Id.btn_get_users);
            circleprogressbar = rootView.FindViewById<ProgressBar>(Resource.Id.progBar);
            _inputSearch = rootView.FindViewById<EditText>(Resource.Id.inputSearch);

            buttonGet.Click += (sender, args) =>
            {
                circleprogressbar.Visibility = ViewStates.Visible;
                ThreadStart myThreadDelegate = new ThreadStart(getUsersByName);

                Thread myThread = new Thread(myThreadDelegate);
                myThread.Start();
            };

            //callUser();

            button.Click += (sender, args) =>
            {
                circleprogressbar.Visibility = ViewStates.Visible;
                ThreadStart myThreadDelegate = new ThreadStart(getAllUsers);

                Thread myThread = new Thread(myThreadDelegate);
                myThread.Start();
            };
            ////progressBar.Dismiss();

            listView = rootView.FindViewById<ListView>(Resource.Id.listview_users);

            listView.ItemClick += async (object sender, ItemClickEventArgs e) =>
            {
                //Toast.MakeText(Activity, Convert.ToString(listView.GetItemAtPosition(e.Position)), ToastLength.Long).Show();    //This Show Text
                //                                                                                                                //txt2.Text = Convert.ToString(e.Position);   // This Show Index
                //Intent intent = new Intent(Activity, typeof(LayoutActivity));
                //intent.PutExtra("selectedItemId", e.Position);
                ////intent.PutExtra("selectedItemId", 0); // Replace '0' with your data here
                ////intent.PutExtra("selectedItem", JsonConvert.SerializeObject(object)); //replace object with the object of data you want to pass

                //StartActivity(intent);

                Uri geturi = new Uri("http://api-eabsen-merauke.somee.com/api/Pegawai"); //replace your xml url  
                HttpClient client = new HttpClient();
                HttpResponseMessage responseGet = await client.GetAsync(geturi);
                string response = await responseGet.Content.ReadAsStringAsync();

                //JObject joResponse = JObject.Parse(response);
                //JObject ojObject = (JObject)joResponse["NAMA_PEGAWAI"];
                JArray jsonArray = JArray.Parse(response);
                var data = JObject.Parse(jsonArray[e.Position].ToString());

                //Pegawai bsObj = new Pegawai()
                //{
                //    NAMA_PEGAWAI = data.ToString()
                //};
                
                //var resultObject = jsonArray[0]
                //      .Values<JObject>()
                //      .Where(n => n["NAMA_PEGAWAI"].Value<string>() == Convert.ToString(listView.GetItemAtPosition(e.Position)));


                var intent = new Intent(Activity, typeof(LayoutActivity));
                //intent.PutExtra("selectedItemId", Convert.ToString(listView.GetItemAtPosition(e.Position))); // Replace '0' with your data here
                intent.PutExtra("selectedItem", data.ToString()); //replace object with the object of data you want to pass
                StartActivity(intent);

                //List<Pegawai> PegawaiList = new List<Pegawai>();
                //var customers = JsonConvert.DeserializeObject<List<Pegawai>>(response);
                //XmlSerializer xmlSerializer = new XmlSerializer(customers.GetType());

                //using (StringWriter textWriter = new StringWriter())
                //{
                //    xmlSerializer.Serialize(textWriter, customers);
                //    var xml = textWriter.ToString();

                //    string[] arr = XDocument.Parse(xml).Descendants("NAMA_PEGAWAI")
                //                        .Select(element => element.Value).ToArray();

                //    var objectString = customers;
                //    var activity = new Intent(Activity, typeof(LayoutActivity));
                //    activity.PutExtra("getPegawai", arr.First());
                //    StartActivity(activity);
                //}
            };

            return rootView;
        } }
    }