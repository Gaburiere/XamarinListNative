using System.Collections.Generic;
using Foundation;
using GiunecoTeam.Domain.Models;
using UIKit;

namespace GiunecoTeam.Ios
{
    public class TeamCollectionViewSource: UICollectionViewSource
    {
        private const string ReuseId = "TeamMemberCell";

        private readonly IList<TeamMember> _team;
        private readonly UIViewController _controller;

        public TeamCollectionViewSource(IList<TeamMember> team, UIViewController controller)
        {
            _team = team;
            _controller = controller;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var teamMemberViewCell = (TeamMemberViewCell)collectionView.DequeueReusableCell(ReuseId, indexPath);

            var teamMember = _team[indexPath.Row];

            teamMemberViewCell.UpdateCell(teamMember);

            return teamMemberViewCell;
        }

    }
}