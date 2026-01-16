using System.Net.Http.Headers;

namespace SafeBoda.Admin.Services
{
    public class AuthService
    {
        private string _token;

        public bool IsAuthenticated => !string.IsNullOrEmpty(_token);

        public void SetToken(string token)
        {
            _token = token;
        }

        public void Logout()
        {
            _token = null;
        }

        public void AttachToken(HttpClient client)
        {
            if (IsAuthenticated)
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _token);
            }
        }
    }
}