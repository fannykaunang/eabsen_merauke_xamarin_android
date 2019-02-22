using System.Threading.Tasks;
using Refit;
using NavDrawer.Model;

namespace NavDrawer.Interface
{
    [Headers("User-Agent: :request:")]
    interface IGitHubApi
    {
        [Get("/search/users?q=location:indonesia")]
       Task<ApiResponse> GetUser();
    }
}