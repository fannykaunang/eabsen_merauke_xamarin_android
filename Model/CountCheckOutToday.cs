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
    public class CountCheckOutToday
    {
        [JsonProperty("CHECKOUT_COUNT")]
        public string Content { get; set; }

        public override string ToString()
        {
            return Content;
            //return string.Format(
            //    "Post Id: {0}\nTitle: {1}\nBody: {2}",
            //    Id, Title, Content);
        }
    }
}