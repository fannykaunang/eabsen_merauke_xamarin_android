using System.Threading.Tasks;
using Refit;

namespace NavDrawer
{
    interface PokemonService    {
        [Get("/bins/boaiy")]
        Task<MyResponse> getMyResponse();
    }
}