using System.Collections.Generic;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Square.Picasso;

namespace NavDrawer
{
    public class PokemonAdapter : RecyclerView.Adapter
    {

        //private ArrayList pokemons;
        private List<Pokemon> pokemons;
        private Context context;

        public PokemonAdapter(List<Pokemon> pokemons, Context context)
        {
            this.pokemons = pokemons;
            this.context = context;
        }

        public override int ItemCount
        {
            get
            {

                if (pokemons != null)
                {
                    return pokemons.Count;
                }
                else
                {
                    return 0;
                }

            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            PokemonViewHolder pvh = holder as PokemonViewHolder;
            pvh.pokemonName.Text = pokemons[position].name;

            string url = string.Concat("https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/back/shiny/", pokemons[position].getPokemonID(), ".png");

            Picasso.
                With(context).
                Load(url).
                Fit().
                CenterCrop().
                MemoryPolicy(MemoryPolicy.NoCache, MemoryPolicy.NoStore)
                .NetworkPolicy(NetworkPolicy.NoCache, NetworkPolicy.NoStore)
                .Into(pvh.imagePokemon);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View v = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.SKPDItem, parent, false);
            return new PokemonViewHolder(v);
        }

        public void setItems(List<Pokemon> newData)
        {
            pokemons.AddRange(newData);
            NotifyDataSetChanged();
        }
    }
}