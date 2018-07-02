using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using GiunecoTeam.Domain.Models;
using UIKit;

namespace GiunecoTeam.Ios2
{
    public class TeamSource : UITableViewSource
    {
        private const string ReuseId = "TeamMemberCell";
        private readonly IEnumerable<TeamMember> _team;
        private readonly UIViewController _controller;

        public TeamSource(IEnumerable<TeamMember> team, UIViewController teamViewController)
        {
            _team = team;
            _controller = teamViewController;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (TeamMemberCell)tableView.DequeueReusableCell(ReuseId, indexPath);
            var teamMember = this._team.ElementAt(indexPath.Row); // todo check outofindex?


            cell.UpdateCell(teamMember);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _team.Count();
        }
    }
}