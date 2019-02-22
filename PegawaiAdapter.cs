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
using NavDrawer.Model;

namespace NavDrawer
{
    class PegawaiAdapter : BaseAdapter
    {
        private readonly Context c;
        private readonly JavaList<PegawaiImg> pegawai;
        private LayoutInflater inflater;
        //private Context context;

        //public PegawaiAdapter(Context context)
        //{
        //    this.context = context;
        //}

        public PegawaiAdapter(Context c, JavaList<PegawaiImg> pegawai)
        {
            this.c = c;
            this.pegawai = pegawai;
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return pegawai.Get(position);
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            //INITIALIZE INFLATER
            if (inflater == null)
            {
                inflater = (LayoutInflater)c.GetSystemService(Context.LayoutInflaterService);
            }

            //INFLATE OUR MODEL LAYOUT
            if (convertView == null)
            {
                convertView = inflater.Inflate(Resource.Layout.PegawaiModel, parent, false);
            }

            //BIND DATA
            PegawaiAdapterViewHolder holder = new PegawaiAdapterViewHolder(convertView)
            {
                NameTxt = { Text = pegawai[position].NAMA_PEGAWAI }
            };
            holder.Img.SetImageResource(Convert.ToInt32(pegawai[position].FOTO_FILEPATH));
            //holder.Img.SetImageDrawable(ImageManager.Get(parent.Context, users[position].ImageUrl));
            //convertView.SetBackgroundColor(Color.LightBlue);

            return convertView;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get { return pegawai.Size(); }
        }

    }

    class PegawaiAdapterViewHolder : Java.Lang.Object
    {
        //adapter views to re-use
        public TextView NameTxt;
        public ImageView Img;

        public PegawaiAdapterViewHolder(View itemView)
        {
            NameTxt = itemView.FindViewById<TextView>(Resource.Id.nameTxt);
            Img = itemView.FindViewById<ImageView>(Resource.Id.spacecraftImg);

        }
    }
}