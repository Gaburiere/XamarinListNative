using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GiunecoTeam.Domain.Exceptions;
using GiunecoTeam.Domain.Resources.Reponses;
using Newtonsoft.Json;

namespace GiunecoTeam.Domain.Resources.Impl
{
    public class UserResource: IUserResource
    {
        public async Task<string> Login(string username, string password)
        {
            using (var httpClient = new HttpClient())
            {
                var uri = $"{CommonSetting.EndPointToken}";
                var dictionary = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("password", password),
                    new KeyValuePair<string, string>("grant_type", "password")
                };

                var content = new FormUrlEncodedContent(dictionary);
                var response = await httpClient.PostAsync(uri, content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var goodReponse = JsonConvert.DeserializeObject<LoginResponse>(responseContent);
                    return goodReponse.Token;
                }
                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    var badResponse = JsonConvert.DeserializeObject<BadLoginResponse>(responseContent);
                    throw new RemoteException(badResponse.ErrorMessage);
                }

                throw new RemoteException("Something wrong, please retry later");
            }
        }
    }
}
