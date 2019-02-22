using System;
using Newtonsoft.Json;

namespace NavDrawer.Model
{
    class CountTanpaKetToday
    {
        [JsonProperty("TANPA_KET")]
        public string Content { get; set; }

        public override string ToString()
        {
            return Content;
        }
    }
}