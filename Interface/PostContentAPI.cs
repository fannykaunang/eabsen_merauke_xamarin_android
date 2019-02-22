using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NavDrawer.Model;
using Refit;

namespace NavDrawer.Interface
{
   public interface PostContentAPI
    {
        [Post("/posts")]
        Task<PostContent> SubmitPost([Body] PostContent post);
    }
}