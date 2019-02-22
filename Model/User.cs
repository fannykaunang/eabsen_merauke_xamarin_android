using Newtonsoft.Json;


namespace NavDrawer.Model
{
   public class User
    {
        [JsonProperty(PropertyName = "login")]
        public string UserName { get; set; }

        public override string ToString()
        {
            return UserName;
        }
    }
}