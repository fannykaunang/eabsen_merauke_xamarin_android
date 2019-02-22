

using Newtonsoft.Json;
using System.Collections.Generic;

namespace NavDrawer
{

    public class MyResponse
    {
        [JsonProperty(PropertyName = "NAMA_PEGAWAI")]
        public string NAMA_PEGAWAI { get; set; }
        [JsonProperty(PropertyName = "TEMPAT_LAHIR")]
        public string TEMPAT_LAHIR { get; set; }
        [JsonProperty(PropertyName = "Pegawai")]
        public List<Pokemon> ClassPegawai { get; set; }
        [JsonProperty(PropertyName = "USERID")]
        public string USERID { get; set; }

    }


}