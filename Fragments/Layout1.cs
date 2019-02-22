using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using NavDrawer.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace NavDrawer.Fragments
{
    public class Layout1 : Fragment
    {
        private ListView lv;
        private PegawaiAdapter adapter;
        private JavaList<PegawaiImg> pegawai;
        ProgressBar circleprogressbar;
        int progressValue = 0;
        TextView txtAbsensitoday;
        TextView txt_kehadiran;
        TextView txt_tanpaket;
        TextView txt_dinas;
        TextView txt_ijin;
        TextView txt_sakit;
        TextView txt_kepulangan;
        Button btnGet;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static Layout1 NewInstance()
        {
            var layout1 = new Layout1 { Arguments = new Bundle() };
            return layout1;
        }
        
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            //var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            //return inflater.Inflate(Resource.Layout.layout1, container, false);

            var rootView = inflater.Inflate(Resource.Layout.layout1, container, false);
            
            circleprogressbar = rootView.FindViewById<ProgressBar>(Resource.Id.progBar);

            circleprogressbar.Visibility = ViewStates.Gone;

            txtAbsensitoday = rootView.FindViewById<TextView>(Resource.Id.txtAbsensiToday);
            txt_dinas = rootView.FindViewById<TextView>(Resource.Id.txtdinas);
            txt_ijin = rootView.FindViewById<TextView>(Resource.Id.txtijin);
            txt_kehadiran = rootView.FindViewById<TextView>(Resource.Id.txtkehadiran);
            txt_tanpaket = rootView.FindViewById<TextView>(Resource.Id.txttanpaket);
            txt_sakit = rootView.FindViewById<TextView>(Resource.Id.txtsakit);
            txt_kepulangan = rootView.FindViewById<TextView>(Resource.Id.txtkepulangan);

            btnGet = rootView.FindViewById<Button>(Resource.Id.btn_get_absensi);

            getAll();


            txtAbsensitoday.Text = "Absensi hari ini (" + DateTime.Now.ToString("dd MMMM yyyy") + ")";
            //circleprogressbar.Visibility = ViewStates.Visible;
            //lv = rootView.FindViewById<ListView>(Resource.Id.listView);
            //adapter = new PegawaiAdapter(Activity, GetPegawai());

            //lv.Adapter = adapter;
            return rootView;
        }

        private async void getAll()
        {
            circleprogressbar.Visibility = ViewStates.Visible;

            while (progressValue < 100)
            {
                progressValue += 10;
                circleprogressbar.Progress = progressValue;
            }

            using (var client = new HttpClient())
            {
                // send a GET request
                var uri = "http://api-eabsen-merauke.somee.com/api/CountCheckInToday";
                var result = await client.GetStringAsync(uri);

                //handling the answer
                var checkin = JsonConvert.DeserializeObject<List<CountCheckInToday>>(result).First();
                var checkout = JsonConvert.DeserializeObject<List<CountCheckOutToday>>(result).First();
                var tanpaket = JsonConvert.DeserializeObject<List<CountTanpaKetToday>>(result).First();
                var dinas = JsonConvert.DeserializeObject<List<CountDinasToday>>(result).First();
                var sakit = JsonConvert.DeserializeObject<List<CountSakitToday>>(result).First();
                var ijin = JsonConvert.DeserializeObject<List<CountIjinToday>>(result).First();
                var jumpeg = JsonConvert.DeserializeObject<List<CountJumlahPegawai>>(result).First();

                int.TryParse(jumpeg.ToString(), out int val_jumpeg);
                int jumpegs = Convert.ToInt32(val_jumpeg);

                int.TryParse(checkin.ToString(), out int val_checkin);
                int checkins = Convert.ToInt32(val_checkin);

                int.TryParse(checkout.ToString(), out int val_checkout);
                int checkouts = Convert.ToInt32(val_checkout);

                int.TryParse(tanpaket.ToString(), out int val_tanpaket);
                int tanpakets = Convert.ToInt32(val_tanpaket);

                int.TryParse(dinas.ToString(), out int val_dinas);
                int dinass = Convert.ToInt32(val_dinas);

                int.TryParse(sakit.ToString(), out int val_sakit);
                int sakits = Convert.ToInt32(val_sakit);

                int.TryParse(ijin.ToString(), out int val_ijin);
                int ijins = Convert.ToInt32(val_ijin);

                double dblValuecheckins = Convert.ToInt32(val_checkin) / (double)jumpegs * 100;
                double dblValuecheckouts = Convert.ToInt32(val_checkout) / (double)jumpegs * 100;
                double dblValuetanpakets = Convert.ToInt32(val_tanpaket) / (double)jumpegs * 100;
                double dblValuedinass = Convert.ToInt32(val_dinas) / (double)jumpegs * 100;
                double dblValuesakits = Convert.ToInt32(val_sakit) / (double)jumpegs * 100;
                double dblValueijins = Convert.ToInt32(val_ijin) / (double)jumpegs * 100;

                // generate the output
                txt_kehadiran.Text = Convert.ToInt32(checkins).ToString() + " / " + dblValuecheckins.ToString("N", CultureInfo.InvariantCulture) + "%" + "\n(dari " + jumpegs + " Pegawai)";

                txt_kepulangan.Text = Convert.ToInt32(checkouts).ToString() + " / " + dblValuecheckouts.ToString("N", CultureInfo.InvariantCulture) + "%" + "\n(dari " + jumpegs + " Pegawai)";
                
                txt_tanpaket.Text = Convert.ToInt32(tanpakets).ToString() + " / " + dblValuetanpakets.ToString("N", CultureInfo.InvariantCulture) + "%" + "\n(dari " + jumpegs + " Pegawai)";
                
                txt_dinas.Text = Convert.ToInt32(dinass).ToString() + " / " + dblValuedinass.ToString("N", CultureInfo.InvariantCulture) + "%" + "\n(dari " + jumpegs + " Pegawai)";

                txt_sakit.Text = Convert.ToInt32(sakits).ToString() + " / " + dblValuesakits.ToString("N", CultureInfo.InvariantCulture) + "%" + "\n(dari " + jumpegs + " Pegawai)";

                txt_ijin.Text = Convert.ToInt32(ijins).ToString() + " / " + dblValueijins.ToString("N", CultureInfo.InvariantCulture) + "%" + "\n(dari " + jumpegs + " Pegawai)";

            }

            circleprogressbar.Visibility = ViewStates.Gone;
        }
        
        private JavaList<PegawaiImg> GetPegawai()
        {
            pegawai = new JavaList<PegawaiImg>();
            List<PegawaiImg> list = pegawai.ToList();
            PegawaiImg s;
            Thread.Sleep(300);

            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString("http://api-eabsen-merauke.somee.com/api/Pegawai");

                List<Pegawai> PegawaiList = new List<Pegawai>();
                var customers = JsonConvert.DeserializeObject<List<Pegawai>>(json);
                XmlSerializer xmlSerializer = new XmlSerializer(customers.GetType());

                using (StringWriter textWriter = new StringWriter())
                {
                    xmlSerializer.Serialize(textWriter, customers);
                    var xml = textWriter.ToString();

                    string[] arr = XDocument.Parse(xml).Descendants("NAMA_PEGAWAI")
                                        .Select(element => element.Value).ToArray();

                    for (int i = 0; i < arr.Length; i++)
                    {
                        s = new PegawaiImg(arr[i].ToString(), Resource.Drawable.user);
                        pegawai.Add(s);
                    }
                }
            }

            circleprogressbar.Visibility = ViewStates.Invisible;

            return pegawai;

        }
    }
}