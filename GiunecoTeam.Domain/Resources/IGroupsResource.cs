using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using GiunecoTeam.Domain.Models;

namespace GiunecoTeam.Domain.Resources
{
    public interface IGroupsResource
    {
        Task<IEnumerable<Group>> Get();
        Task<IEnumerable<Group>> LocalGet(Stream dbStream);
    }
}
