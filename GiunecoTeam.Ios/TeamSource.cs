using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using GiunecoTeam.Domain.Models;
using UIKit;

namespace GiunecoTeam.Ios
{
    public class TeamSource: UITableViewSource
    {
        private const string ReuseId = "TeamMemberCell";
        private readonly IEnumerable<TeamMember> _team;
        private readonly UIViewController _controller;

        public TeamSource(IEnumerable<TeamMember> team, UIViewController controller)
        {
            _team = team;
            _controller = controller;
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

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            //var teamMemberDetailController = _controller.Storyboard.InstantiateViewController("TeamMemberDetailController") as TeamMemberDetailController;
            //if (teamMemberDetailController == null) return;

            //var teamMember = _team[indexPath.Row];
            //teamMemberDetailController.InitForCategoryId(teamMember.Id);

            //_controller.NavigationController.PushViewController(teamMemberDetailController, true);

        }
    }
}