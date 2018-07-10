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
            this.Title = "Team";
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            _team = await this.GetTeam();
            this.TableView.Source = new TeamSource(_team, this);
            TableView.RowHeight = UITableView.AutomaticDimension;
            TableView.EstimatedRowHeight = 120f;
            TableView.ReloadData();
        }

        private async Task<IEnumerable<TeamMember>> GetTeam()
        {
            return await _teamResource.Get();
        }
    }
}