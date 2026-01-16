using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SafeBoda.Admin.Services
{
    public class ApiClient
    {
        private readonly HttpClient _http;
        private readonly AuthService _auth;

        public ApiClient(HttpClient http, AuthService auth)
        {
            _http = http;
            _auth = auth;
        }

        private HttpClient WithAuth()
        {
            _auth.AttachToken(_http);
            return _http;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            return await WithAuth().GetFromJsonAsync<T>(url);
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string url, T data)
        {
            return await WithAuth().PostAsJsonAsync(url, data);
        }
    }
}