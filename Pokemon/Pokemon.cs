using Android.Util;
using Newtonsoft.Json;
using System;

namespace NavDrawer
{
    public class Pokemon    {
        
        [JsonProperty(PropertyName = "FOTO_FILEPATH")]
        public string url { get; set; }
        [JsonProperty(PropertyName = "NAMA_PEGAWAI")]
        public string name { get; set; }

        public int getPokemonID() {
            string [] tokens = url.Split('/');
            return Int32.Parse(tokens[tokens.Length - 2]);  
        }

    }
}