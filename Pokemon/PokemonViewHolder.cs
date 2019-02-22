using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace NavDrawer
{
    public class PokemonViewHolder : RecyclerView.ViewHolder
    {

        public TextView pokemonName;
        public ImageView imagePokemon;

        public PokemonViewHolder(View itemView) : base(itemView)
        {
            pokemonName = itemView.FindViewById<TextView>(Resource.Id.pokemonName);
            imagePokemon = itemView.FindViewById<ImageView>(Resource.Id.pokemonImage);
        }
    }
}