using Foundation;
using System;
using System.Threading.Tasks;
using FFImageLoading;
using FFImageLoading.Work;
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
            var member = await this.GetTeamMember(_id);
            SetTeamMember(member);

        }

        private void SetTeamMember(TeamMember member)
        {
            ImageService.Instance.LoadUrl(member.Images.ImgFull)
                .ErrorPlaceholder("user.png", ImageSource.CompiledResource)
                .LoadingPlaceholder("loading.png", ImageSource.CompiledResource)
                .Into(this.Image);

            this.Name.Text = member.Fullname;
            this.Role.Text = member.Role;
            this.Email.Text = member.Email;
            //this.Bio.Text = member.Bio;
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