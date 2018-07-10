using GiunecoTeam.Domain.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace GiunecoTeam.Domain.Resources
{
    public interface ITeamResource
    {
        Task<IEnumerable<TeamMember>> Get();
        Task<TeamMember> Get(int id);
        Task<IEnumerable<TeamMember>> LocalGet(Stream dbStrem);
        Task<TeamMember> LocalGet(Stream dbStream, int id);
    }
}
