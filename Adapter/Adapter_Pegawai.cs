using System;
using System.Collections;
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

namespace NavDrawer.Adapter
{
    class Adapter_Pegawai : BaseAdapter
    {

        Context context;
        private int mRowLayout;
        private List<Pegawai> mFriends;

        public Adapter_Pegawai(Context context, int rowLayout, List<Pegawai> pegawai)
        {
            this.context = context;
            mRowLayout = rowLayout;
            mFriends = pegawai;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            //var view = convertView;
            Adapter_PegawaiViewHolder holder = null;

            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(mRowLayout, parent, false);
            }

            //var nama = view.FindViewById<TextView>(Resource.Id.txtnama);
            //var skpd = view.FindViewById<TextView>(Resource.Id.txtskpd);

            TextView nama = row.FindViewById<TextView>(Resource.Id.txtnama);
            nama.Text = mFriends[position].NAMA_PEGAWAI;

            TextView skpd = row.FindViewById<TextView>(Resource.Id.txtskpd);
            skpd.Text = mFriends[position].NAMA_SKPD;

            row.Click += delegate
            {
                Toast.MakeText(context, nama.Text, ToastLength.Short).Show();
            };

            if (row != null)
                holder = row.Tag as Adapter_PegawaiViewHolder;

            if (holder == null)
            {
                holder = new Adapter_PegawaiViewHolder();
                var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();

                row.Tag = holder;
            }

            row.Click += delegate
            {
                Toast.MakeText(context, nama.Text, ToastLength.Short).Show();
            };
            //fill in your items
            //holder.Title.Text = "new text here";

            return row;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get { return mFriends.Count; }
        }

    }

    class Adapter_PegawaiViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}