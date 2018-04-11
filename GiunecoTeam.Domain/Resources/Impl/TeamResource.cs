using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using GiunecoTeam.Domain.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GiunecoTeam.Domain.Resources.Impl
{
    public class TeamResource : ITeamResource
    {
        public async Task<IEnumerable<TeamMember>> Get()
        {
            using (var httpClient = new HttpClient())
            {
                var uri = $"{CommonSetting.EndPoint}team";
                var response = await httpClient.GetAsync(uri);
                var stringContent = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<IEnumerable<TeamMember>>(stringContent);
                return data;
            }
        }

        public async Task<IEnumerable<TeamMember>> LocalGet(Stream dbStrem)
        {
            var sr = new StreamReader(dbStrem);
            var dataString = await sr.ReadToEndAsync();
            var data = JObject.Parse(dataString).SelectToken("team").ToString();
            var team = JsonConvert.DeserializeObject<IEnumerable<TeamMember>>(data);
            return team;
        }
    }
}
