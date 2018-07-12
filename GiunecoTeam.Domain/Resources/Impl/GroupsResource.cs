using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using GiunecoTeam.Domain.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GiunecoTeam.Domain.Resources.Impl
{
    public class GroupsResource: IGroupsResource
    {
        public async Task<IEnumerable<Group>> Get()
        {
            using (var httpClient = new HttpClient())
            {
                var uri = $"{CommonSetting.EndPoint}groups";
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {CommonSetting.Token}");
                var response = await httpClient.GetAsync(uri);
                var stringContent = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<IEnumerable<Group>>(stringContent);
                return data;
            }
        }

        public async Task<IEnumerable<Group>> LocalGet(Stream dbStream)
        {
            var sr = new StreamReader(dbStream);
            //todo capire perché non fa più il read async
            var dataString = sr.ReadToEnd();
            var data = JObject.Parse(dataString).SelectToken("groups").ToString();
            var team = JsonConvert.DeserializeObject<IEnumerable<Group>>(data);
            return team;
        }
    }
}
