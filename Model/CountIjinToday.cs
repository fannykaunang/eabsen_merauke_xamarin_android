using Newtonsoft.Json;

namespace NavDrawer.Model
{
    public class CountIjinToday
    {
        [JsonProperty("CUTI_IJIN")]
        public string Content { get; set; }

        public override string ToString()
        {
            return Content;
        }
    }
}