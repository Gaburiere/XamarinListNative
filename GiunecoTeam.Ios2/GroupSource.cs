using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using GiunecoTeam.Domain.Models;
using UIKit;

namespace GiunecoTeam.Ios2
{
    public class GroupSource: UITableViewSource
    {
        private const string ReuseId = "GroupViewCell";
        private readonly IEnumerable<Group> _groups;
        private readonly UIViewController _controller;

        public GroupSource(IEnumerable<Group> groups, UIViewController controller)
        {
            _groups = groups;
            _controller = controller;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (GroupViewCell)tableView.DequeueReusableCell(ReuseId, indexPath);
            cell.Controller = _controller;

            var group = this._groups.ElementAt(indexPath.Row);


            cell.UpdateCell(group);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _groups.Count();
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return new nfloat(200);
        }
    }
}