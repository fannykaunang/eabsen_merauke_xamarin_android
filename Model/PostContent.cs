using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace NavDrawer.Model
{
   //public class PostContent
   // {
   //     public string user { get; set; }
   //     public string title { get; set; }
   //     public string body { get; set; }
   //     public int id { get; set; }
   // }

    public class PostContent
    {
        [JsonProperty(PropertyName = "body")]
        public string body { get; set; }

        //public override string ToString()
        //{
        //    return body;
        //}
    }
}