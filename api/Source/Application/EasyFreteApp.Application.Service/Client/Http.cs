using System.Dynamic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EasyFreteApp.Application.Service.Client
{
    public static class Http
    {
        private static readonly HttpClient _client = new HttpClient();

        public static async Task<string> Get(string url)
        {
           var response = await _client.GetAsync(url);

               response.EnsureSuccessStatusCode();

            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
