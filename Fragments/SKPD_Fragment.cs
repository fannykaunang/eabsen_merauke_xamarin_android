using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using NavDrawer.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Refit;

namespace NavDrawer.Fragments
{
    public class SKPD_Fragment : Android.Support.V4.App.Fragment
    {
        private PokemonService pokemonService;
        private List<Pokemon> pokemons = new List<Pokemon>();
        private RecyclerView pokeRecycler;
        private PokemonAdapter adapter;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public static SKPD_Fragment NewInstance()
        {
            var skpd_fragment = new SKPD_Fragment { Arguments = new Bundle() };
            return skpd_fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var rootView = inflater.Inflate(Resource.Layout.SKPDModel, container, false);

            pokeRecycler = rootView.FindViewById<RecyclerView>(Resource.Id.recycler_skpd);
            pokeRecycler.HasFixedSize = true;
            adapter = new PokemonAdapter(pokemons, Activity);
            pokeRecycler.SetAdapter(adapter);

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = { new StringEnumConverter() }
            };

            try
            {
                pokemonService = RestService.For<PokemonService>("https://api.myjson.com");
            }
            catch (Exception e)
            {
                Log.Error("TAGG", e.StackTrace);
            }
            getData();
            return rootView;
        }

        private async void getData()
        {
            try
            {
                MyResponse responses = await pokemonService.getMyResponse();
                pokemons = responses.ClassPegawai;
                adapter.setItems(pokemons);
            }
            catch (Exception e)
            {
                Toast.MakeText(Activity, e.StackTrace, ToastLength.Long).Show();
            }


        }
    }
}