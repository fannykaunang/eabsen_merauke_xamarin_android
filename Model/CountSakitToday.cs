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
    public class CountSakitToday
    {
        [JsonProperty("SAKIT")]
        public string Content { get; set; }

        public override string ToString()
        {
            return Content;
        }
    }
}