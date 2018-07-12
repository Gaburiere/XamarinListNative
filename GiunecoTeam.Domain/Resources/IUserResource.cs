using System.Threading.Tasks;

namespace GiunecoTeam.Domain.Resources
{
    public interface IUserResource
    {
        Task<string> Login(string username, string password);
    }
}