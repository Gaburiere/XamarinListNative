using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GiunecoTeam.Domain.Models;
using GiunecoTeam.Domain.Resources.Impl;
using UIKit;

namespace GiunecoTeam.Ios2
{
    public partial class TeamViewController : UITableViewController
    {
        private readonly TeamResource _teamResource;
        private IEnumerable<TeamMember> _team;

        public TeamViewController (IntPtr handle) : base (handle)
        {
            _teamResource = new TeamResource();

        }

        public override async void ViewDidLoad()
        {
            //TableView.RegisterClassForCellReuse(typeof(TeamMemberCell), "TeamMemberCell");

            _team = await this.GetTeam();
            this.TableView.Source = new TeamSource(_team, this);
        }

        private async Task<IEnumerable<TeamMember>> GetTeam()
        {
            return await _teamResource.Get();
        }
    }
}