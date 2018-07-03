using Newtonsoft.Json;

namespace GiunecoTeam.Domain.Resources.Reponses
{
    public class LoginResponse
    {
        [JsonProperty("access_token")]
        public string Token { get; set; }
    }

    public class BadLoginResponse
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("error_description")]
        public string ErrorMessage { get; set; }
    }
}
