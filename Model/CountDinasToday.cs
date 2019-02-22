using Newtonsoft.Json;

namespace NavDrawer.Model
{
    class CountDinasToday
    {
        [JsonProperty("DINAS")]
        public string Content { get; set; }

        public override string ToString()
        {
            return Content;
        }
    }
}