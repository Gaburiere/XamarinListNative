using Foundation;
using System;
using System.Threading.Tasks;
using GiunecoTeam.Domain.Models;
using GiunecoTeam.Domain.Resources;
using GiunecoTeam.Domain.Resources.Impl;
using UIKit;

namespace GiunecoTeam.Ios2
{
    public partial class TeamMemberDetailController : UIViewController
    {
        private int _id;
        private readonly ITeamResource _teamResource;

        public TeamMemberDetailController (IntPtr handle) : base (handle)
        {
            _teamResource = new TeamResource();
        }

        public override async void ViewDidLoad()
        {
            var teamMember = await this.GetTeamMember(_id);
        }

        private async Task<TeamMember> GetTeamMember(int id)
        {
            return await _teamResource.Get(id);
        }

        public void InitTeamMember(int teamMemberId)
        {
            _id = teamMemberId;
        }
    }
}