using System;
using System.Collections.Generic;
using System.Linq;
using GiunecoTeam.Domain.Models;
using UIKit;

namespace GiunecoTeam.Ios2
{
    public class GroupMemberSource : UICollectionViewSource
    {
        private const string ReuseIdentitifier = "GroupMemberViewCell";

        private readonly IEnumerable<TeamMember> _groupMembers;
        private readonly UIViewController _controller;

        public GroupMemberSource(IEnumerable<TeamMember> groupMembers, UIViewController controller)
        {
            _groupMembers = groupMembers;
            _controller = controller;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return this._groupMembers.Count();
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, Foundation.NSIndexPath indexPath)
        {
            var cell = (GroupMemberViewCell)collectionView.DequeueReusableCell(ReuseIdentitifier, indexPath);

            var teamMember = this._groupMembers.ElementAt(indexPath.Row);

            cell.UpdateCell(teamMember);
            return cell;
        }

        public override void ItemSelected(UICollectionView collectionView, Foundation.NSIndexPath indexPath)
        {
            var teamMemberController = _controller.Storyboard.InstantiateViewController("TeamMemberDetail") as TeamMemberDetailController;
            if (teamMemberController == null)
                return;
            var teamMember = _groupMembers.ElementAt(indexPath.Row);
            teamMemberController.InitTeamMember(teamMember.Id);

            _controller.NavigationController.PushViewController(teamMemberController, true);

        }
    }
}