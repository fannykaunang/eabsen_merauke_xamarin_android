using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NavDrawer.Model;
using Newtonsoft.Json;

namespace NavDrawer
{
    [Activity(Label = "@string/app_name", MainLauncher = false, LaunchMode = LaunchMode.SingleTop, Icon = "@drawable/fingerprint_icon72")]
    public class LayoutActivity : Activity
    {
        private ListView listView;
        private TextView txtNama;
        private TextView txtSKPD;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_detail_pegawai);
            listView = FindViewById<ListView>(Resource.Id.listview_get_users);
            txtNama = FindViewById<TextView>(Resource.Id.user_profile_name);
            txtSKPD = FindViewById<TextView>(Resource.Id.txtSKPD);

            var selectedItem = JsonConvert.DeserializeObject<Pegawai>(Intent.GetStringExtra("selectedItem"));

            txtNama.Text = selectedItem.NAMA_PEGAWAI;
            txtSKPD.Text = selectedItem.NAMA_SKPD; //"USERID: " + Convert.ToString(selectedItem.USERID);

            //string _objectstring = Intent.GetStringExtra("selectedItemId") ?? "Tidak ada data";
            //string _objectstring2 = Intent.GetStringExtra("selectedItem") ?? "Tidak ada data";
            //if (!string.IsNullOrEmpty(_objectstring))
            //{
            //    //var arr = JsonConvert.DeserializeObject<Pegawai>(_objectstring);

            //    txtNama.Text = _objectstring;
            //    txtSKPD.Text = _objectstring2;
            //}
        }
    }
}