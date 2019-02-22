using System;
using Newtonsoft.Json;

namespace NavDrawer.Model
{
    public class CountJumlahPegawai
    {
        [JsonProperty("JUM_PEGAWAI")]
        public string Content { get; set; }

        public override string ToString()
        {
            return Content;
        }
    }
}