using System.Collections.Generic;

namespace GiunecoTeam.Domain.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GroupImage { get; set; }
        public string Address { get; set; }
        public IEnumerable<TeamMember> GroupMembers { get; set; }
    }
}
