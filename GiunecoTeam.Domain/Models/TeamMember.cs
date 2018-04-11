namespace GiunecoTeam.Domain.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
        public string Bio { get; set; }
        public string Email { get; set; }
        public TeamMemberImage Images { get; set; }
        public string Fullname => $"{this.Name} {this.Surname}";
    }
}
